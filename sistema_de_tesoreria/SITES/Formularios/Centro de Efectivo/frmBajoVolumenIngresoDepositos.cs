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

namespace GUILayer.Formularios.Centro_de_Efectivo
{
    public partial class frmBajoVolumenIngresoDepositos : Form
    {        

        #region Atributos

        private ProcesamientoBajoVolumenManifiesto _manifiesto = null;
        private Boolean VerificaMonto = true;
        private Colaborador _colaborador = null;
        private Tula _tula = null;
        private AtencionBL _atencion = AtencionBL.Instancia;
        private bool Error = false;
        private Deposito _deposito = null;
        private byte cancelact = 0;
        private int _coordinador = 0;        
        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private LimiteEfectivo _limiteefectivo = null;
        private BindingList<LimiteEfectivo> _listalimiteefectivo;
        private ProcesamientoBajoVolumen _procesamientobajovolumen = null;
        private SeguridadBL _seguridad = SeguridadBL.Instancia;
        int conteoerrores = 0;
        private Stopwatch sw;
        private Boolean permisosup = false;
        long tiempo = 0;
        string datos = "";
        string comentarioincons = "";
        private SerialPort port;
        string nompuerto = "";        
        int idtulapendiente = 0;
        private byte origendiferenciadeposito = 0;
        //private Boolean _manifiesto_pendiente = false;
        private int chkcierremanifiesto = 0;
        private int chktab = 0;
        String numdeposito = "";
        String pdepositante = "";
        private int conteotabs = 0;
        private byte contecodigoVDenter = 0;
        private int conteoshift = 0;
        private int chktime = 0;
        private int nuderror = 0;
        private int nuderror2 = 0;
        private int chklecturacodigo = 0;        
        private ConteoNiquel conteoNiquel = null;
        private ProcesamientoNiquel procesoNiquel = null;
        private decimal MontoContadoManifiesto = 0;
        private Archivos archivo = null;
        private bool hayBilleteFalso = false;


        #endregion Atributos

        #region Constructor

        public frmBajoVolumenIngresoDepositos(ref ProcesamientoBajoVolumenManifiesto manifiesto, ref ProcesamientoBajoVolumen procesamientoBV, Boolean manifiestopendiente, ref Colaborador colaborador)
        {
            InitializeComponent();
            archivo = new Archivos(@"c:\bitacora\bitacora" + colaborador.ID.ToString() + "-" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt");
            archivo.writetext("Inicia constructor frmBajoVolumenIngresoDepositos");
            try
            {
                datos = "";
                _manifiesto = manifiesto;
                _colaborador = colaborador;
                _seguridad.obtenerPerfilesxColaborador(ref _colaborador);
                _tula = new Tula("");
                this.formatoVentana();
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
                _listalimiteefectivo = _mantenimiento.listarLimiteEfectivos(colaborador.ID);
                archivo.writetext("Ingreso Depósito, Cliente en _manifiesto evento constructor: " + _manifiesto.Cliente.Nombre);
                archivo.writetext("Ingreso Depósito, Punto de venta en _manifiesto evento constructor: " + _manifiesto.PuntoVenta.Nombre);
                if (_listalimiteefectivo.Count == 0)
                {
                    MessageBox.Show("El colaborador no posee límite de efectivo asociado");
                    this.Close();
                }                    
                _limiteefectivo = _listalimiteefectivo[0];
                archivo.writetext("Límite de efectivo: "  + _limiteefectivo.LimiteAD.ToString() + "," + _limiteefectivo.LimiteBD.ToString() + "," + _limiteefectivo.LimiteCOL.ToString() + "," + _limiteefectivo.LimiteDOL.ToString());
                _procesamientobajovolumen = procesamientoBV;
                if (_procesamientobajovolumen == null)
                    _procesamientobajovolumen = new ProcesamientoBajoVolumen(montoAD: 0, montoBD: 0, montoDOL: 0, montoCOL: 0, montoEUR: 0);
                if (manifiestopendiente == true)
                {
                    idtulapendiente = _mantenimiento.VerificaTulaPendiente(_manifiesto.ID);
                    archivo.writetext("ID Tula pendiente: " + idtulapendiente.ToString());
                    BindingList<ProcesamientoBajoVolumenDeposito> listadeposito = _mantenimiento.listarProcesamientoBajoVolumenDeposito(_manifiesto);
                    archivo.writetext("Ingreso Depósito, Cliente en _manifiesto evento constructor2: " + _manifiesto.Cliente.Nombre);
                    archivo.writetext("Ingreso Depósito, Punto de venta en _manifiesto evento constructor2: " + _manifiesto.PuntoVenta.Nombre);
                    if (listadeposito.Count > 0)
                    {
                        lstDepósitos.Items.Clear();
                        ListViewItem item;
                        foreach (ProcesamientoBajoVolumenDeposito procesamientodeposito in listadeposito)
                        {
                            _manifiesto.agregarDeposito(procesamientodeposito);
                            archivo.writetext("Ingreso Depósito, Cliente en _manifiesto despues de agregarDeposito: " + _manifiesto.Cliente.Nombre);
                            archivo.writetext("Ingreso Depósito, Punto de venta en _manifiesto despues de agregarDeposito: " + _manifiesto.PuntoVenta.Nombre);
                            _deposito = new Deposito(procesamientodeposito.DB_ID, procesamientodeposito.ID, procesamientodeposito.MontoContado, 0, procesamientodeposito.Moneda,
                                procesamientodeposito.CodigoVD, procesamientodeposito.CodigoTransaccion, procesamientodeposito.Cuenta, procesamientodeposito.Cedula, procesamientodeposito.TipoMesa,
                                procesamientodeposito.MontoNiquel, procesamientodeposito.MontoDeclarado, procesamientodeposito.Diferencia, procesamientodeposito.NumeroDeposito, 
                                procesamientodeposito.Depositante);
                            item = new ListViewItem();
                            item.SubItems[0].Text = procesamientodeposito.NumeroDeposito;
                            item.SubItems.Add(procesamientodeposito.MontoContado.ToString());
                            lstDepósitos.Items.Add(item);
                            archivo.writetext("depósito #" + _deposito.ID);
                            if (_tula.Codigo == "")
                            {
                                _tula = procesamientodeposito.Tula;
                                _tula.agregarDeposito(_deposito);
                                archivo.writetext("agrega deposito " + _deposito.ToString() + " a tula.");
                            }
                            else
                            {
                                if (_tula.ID != procesamientodeposito.Tula.ID)
                                {
                                    archivo.writetext("variable tula: " + _tula.ToString() + ", procesamientodeposito tula: " + procesamientodeposito.Tula.ToString());
                                    archivo.writetext("agrega tula " + _tula.ToString() + " a manifiesto.");
                                    _manifiesto.agregarTula(_tula);
                                    archivo.writetext("Ingreso Depósito, Cliente en _manifiesto _tula.ID != procesamientodeposito.Tula.ID: " + _manifiesto.Cliente.Nombre);
                                    archivo.writetext("Ingreso Depósito, Punto de venta en _manifiesto _tula.ID != procesamientodeposito.Tula.ID: " + _manifiesto.PuntoVenta.Nombre);
                                    _tula = new Tula("");
                                    _tula = procesamientodeposito.Tula;
                                    _tula.agregarDeposito(_deposito);
                                }
                                else
                                {
                                    _tula.agregarDeposito(_deposito);
                                    archivo.writetext("agrega deposito " + _deposito.ToString() + " a tula.");
                                }
                            }
                        }
                        if ((_tula.Codigo != "") && (_manifiesto.Tulas.Count == 0))
                        {
                            _manifiesto.agregarTula(_tula);
                            archivo.writetext("agrega tula "+_tula.ToString() + " a manifiesto cuando no hay tulas asociadas al manifiesto.");
                            archivo.writetext("Ingreso Depósito, Cliente en _manifiesto ((_tula.Codigo != '') && (_manifiesto.Tulas.Count == 0)): " + _manifiesto.Cliente.Nombre);
                            archivo.writetext("Ingreso Depósito, Punto de venta en _manifiesto ((_tula.Codigo != '') && (_manifiesto.Tulas.Count == 0)): " + _manifiesto.PuntoVenta.Nombre);
                            if (idtulapendiente == 0) _tula = new Tula("");
                        }
                        if ((_tula.Codigo != "") && (_manifiesto.Tulas.Count > 0))
                        {
                            if (_manifiesto.Tulas[_manifiesto.Tulas.Count - 1].Codigo != _tula.Codigo)
                            {
                                _manifiesto.agregarTula(_tula);
                                archivo.writetext("agrega tula " + _tula.ToString() + " a manifiesto.");
                                archivo.writetext("Ingreso Depósito, Cliente en _manifiesto (_manifiesto.Tulas[_manifiesto.Tulas.Count - 1].Codigo != _tula.Codigo): " + _manifiesto.Cliente.Nombre);
                                archivo.writetext("Ingreso Depósito, Punto de venta en _manifiesto (_manifiesto.Tulas[_manifiesto.Tulas.Count - 1].Codigo != _tula.Codigo): " + _manifiesto.PuntoVenta.Nombre);
                                if (idtulapendiente == 0) _tula = new Tula(""); //CAMBIO GZH 29092017
                            }
                        }
                        if ((_manifiesto.Tulas[_manifiesto.Tulas.Count - 1].ID == idtulapendiente) && (idtulapendiente != 0))
                        {
                            archivo.writetext("Tula pendiente igual a la ultimo registrada " + idtulapendiente.ToString());
                            archivo.writetext("Ingreso Depósito, Cliente en _manifiesto ((_manifiesto.Tulas[_manifiesto.Tulas.Count - 1].ID == idtulapendiente) && (idtulapendiente != 0)): " + _manifiesto.Cliente.Nombre);
                            archivo.writetext("Ingreso Depósito, Punto de venta en _manifiesto ((_manifiesto.Tulas[_manifiesto.Tulas.Count - 1].ID == idtulapendiente) && (idtulapendiente != 0)): " + _manifiesto.PuntoVenta.Nombre);
                            txtNumero.Text = _manifiesto.Tulas[_manifiesto.Tulas.Count - 1].Codigo;
                            cboTipoMesaNiquel.Items.Clear();                            
                            foreach (Perfil perfil in _colaborador.Perfiles)
                            {
                                if (perfil.ID == 73)
                                {
                                    archivo.writetext("Carga dato combo para cajero niquel.");
                                    cboTipoMesaNiquel.Items.Add("Mesa Níquel");
                                    break;
                                }                                
                            }
                            if (cboTipoMesaNiquel.Items.Count == 0)
                            {
                                cboTipoMesaNiquel.Items.Add("En Mesa");
                                cboTipoMesaNiquel.Items.Add("Cajero Níquel");
                            }                            
                            cboTipoMesaNiquel.SelectedIndex = 0;

                            txtNumero.Enabled = false;
                            //_tula = new Tula(txtNumero.Text);
                            _deposito = new Deposito(0);
                            archivo.writetext("nuevo depósito se crea");
                            epError.SetError(txtNumero, "");
                            gbDatosDeposito.Enabled = true;
                            btnVerificar.Enabled = false;
                            btnCancelarTula.Enabled = false;
                            //btnmodificar.Enabled = false;
                            gbDatosDeposito.Focus();
                            txtCodigoVD.Focus();
                            archivo.writetext("Ingreso Depósito, Cliente en _manifiesto evento constructor3: " + _manifiesto.Cliente.Nombre);
                            archivo.writetext("Ingreso Depósito, Punto de venta en _manifiesto evento constructor3: " + _manifiesto.PuntoVenta.Nombre);
                            if (port != null)
                            {
                                if (port.IsOpen == false) port.Open();
                                btnextraerinfo.Enabled = true;
                                lbldestadolector.BackColor = Color.Green;
                                epError.SetError(btnextraerinfo, "");
                            }
                            else
                            {
                                int i = 0;
                                var ports = SerialPort.GetPortNames().OrderByDescending(name => name);
                                foreach (var portName in ports)
                                {
                                    i += 1;
                                    nompuerto = portName;
                                    break;
                                }
                                if (i > 0)
                                {
                                    port = new SerialPort(nompuerto, 9600, Parity.None, 8, StopBits.One);
                                    port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
                                }
                                else
                                {
                                    port = null;
                                    nompuerto = "";
                                }
                                if (port != null)
                                {
                                    //danilo descomentar esto
                                    if (port.IsOpen == false) port.Open();
                                    btnextraerinfo.Enabled = true;
                                    lbldestadolector.BackColor = Color.Green;
                                    epError.SetError(btnextraerinfo, "");
                                }
                                else
                                {
                                    btnextraerinfo.Enabled = false;
                                    lbldestadolector.BackColor = Color.Red;
                                    epError.SetError(btnextraerinfo, "El puerto del equipo Magner no se encuentra disponible, favor verificar que se encuentra conectado");
                                }                                
                            }
                            chkcierremanifiesto = 1;
                        }
                        //_deposito = new Deposito(0, id:
                    }
                }
            }
            catch (Excepcion ex)
            {
                MessageBox.Show("Error inicializando formulario: " + ex.Message);
            }

         }
         
        /// <summary>
        /// Dar formato a ciertas opciones de la ventana.
        /// </summary>
        private void formatoVentana()
        {
            try
            {
                cboMoneda.SelectedIndex = (byte)Monedas.Colones;
                cboMonedaDeclarada.SelectedIndex = (byte)Monedas.Colones;
                mostrarcamposmoneda(cboMoneda.SelectedIndex);
                sumarTotales();
            }
            catch (Excepcion ex)
            {
                MessageBox.Show("Error formatoventana: " + ex.Message);
            }
            //cboTipoMesaNiquel.SelectedIndex = (byte)Monedas.Colones;
        }

        private void mostrarcamposmoneda(int seleccionmoneda) //Cambio GZH 28/08/2017
        {
            try
            {
                switch (seleccionmoneda)
                {
                    case 0:
                        gbcolones.Visible = true;
                        gbdolares.Visible = false;
                        gbeuros.Visible = false;
                        nudMontoNiquel.Enabled = true;
                        nudMontoNiquel.Value = 0;
                        break;
                    case 1:
                        gbcolones.Visible = false;
                        gbdolares.Visible = true;
                        gbeuros.Visible = false;
                        nudMontoNiquel.Enabled = false;
                        nudMontoNiquel.Value = 0;
                        break;
                    case 2:
                        gbcolones.Visible = false;
                        gbdolares.Visible = false;
                        gbeuros.Visible = true;
                        nudMontoNiquel.Enabled = false;
                        nudMontoNiquel.Value = 0;
                        break;
                }
            }
            catch (Excepcion ex)
            {
                MessageBox.Show("Error mostrarcamposmoneda: " + ex.Message);
            }
        }


        #endregion Constructor               

        #region Eventos

        private void txtNumero_TextChanged(object sender, EventArgs e)
        {
            epError.SetError(txtNumero, "");
        }



        private Boolean validaCampos()
        {
            try
            {
                /*if (_manifiesto.Tulas.Count) {
                }*/
                if (txtNumDeposito.Text.Trim().Equals(""))
                {
                    epError.SetError(txtNumDeposito, "Favor digitar el número de depósito");
                    conteoerrores += 1;
                    return false;
                }
                if (txtCtaReferencia.Text.Trim().Equals(""))
                {
                    epError.SetError(txtCtaReferencia, "Favor digitar el número de referencia");
                    conteoerrores += 1;
                    return false;
                }
                if (txtCedula.Text.Trim().Equals(""))
                {
                    epError.SetError(txtCedula, "Favor digitar el número de cédula");
                    conteoerrores += 1;
                    return false;
                }
                if (cboMoneda.SelectedIndex == -1)
                {
                    epError.SetError(cboMoneda, "Favor seleccionar una opción de moneda");
                    conteoerrores += 1;
                    return false;
                }
                if (cboTipoMesaNiquel.SelectedIndex == -1)
                {
                    epError.SetError(cboTipoMesaNiquel, "Favor seleccionar una opción de tipo de mesa niquel");
                    return false;
                }
                if (nudMontoDeclarado.Value == 0)
                {
                    epError.SetError(nudMontoDeclarado, "El monto indicado no es válido.");
                    conteoerrores += 1;
                    return false;
                }
                /*if (nudMontoNiquel.Value == 0)
                {
                    epError.SetError(nudMontoNiquel, "El monto indicado no es válido.");
                    return false;
                }*/
                if (txtCodigoTransaccion.Text.Trim().Equals(""))
                {
                    epError.SetError(txtCodigoTransaccion, "Favor digitar el código de transacción");
                    conteoerrores += 1;
                    return false;
                }
                if (txtMontoContado.Text.Trim().Equals("0"))
                {
                    epError.SetError(txtMontoContado, "Falta la definición del valor del monto contado");
                    conteoerrores += 1;
                    return false;
                }
                if ((epError.GetError(txtCtaReferencia).Equals("La cuenta referencia no pertenece al Cliente y Punto de Venta asociado") == true) || (epError.GetError(txtCtaReferencia).Equals("La cuenta referencia no corresponde a la moneda seleccionada o al Cliente y Punto de Venta asociado") == true))
                { //La cuenta referencia no corresponde a la moneda seleccionada o al Cliente y Punto de Venta asociado
                    conteoerrores += 1;
                    return false;
                }
                /*if (nuderror > 0)
                {
                    epError.SetError(txtDiferencia, "No se puede procesar debido a que los montos por denominaciones no están correctos todos.");
                    conteoerrores += 1;0
                    return false;
                }*/
                if (revisardenominacionesbillete() == false)
                {
                    epError.SetError(txtDiferencia, "No se puede procesar debido a que los montos por denominaciones no están correctos todos.");
                    conteoerrores += 1;
                    return false;
                }
                Decimal diferencia = Convert.ToDecimal(txtDiferencia.Text);
                if (cboMonedaDeclarada.SelectedItem.Equals("Colones"))
                {
                    if ((diferencia > 500) || (diferencia < -500))
                    //if (!txtDiferencia.Text.Equals("0"))
                    {
                        epError.SetError(txtDiferencia, "Existe una diferencia entre el monto declarado y el monto contado");
                        conteoerrores += 1;
                        return false;
                    }
                }
                else
                {
                    if ((diferencia >= 1) || (diferencia <= -1))
                    //if (!txtDiferencia.Text.Equals("0"))
                    {
                        epError.SetError(txtDiferencia, "Existe una diferencia entre el monto declarado y el monto contado");
                        conteoerrores += 1;
                        return false;
                    }
                }                
                return true;
                //return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error validacampos: " + ex.Message);
                return false;
            }
        }

        private void txtNumero_Leave(object sender, EventArgs e)
        {
            try
            {
                epError.SetError(txtNumero, "");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error txtnumero_leave: " + ex.Message);
            }            
        }

        private void cambiarinfotextodeposito()
        {
            try
            {
                txtNumDeposito.Text = numdeposito;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error cambiarinfotextodeposito: " + ex.Message);
            }            
        }

        private void txtNumDeposito_TextChanged(object sender, EventArgs e) //Cambios GZH 31/10/2017
        {
            long number;
            bool result = false;
            try
            {
                if (!txtNumDeposito.Text.Trim().Equals(""))
                {
                    result = Int64.TryParse(txtNumDeposito.Text.Trim(), out number);
                    if (!result)
                    {
                        txtNumDeposito.Text = "";
                    }
                }
                txtNumDeposito.Text = txtNumDeposito.Text.Trim();
                conteoerrores = 0;
                epError.SetError(txtNumDeposito, "");
            }
            catch (Excepcion ex)
            {
                MessageBox.Show("Error txtnumdeposito_textchanged: " + ex.Message);
            }            
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

        private void txtCtaReferencia_TextChanged(object sender, EventArgs e)
        {
            long number;
            bool result = false;
            try
            {
                if (!txtCtaReferencia.Text.Trim().Equals(""))
                {
                    result = Int64.TryParse(txtCtaReferencia.Text.Trim(), out number);
                    if (!result)
                    {
                        txtCtaReferencia.Text = "";
                    }
                }
                txtCtaReferencia.Text = txtCtaReferencia.Text.Trim();                
                epError.SetError(txtCtaReferencia, "");
                conteoerrores = 0;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error txtctareferencia_textchanged: " + ex.Message);
            }            
        }

        private void txtCedula_TextChanged(object sender, EventArgs e) //Cambios GZH 31/10/2017
        {
            long number;
            bool result = false;
            try
            {
                if (!txtCedula.Text.Trim().Equals(""))
                {
                    result = Int64.TryParse(txtCedula.Text.Trim(), out number);
                    if (!result)
                    {
                        txtCedula.Text = "";
                    }
                }
                txtCedula.Text = txtCedula.Text.Trim();                   
                epError.SetError(txtCedula, "");
                conteoerrores = 0;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error txtcedula_textchanged: " + ex.Message);
            }            
        }

        private void cboMonedaDeclarada_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!txtCtaReferencia.Text.Trim().Equals(""))
                {
                    long n;
                    bool isNumeric = long.TryParse(txtCtaReferencia.Text, out n);
                    if (isNumeric)
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
                        archivo.writetext("Ingreso Depósito, Cliente en _manifiesto cboMonedaDeclarada_SelectedIndexChanged: " + _manifiesto.Cliente.Nombre);
                        archivo.writetext("Ingreso Depósito, Punto de venta en _manifiesto cboMonedaDeclarada_SelectedIndexChanged: " + _manifiesto.PuntoVenta.Nombre);
                    }
                    else
                    {
                        epError.SetError(txtCtaReferencia, "El formato del número de cuenta es incorrecto");
                    }                    
                }
                if (cboMonedaDeclarada.SelectedIndex != cboMoneda.SelectedIndex)
                {
                    epError.SetError(cboMoneda, "La moneda declarada es diferente a la moneda seleccionada");
                }
                else
                {
                    epError.SetError(cboMoneda, "");
                    conteoerrores = 0;
                }
                foreach (Control control in gbcolones.Controls)
                {
                    NumericUpDown numControls = control as NumericUpDown;
                    if (numControls != null)
                    {
                        numControls.Value = 0;
                        numControls.Tag = numControls.Value;
                        epError.SetError(numControls, "");
                    }
                }
                foreach (Control control in gbdolares.Controls)
                {
                    NumericUpDown numControls = control as NumericUpDown;
                    if (numControls != null)
                    {
                        numControls.Value = 0;
                        numControls.Tag = numControls.Value;
                        epError.SetError(numControls, "");
                    }
                }
                foreach (Control control in gbeuros.Controls)
                {
                    NumericUpDown numControls = control as NumericUpDown;
                    if (numControls != null)
                    {
                        numControls.Value = 0;
                        numControls.Tag = numControls.Value;
                        epError.SetError(numControls, "");
                    }
                }
                datos = "";
            }
            catch (Excepcion ex)
            {
                MessageBox.Show("Error cbomonedadeclarada: " + ex.Message);
                datos = "";
            }
        }

        private void cboTipoMesaNiquel_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                epError.SetError(cboTipoMesaNiquel, "");
                conteoerrores = 0;
                if (cboTipoMesaNiquel.SelectedItem == "Mesa Níquel")
                {
                    nudMontoNiquel.ReadOnly = true;
                }
                else
                {
                    nudMontoNiquel.ReadOnly = false;
                }
            }    
            catch (Excepcion ex)
            {
                MessageBox.Show("cbotipomesaniquel_selectedindexchanged error: " + ex.Message);
            }
        }

        private void txtMontoContado_TextChanged(object sender, EventArgs e)
        {
            try
            {
                epError.SetError(txtMontoContado, "");
                conteoerrores = 0;
            }
            catch(Exception ex)
            {
                MessageBox.Show("txtmontocontado_textchanged error: " + ex.Message);
            }            
        }

        private void txtCodigoTransaccion_TextChanged(object sender, EventArgs e) //Camvio GZH 31/10/2017
        {
            long number;
            bool result = false;
            try
            {
                if (!txtCodigoTransaccion.Text.Trim().Equals(""))
                {
                    result = Int64.TryParse(txtCodigoTransaccion.Text.Trim(), out number);
                    if (!result)
                    {
                        txtCodigoTransaccion.Text = "";
                    }
                }
                txtCodigoTransaccion.Text = txtCodigoTransaccion.Text.Trim();
                epError.SetError(txtCodigoTransaccion, "");
                conteoerrores = 0;
                /*switch (txtCodigoTransaccion.Text)
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
                    case "8003":
                        cboMoneda.SelectedIndex = 0;
                        cboMonedaDeclarada.SelectedIndex = 0;
                        break;
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
                        //no puedo escribir manualmente en txt xq se borra, hay que hacer ctrl v
                        txtCodigoTransaccion.Text = "";
                        break;
                }*/
            }
            catch (Excepcion ex)
            {
                MessageBox.Show("txtcodigotransaccion_textchanged error: " + ex.Message);
            }            
        }

        private void nudcincoeur_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if ((VerificaMonto == true) && (cancelact == 0))
                {

                    decimal mValuePre = (decimal)nud5EUR.Tag;
                    if (mValuePre > nud5EUR.Value)
                    {
                        //epError.SetError(nud5EUR, "No se puede ingresar ese monto, el valor permitido es igual o mayor a " + nud5EUR.Tag);
                        //Error = true;
                        //nuderror += 1;
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
            catch(Exception ex)
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
                        //Error = true;
                        //nuderror += 1;
                        //epError.SetError(nud100EUR, "No se puede ingresar ese monto, el valor permitido es igual o mayor a " + nud100EUR.Tag);
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
            catch(Exception ex)
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
                        //Error = true;
                        //nuderror += 1;
                        //epError.SetError(nud10EUR, "No se puede ingresar ese monto, el valor permitido es igual o mayor a " + nud10EUR.Tag);
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
            catch(Exception ex)
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
                        //Error = true;
                        //nuderror += 1;
                        //epError.SetError(nud200EUR, "No se puede ingresar ese monto, el valor permitido es igual o mayor a " + nud200EUR.Tag);
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
            catch(Exception ex)
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
                        //Error = true;
                        //nuderror += 1;
                        //epError.SetError(nud20EUR, "No se puede ingresar ese monto, el valor permitido es igual o mayor a " + nud20EUR.Tag);
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
            catch(Exception ex)
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
                        //Error = true;
                        //nuderror += 1;
                        //epError.SetError(nud500EUR, "No se puede ingresar ese monto, el valor permitido es igual o mayor a " + nud500EUR.Tag);
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
            catch(Exception ex)
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
                        //Error = true;
                        //nuderror += 1;
                        //epError.SetError(nud50EUR, "No se puede ingresar ese monto, el valor permitido es igual o mayor a " + nud50EUR.Tag);
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
            catch(Exception ex)
            {
                MessageBox.Show("nudcincuentaeur_valuechanged error: " + ex.Message);
            }            
        }

        private void nudunusd_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if ((VerificaMonto == true) && (cancelact == 0))
                {
                    decimal mValuePre = (decimal)nud1USD.Tag;
                    if (mValuePre > nud1USD.Value)
                    {
                        //Error = true;
                        //nuderror += 1;
                        //epError.SetError(nud1USD, "No se puede ingresar ese monto, el valor permitido es igual o mayor a " + nud1USD.Tag);
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
            catch(Exception ex)
            {
                MessageBox.Show("nudunusd_valuechanged error: " + ex.Message);
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
                        //Error = true;
                        //nuderror += 1;
                        //epError.SetError(nud20USD, "No se puede ingresar ese monto, el valor permitido es igual o mayor a " + nud20USD.Tag);
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
            catch(Exception ex)
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
                        //Error = true;
                        //nuderror += 1;
                        //epError.SetError(nud5USD, "No se puede ingresar ese monto, el valor permitido es igual o mayor a " + nud5USD.Tag);
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
            catch(Exception ex)
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
                        //Error = true;
                        //nuderror += 1;
                        //epError.SetError(nud50USD, "No se puede ingresar ese monto, el valor permitido es igual o mayor a " + nud50USD.Tag);
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
                        //Error = true;
                        //nuderror += 1;
                        //epError.SetError(nud10USD, "No se puede ingresar ese monto, el valor permitido es igual o mayor a " + nud10USD.Tag);
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
                        //Error = true;
                        //epError.SetError(nud100USD, "No se puede ingresar ese monto, el valor permitido es igual o mayor a " + nud100USD.Tag);
                        //nuderror += 1;
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
            try
            {
                if ((VerificaMonto == true) && (cancelact == 0))
                {
                    decimal mValuePre = (decimal)nud50000CRC.Tag;
                    if (mValuePre > nud50000CRC.Value)
                    {
                        //Error = true;
                        //epError.SetError(nud50000CRC, "No se puede ingresar ese monto, el valor permitido es igual o mayor a " + nud50000CRC.Tag);
                        //nuderror += 1;
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
            catch (Exception ex)
            {
                MessageBox.Show("cincuentamil_valuechanged error: " + ex.Message);
            }
        }

        private void nudCincomil_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if ((VerificaMonto == true) && (cancelact == 0))
                {
                    decimal mValuePre = (decimal)nud5000CRC.Tag;
                    if (mValuePre > nud5000CRC.Value)
                    {
                        //Error = true;
                        //epError.SetError(nud5000CRC, "No se puede ingresar ese monto, el valor permitido es igual o mayor a " + nud5000CRC.Tag);
                        //nuderror += 1;
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
            catch (Exception ex)
            {
                MessageBox.Show("cincomil_valuechanged error: " + ex.Message);
            }
        }

        private void nudVeintemil_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if ((VerificaMonto == true) && (cancelact == 0))
                {
                    decimal mValuePre = (decimal)nud20000CRC.Tag;
                    if (mValuePre > nud20000CRC.Value)
                    {
                        //Error = true;
                        //epError.SetError(nud20000CRC, "No se puede ingresar ese monto, el valor permitido es igual o mayor a " + nud20000CRC.Tag);
                        //nuderror += 1;
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
            catch (Exception ex)
            {
                MessageBox.Show("nudveintemil_valuechanged error: " + ex.Message);
            }
        }

        private void nudDosmil_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if ((VerificaMonto == true) && (cancelact == 0))
                {
                    decimal mValuePre = (decimal)nud2000CRC.Tag;
                    if (mValuePre > nud2000CRC.Value)
                    {
                        //Error = true;
                        //nuderror += 1;
                        //epError.SetError(nud2000CRC, "No se puede ingresar ese monto, el valor permitido es igual o mayor a " + nud2000CRC.Tag);
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
            catch (Exception ex)
            {
                MessageBox.Show("nuddosmil_valuechanged error: " + ex.Message);
            }
        }

        private void nudDiezmil_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if ((VerificaMonto == true) && (cancelact == 0))
                {
                    decimal mValuePre = (decimal)nud10000CRC.Tag;
                    if (mValuePre > nud10000CRC.Value)
                    {
                        //Error = true;
                        //nuderror += 1;
                        //epError.SetError(nud10000CRC, "No se puede ingresar ese monto, el valor permitido es igual o mayor a " + nud10000CRC.Tag);
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
            catch (Exception ex)
            {
                MessageBox.Show("nuddiezmil_valuechanged error: " + ex.Message);
            }
        }

        private void nudMil_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if ((VerificaMonto == true) && (cancelact == 0))
                {
                    decimal mValuePre = (decimal)nud1000CRC.Tag;
                    if (mValuePre > nud1000CRC.Value)
                    {
                        //Error = true;
                        //nuderror += 1;
                        //epError.SetError(nud1000CRC, "No se puede ingresar ese monto, el valor permitido es igual o mayor a " + nud1000CRC.Tag);
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
            catch (Exception ex)
            {
                MessageBox.Show("nudmil_valuechanged error: " + ex.Message);
            }
        }

        /*private void btnextraerinfo_Click(object sender, EventArgs e)
        {
            //ExtraeInformacionMagner();
        }*/

        private void btnCompraVta_Click(object sender, EventArgs e)
        {
            try
            {
                Monedas _monedadeposito = (Monedas)cboMonedaDeclarada.SelectedIndex;
                frmIngresoCompraVenta formulario = new frmIngresoCompraVenta(ref _monedadeposito, _deposito);
                formulario.ShowDialog(this);
                datos = "";
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
                datos = "";
            }
        }


        private void btnCancelarTula_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        private void btnIngresoCheques_Click(object sender, EventArgs e)
        {
            try
            {  
                BindingList<ChequeDeposito> listachequedeposito = new BindingList<ChequeDeposito>();
                listachequedeposito = _deposito.ChequeDeposito;
                Monedas _monedadeposito = (Monedas)cboMonedaDeclarada.SelectedIndex;
                frmIngresoChequesCE formulario = new frmIngresoChequesCE(ref listachequedeposito, ref _colaborador, ref _monedadeposito);
                formulario.ShowDialog(this);
                datos = "";
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
                datos = "";
            }
        }

        private void btnmodificar_Click(object sender, EventArgs e)
        {
            try
            {
                frmValidacionCoordinadorCE formulario = new frmValidacionCoordinadorCE(2, _colaborador);
                formulario.ShowDialog();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        private void btnVerificar_Click(object sender, EventArgs e)
        {
            try
            {
                datos = "";
                byte tularep = 0;
                if (txtNumero.Text != "")
                {
                    _tula.Codigo = txtNumero.Text;
                    archivo.writetext("Inicia botón verificar tula ");
                    archivo.writetext("Tula " + _tula.Codigo.ToString());
                    archivo.writetext("Manifiesto " + _manifiesto.ToString());
                    archivo.writetext("Ingreso Depósito, Cliente en _manifiesto btnVerificar_Click: " + _manifiesto.Cliente.Nombre);
                    archivo.writetext("Ingreso Depósito, Punto de venta en _manifiesto btnVerificar_Click: " + _manifiesto.PuntoVenta.Nombre);
                    if (_atencion.verificarTulaManifiesto(ref _tula, ref _manifiesto) == false)
                    {
                        epError.SetError(txtNumero, "La tula indicada no existe en el sistema o no está asociada con el manifiesto correcto.");
                    }
                    else
                    {
                        if (_manifiesto.Tulas.Count > 0)
                        {
                            foreach (Tula tula in _manifiesto.Tulas)
                            {
                                if (tula.Codigo.ToUpper().Equals(txtNumero.Text.ToUpper()))
                                {
                                    if (_mantenimiento.VerificaTulasManifiesto(ref _manifiesto))
                                    {
                                        chkcierremanifiesto = 1;
                                        archivo.writetext("VerificaTulasManifiesto correcto");
                                        /*btnProcesar_Click(sender, e);
                                        if (_manifiesto == null)
                                        {
                                            return;
                                        }*/
                                    }
                                    else
                                    {
                                        epError.SetError(txtNumero, "El código de Tula indicado ya fue ingresado, favor registre otra tula.");
                                        archivo.writetext("El código de Tula indicado ya fue ingresado, favor registre otra tula.");
                                        tularep = 1;                                        
                                    }
                                    break;
                                }
                            }
                        }
                       if (tularep == 0)
                       {
                           if (idtulapendiente == 0)
                           {
                                _mantenimiento.agregarPendienteProcesamientoBajoVolumenTula(ref _manifiesto, ref _tula);
                                archivo.writetext("agregarPendienteProcesamientoBajoVolumenTula: nueva tula pendiente " + _tula.Codigo.ToString());
                                archivo.writetext("Ingreso Depósito, Cliente en _manifiesto agregarPendienteProcesamientoBajoVolumenTula: " + _manifiesto.Cliente.Nombre);
                                archivo.writetext("Ingreso Depósito, Punto de venta en _manifiesto agregarPendienteProcesamientoBajoVolumenTula: " + _manifiesto.PuntoVenta.Nombre);

                            } 
                           else
                           {                                
                                BindingList<ProcesamientoBajoVolumenDeposito> listadeposito = _mantenimiento.listarProcesamientoBajoVolumenDeposito(_manifiesto);
                                _tula = new Tula("");
                                _tula.Codigo = txtNumero.Text;
                                _tula.ID = idtulapendiente;
                                archivo.writetext("trabajando tula pendiente " + _tula.Codigo.ToString());
                                archivo.writetext("Ingreso Depósito, Cliente en _manifiesto listarProcesamientoBajoVolumenDeposito: " + _manifiesto.Cliente.Nombre);
                                archivo.writetext("Ingreso Depósito, Punto de venta en _manifiesto listarProcesamientoBajoVolumenDeposito: " + _manifiesto.PuntoVenta.Nombre);
                                foreach (ProcesamientoBajoVolumenDeposito procesamientodeposito in listadeposito)
                                {
                                    _deposito = new Deposito(procesamientodeposito.DB_ID, procesamientodeposito.ID, procesamientodeposito.MontoContado, 0, procesamientodeposito.Moneda,
                                procesamientodeposito.CodigoVD, procesamientodeposito.CodigoTransaccion, procesamientodeposito.Cuenta, procesamientodeposito.Cedula, procesamientodeposito.TipoMesa,
                                procesamientodeposito.MontoNiquel, procesamientodeposito.MontoDeclarado, procesamientodeposito.Diferencia, procesamientodeposito.NumeroDeposito,
                                procesamientodeposito.Depositante);
                                    archivo.writetext("nuevo deposito " + _deposito.ToString());
                                    if (txtNumero.Text.Equals(procesamientodeposito.Tula.ToString()))
                                    {       
                                        if (_tula.ID == 0)
                                        {
                                            _tula = procesamientodeposito.Tula;
                                            archivo.writetext("asocio tula de procesamientodeposito " + procesamientodeposito.Tula.ToString());
                                        }                                        
                                        _tula.agregarDeposito(_deposito);
                                        archivo.writetext("agrega deposito a tula " + _deposito.ToString());
                                    }                                    
                                }
                            }


                           cboTipoMesaNiquel.Items.Clear();
                           foreach (Perfil perfil in _colaborador.Perfiles)
                           {
                               if (perfil.ID == 73)
                               {
                                   cboTipoMesaNiquel.Items.Add("Mesa Níquel");
                                   break;
                               }
                           }
                           if (cboTipoMesaNiquel.Items.Count == 0)
                           {
                               cboTipoMesaNiquel.Items.Add("En Mesa");
                               cboTipoMesaNiquel.Items.Add("Cajero Níquel");
                           }
                           cboTipoMesaNiquel.SelectedIndex = 0;

                           txtNumero.Enabled = false;
                           //_tula = new Tula(txtNumero.Text);
                           _deposito = new Deposito(0);                           
                           epError.SetError(txtNumero, "");
                           btnVerificar.Enabled = false;
                           btnCancelarTula.Enabled = false;
                           //btnmodificar.Enabled = false;
                           gbDatosDeposito.Enabled = true;
                           if (port != null)
                           {
                               if (port.IsOpen == false)  port.Open();
                               btnextraerinfo.Enabled = true;
                               lbldestadolector.BackColor = Color.Green;
                               //epError.SetError(btnextraerinfo, "");
                           }
                           else
                           {
                               btnextraerinfo.Enabled = false;
                               lbldestadolector.BackColor = Color.Red;
                               //epError.SetError(btnextraerinfo, "El puerto del equipo Magner no se encuentra disponible, favor verificar que se encuentra conectado");
                           }
                           txtCodigoVD.Focus();
                       }                       
                    }                    
                }
                else
                {
                    epError.SetError(txtNumero, "Favor ingrese el número de Tula");
                }
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        private BindingList<MontoDeposito> añadirlistamontosdenominacion()
        {
            BindingList<MontoDeposito> listamondeposito = new BindingList<MontoDeposito>();
            MontoDeposito mondeposito = null;
            String nomControlsnum;
            BindingList<Denominacion> listadenominacion = _mantenimiento.listarDenominacionesxMonedas((byte)(Monedas)cboMonedaDeclarada.SelectedIndex);
            try
            {
                foreach (Denominacion denominacion in listadenominacion)
                {
                    if ((denominacion.Moneda == Monedas.Colones) && (denominacion.EsMoneda == false))
                    {
                        foreach (Control control in gbcolones.Controls)
                        {
                            NumericUpDown numControls = control as NumericUpDown;
                            if (numControls != null)
                            {
                                nomControlsnum = GetNumbers(numControls.Name);
                                if (nomControlsnum.Equals(Convert.ToString(Convert.ToInt64(denominacion.Valor))) && (numControls.Name.Contains("CRC")) && (numControls.Value > 0))
                                {
                                    mondeposito = new MontoDeposito();
                                    mondeposito.Denominacion = denominacion;
                                    mondeposito.Cantidad_asignada = numControls.Value;
                                    listamondeposito.Add(mondeposito);
                                    /*if (denominacion.Valor < 5000)
                                    {
                                        _procesamientobajovolumen.MontoBD += numControls.Value;
                                    }
                                    else
                                    {
                                        _procesamientobajovolumen.MontoAD += numControls.Value;
                                    }
                                    _procesamientobajovolumen.MontoCOL += numControls.Value;
                                    if ((_procesamientobajovolumen.MontoAD > _limiteefectivo.LimiteAD) && (_procesamientobajovolumen.ExcedelimiteAD == false))
                                    {
                                        _procesamientobajovolumen.Excedelimite = true;
                                        _procesamientobajovolumen.ExcedelimiteAD = true;
                                        MessageBox.Show("Se ha sobrepasado el límite de efectivo de alta denominación. El sistema le requerirá generar un depósito de alto volumen al finalizar el manifiesto.");
                                    }
                                    if ((_procesamientobajovolumen.MontoBD > _limiteefectivo.LimiteBD) && (_procesamientobajovolumen.ExcedelimiteBD == false))
                                    {
                                        _procesamientobajovolumen.Excedelimite = true;
                                        _procesamientobajovolumen.ExcedelimiteBD = true;
                                        MessageBox.Show("Se ha sobrepasado el límite de efectivo de baja denominación. El sistema le requerirá generar un depósito de alto volumen al finalizar el manifiesto.");
                                    }
                                    if ((_procesamientobajovolumen.MontoCOL > _limiteefectivo.LimiteCOL) && (_procesamientobajovolumen.ExcedelimiteCOL == false))
                                    {
                                        _procesamientobajovolumen.Excedelimite = true;
                                        _procesamientobajovolumen.ExcedelimiteCOL = true;
                                        MessageBox.Show("Se ha sobrepasado el límite de efectivo de total colones. El sistema le requerirá generar un depósito de alto volumen al finalizar el manifiesto.");
                                    }*/
                                }
                            }
                        }
                    }
                    else if (denominacion.Moneda == Monedas.Dolares)
                    {

                        foreach (Control control in gbdolares.Controls)
                        {
                            NumericUpDown numControls = control as NumericUpDown;
                            if (numControls != null)
                            {
                                nomControlsnum = GetNumbers(numControls.Name);
                                if (nomControlsnum.Equals(Convert.ToString(Convert.ToInt64(denominacion.Valor))) && (numControls.Name.Contains("USD")) && (numControls.Value > 0))
                                {
                                    mondeposito = new MontoDeposito();
                                    mondeposito.Denominacion = denominacion;
                                    mondeposito.Cantidad_asignada = numControls.Value;
                                    listamondeposito.Add(mondeposito);
                                    /*_procesamientobajovolumen.MontoDOL += numControls.Value;
                                    if ((_procesamientobajovolumen.MontoDOL > _limiteefectivo.LimiteDOL) && (_procesamientobajovolumen.ExcedelimiteDOL == false))
                                    {
                                        _procesamientobajovolumen.ExcedelimiteDOL = true;
                                        _procesamientobajovolumen.Excedelimite = true;
                                        MessageBox.Show("Se ha sobrepasado el límite de efectivo de dólares. El sistema le requerirá generar un depósito de alto volumen al finalizar el manifiesto.");
                                    }*/
                                }
                            }
                        }
                    }
                    else if (denominacion.Moneda == Monedas.Euros)
                    {
                        foreach (Control control in gbeuros.Controls)
                        {
                            NumericUpDown numControls = control as NumericUpDown;
                            if (numControls != null)
                            {
                                nomControlsnum = GetNumbers(numControls.Name);
                                if (nomControlsnum.Equals(Convert.ToString(Convert.ToInt64(denominacion.Valor))) && (numControls.Name.Contains("EUR")) && (numControls.Value > 0))
                                {
                                    mondeposito = new MontoDeposito();
                                    mondeposito.Denominacion = denominacion;
                                    mondeposito.Cantidad_asignada = numControls.Value;
                                    listamondeposito.Add(mondeposito);
                                    /*_procesamientobajovolumen.MontoEUR += numControls.Value;
                                    if ((_procesamientobajovolumen.MontoEUR > _limiteefectivo.LimiteEUR) && (_procesamientobajovolumen.ExcedelimiteDOL == false))
                                    {
                                        _procesamientobajovolumen.ExcedelimiteEUR = true;
                                        _procesamientobajovolumen.Excedelimite = true;
                                        MessageBox.Show("Se ha sobrepasado el límite de efectivo de euros. El sistema le requerirá generar un depósito de alto volumen al finalizar el manifiesto.");
                                    }*/
                                }
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("añadirlistamontosdenominacion error: " + ex.Message);
            }            
            return listamondeposito;
        }

        private void procesardatosprocesamientobajovolumen() //Cambios GZH 13092017
        {
            try
            {
                /*if (_procesamientobajovolumen.ID == 0)
                {
                    archivo.writetext("Agrega registro procesamientobajovolumen.");
                    _mantenimiento.agregarProcesamientoBajoVolumen(ref _procesamientobajovolumen);
                }
                else
                {
                    archivo.writetext("Actualiza registro procesamientobajovolumen.");
                    _mantenimiento.actualizarProcesamientoBajoVolumen(ref _procesamientobajovolumen);
                }*/
                foreach (ProcesamientoBajoVolumenManifiesto manifiesto in _procesamientobajovolumen.ListaManifiestos)
                {
                    foreach (Tula tula in manifiesto.Tulas)
                    {
                        archivo.writetext("Revisa tulas: _tula: " + _tula.ID.ToString() + ", tula: " + tula.ID.ToString() + ", conteo depositos tula: " + tula.Deposito.Count().ToString());
                        if (_tula.ID == tula.ID)
                        {
                            if (_tula.ID != 0)
                            {
                                foreach (Deposito deposito in _tula.Deposito)
                                {
                                    archivo.writetext("Deposito por añadir: " + deposito.NumeroDeposito.ToString() + ",declarado: " + deposito.MontoDeclarado.ToString()
                                        + ", monto: " + deposito.Monto.ToString());
                                    if (deposito.ID == 0)
                                    {
                                        if (_procesamientobajovolumen.ID == 0)
                                        {
                                            archivo.writetext("Agrega registro procesamientobajovolumen.");
                                            _mantenimiento.agregarProcesamientoBajoVolumen(ref _procesamientobajovolumen);
                                        }
                                        Deposito depositoinc = deposito;
                                        //manifiesto.Monto += deposito.MontoDeclarado;
                                        Monedas _moneda = _deposito.Moneda;
                                        _mantenimiento.agregarProcesamientoBajoVolumenDeposito(ref _procesamientobajovolumen, ref _manifiesto, ref _tula, ref _deposito, ref _moneda, _coordinador);
                                        archivo.writetext("Ingreso Depósito, Cliente en _manifiesto agregarProcesamientoBajoVolumenDeposito: " + _manifiesto.Cliente.Nombre);
                                        archivo.writetext("Ingreso Depósito, Punto de venta en _manifiesto agregarProcesamientoBajoVolumenDeposito: " + _manifiesto.PuntoVenta.Nombre);
                                        ListViewItem item = new ListViewItem();
                                        item.SubItems[0].Text = _deposito.NumeroDeposito;
                                        item.SubItems.Add(_deposito.Monto.ToString());
                                        lstDepósitos.Items.Add(item);
                                        archivo.writetext("Agrega deposito " + _deposito.ID.ToString());
                                        ConteoBillete conteobillete = null;
                                        switch (_moneda)
                                        {
                                            case Monedas.Colones:
                                                conteobillete = new ConteoBillete(c50000: nud50000CRC.Value, c20000: nud20000CRC.Value, c10000: nud10000CRC.Value, c5000: nud5000CRC.Value, c2000: nud2000CRC.Value,
                                                    c1000: nud1000CRC.Value, moneda: _moneda, idpbv: _deposito.ID);
                                                _procesamientobajovolumen.MontoBD += (nud2000CRC.Value + nud1000CRC.Value);
                                                _procesamientobajovolumen.MontoAD += (nud50000CRC.Value + nud20000CRC.Value + nud10000CRC.Value + nud5000CRC.Value);                                                
                                                _procesamientobajovolumen.MontoCOL += (nud50000CRC.Value + nud20000CRC.Value + nud10000CRC.Value + nud5000CRC.Value + nud2000CRC.Value + nud1000CRC.Value); // + deposito.CompraVenta.MontoBillete
                                                if (deposito.CompraVenta != null)
                                                {
                                                    if ((deposito.CompraVenta.TipoTransaccion == TipoTransaccion.Venta) || (deposito.CompraVenta.TipoTransaccion == TipoTransaccion.VentaEuros))
                                                        _procesamientobajovolumen.MontoCOL += deposito.CompraVenta.MontoBillete;
                                                    if (deposito.CompraVenta.TipoTransaccion == TipoTransaccion.Compra)
                                                        _procesamientobajovolumen.MontoDOL += deposito.CompraVenta.MontoBillete;
                                                    if (deposito.CompraVenta.TipoTransaccion == TipoTransaccion.CompraEuros)
                                                        _procesamientobajovolumen.MontoEUR += deposito.CompraVenta.MontoBillete;
                                                }                                                    
                                                if ((_procesamientobajovolumen.MontoCOL > _limiteefectivo.LimiteCOL) && (_procesamientobajovolumen.ExcedelimiteCOL == false))
                                                {
                                                    _procesamientobajovolumen.Excedelimite = true;
                                                    _procesamientobajovolumen.ExcedelimiteCOL = true;
                                                    MessageBox.Show("Se ha sobrepasado el límite de efectivo de total colones. El sistema le requerirá generar un depósito de alto volumen al finalizar el manifiesto.");
                                                }
                                                else
                                                {
                                                    if ((_procesamientobajovolumen.MontoAD > _limiteefectivo.LimiteAD) && (_procesamientobajovolumen.ExcedelimiteAD == false))
                                                    {
                                                        _procesamientobajovolumen.Excedelimite = true;
                                                        _procesamientobajovolumen.ExcedelimiteAD = true;
                                                        MessageBox.Show("Se ha sobrepasado el límite de efectivo de alta denominación. El sistema le requerirá generar un depósito de alto volumen al finalizar el manifiesto.");
                                                    }
                                                    if ((_procesamientobajovolumen.MontoBD > _limiteefectivo.LimiteBD) && (_procesamientobajovolumen.ExcedelimiteBD == false))
                                                    {
                                                        _procesamientobajovolumen.Excedelimite = true;
                                                        _procesamientobajovolumen.ExcedelimiteBD = true;
                                                        MessageBox.Show("Se ha sobrepasado el límite de efectivo de baja denominación. El sistema le requerirá generar un depósito de alto volumen al finalizar el manifiesto.");
                                                    }
                                                }
                                                break;
                                            case Monedas.Dolares:
                                                conteobillete = new ConteoBillete(u100: nud100USD.Value, u50: nud50USD.Value, u20: nud20USD.Value, u10: nud10USD.Value, u5: nud5USD.Value, u1: nud1USD.Value,
                                                    moneda: _moneda, idpbv: _deposito.ID);
                                                _procesamientobajovolumen.MontoDOL += (nud1USD.Value + nud5USD.Value + nud10USD.Value + nud20USD.Value + nud50USD.Value + nud100USD.Value);
                                                if (deposito.CompraVenta != null)
                                                {
                                                    if (deposito.CompraVenta.TipoTransaccion == TipoTransaccion.Compra)
                                                        _procesamientobajovolumen.MontoDOL += deposito.CompraVenta.MontoBillete;
                                                    if (deposito.CompraVenta.TipoTransaccion == TipoTransaccion.Venta)
                                                        _procesamientobajovolumen.MontoCOL += deposito.CompraVenta.MontoBillete;
                                                }                                                    
                                                if ((_procesamientobajovolumen.MontoDOL > _limiteefectivo.LimiteDOL) && (_procesamientobajovolumen.ExcedelimiteDOL == false))
                                                {
                                                    _procesamientobajovolumen.ExcedelimiteDOL = true;
                                                    _procesamientobajovolumen.Excedelimite = true;
                                                    MessageBox.Show("Se ha sobrepasado el límite de efectivo de dólares. El sistema le requerirá generar un depósito de alto volumen al finalizar el manifiesto.");
                                                }
                                                break;
                                            case Monedas.Euros:
                                                conteobillete = new ConteoBillete(e500: nud500EUR.Value, e200: nud200EUR.Value, e100: nud100EUR.Value, e50: nud50EUR.Value, e20: nud20EUR.Value,
                                                    e10: nud10EUR.Value, e5: nud5EUR.Value, moneda: _moneda, idpbv: _deposito.ID);
                                                _procesamientobajovolumen.MontoEUR += (nud5EUR.Value + nud10EUR.Value + nud20EUR.Value + nud50EUR.Value + nud100EUR.Value + nud200EUR.Value + nud500EUR.Value);
                                                if (deposito.CompraVenta != null)
                                                {
                                                    if (deposito.CompraVenta.TipoTransaccion == TipoTransaccion.CompraEuros)
                                                        _procesamientobajovolumen.MontoEUR += deposito.CompraVenta.MontoBillete;
                                                    if (deposito.CompraVenta.TipoTransaccion == TipoTransaccion.VentaEuros)
                                                        _procesamientobajovolumen.MontoCOL += deposito.CompraVenta.MontoBillete;
                                                }                                                    
                                                if ((_procesamientobajovolumen.MontoEUR > _limiteefectivo.LimiteEUR) && (_procesamientobajovolumen.ExcedelimiteEUR == false))
                                                {
                                                    _procesamientobajovolumen.ExcedelimiteEUR = true;
                                                    _procesamientobajovolumen.Excedelimite = true;
                                                    MessageBox.Show("Se ha sobrepasado el límite de efectivo de euros. El sistema le requerirá generar un depósito de alto volumen al finalizar el manifiesto.");
                                                }
                                                break;
                                        }
                                        _mantenimiento.agregarConteoBilleteBajoVolumenDeposito(ref conteobillete);
                                        if (deposito.CompraVenta != null)
                                        {
                                            CompraVenta _compraventadeposito = deposito.CompraVenta;
                                            _mantenimiento.agregarCompraVentaDeposito(ref _compraventadeposito, ref _deposito);
                                        }
                                        _mantenimiento.actualizarProcesamientoBajoVolumen(ref _procesamientobajovolumen);                                                                                
                                        if (deposito.ChequeDeposito != null)
                                        {
                                            BindingList<ChequeDeposito> _chequedepositos = deposito.ChequeDeposito;
                                            foreach (ChequeDeposito cheque in _chequedepositos)
                                            {
                                                ChequeDeposito _chequedeposito = cheque;
                                                _mantenimiento.agregarChequeDeposito(ref _chequedeposito, ref _deposito);
                                            }
                                        }
                                        if (deposito.BilletesFalsos != null)
                                        {
                                            BindingList<BilleteFalso> _billetesfalsos = deposito.BilletesFalsos;
                                            foreach (BilleteFalso billete in _billetesfalsos)
                                            {
                                                BilleteFalso _billetefalso = billete;
                                                _mantenimiento.agregarBilleteFalsoDeposito(ref _billetefalso, ref _deposito);
                                            }
                                        }
                                        //danilo--
                                        if(_deposito.BilletesFalsos != null){
                                            origendiferenciadeposito = (_deposito.BilletesFalsos.Count > 0) ? Convert.ToByte(2) : origendiferenciadeposito;
                                        }
                                        
                                        
                                        if (deposito.MontoDiferencia != 0 || origendiferenciadeposito==2)
                                        //--
                                        {
                                            DateTime fprocesobajovolumendeposito = _mantenimiento.obtenerProcesamientoBajoVolumenDeposito(deposito.ID);
                                            archivo.writetext("diferencia en el depósito " + deposito.ID.ToString() + ": " + deposito.MontoDiferencia.ToString());

                                            switch (deposito.Moneda)
                                            {
                                                case Monedas.Colones:
                                                    if ((deposito.MontoDiferencia < -500) || (deposito.MontoDiferencia > 500))
                                                    {
                                                        archivo.writetext("Imprimir inconsistencia CRC");
                                                        imprimirInconsistenciaDeposito(_manifiesto.Cliente, _manifiesto, _colaborador, _tula, deposito, fprocesobajovolumendeposito, origendiferenciadeposito);
                                                    }
                                                    break;
                                                case Monedas.Dolares:
                                                    if ((deposito.MontoDiferencia <= -1) || (deposito.MontoDiferencia >= 1))
                                                    {
                                                        archivo.writetext("Imprimir inconsistencia USD");
                                                        imprimirInconsistenciaDeposito(_manifiesto.Cliente, _manifiesto, _colaborador, _tula, deposito, fprocesobajovolumendeposito, origendiferenciadeposito);
                                                    }
                                                    break;
                                                case Monedas.Euros:
                                                    if ((deposito.MontoDiferencia <= -1) || (deposito.MontoDiferencia >= 1))
                                                    {
                                                        archivo.writetext("Imprimir inconsistencia EUR");
                                                        imprimirInconsistenciaDeposito(_manifiesto.Cliente, _manifiesto, _colaborador, _tula, deposito, fprocesobajovolumendeposito, origendiferenciadeposito);
                                                    }
                                                    break;

                                            }
                                            
                                            


                                            /*if ((deposito.MontoDiferencia < -500) || (deposito.MontoDiferencia > 500))
                                            {                                        
                                                imprimirInconsistenciaDeposito(_manifiesto.Cliente, _manifiesto, _colaborador, _tula, deposito, fprocesobajovolumendeposito, origendiferenciadeposito);
                                            }*/
                                            archivo.writetext("Agrega inconsistencia procesamiento bajo volumen");
                                            _mantenimiento.agregarInconsistenciaProcesamientoBajoVolumenDeposito(ref _manifiesto, ref _tula, ref depositoinc, ref _moneda, origendiferenciadeposito, fprocesobajovolumendeposito);
                                            archivo.writetext("Ingreso Depósito, Cliente en _manifiesto agregarInconsistenciaProcesamientoBajoVolumenDeposito: " + _manifiesto.Cliente.Nombre);
                                            archivo.writetext("Ingreso Depósito, Punto de venta en _manifiesto agregarInconsistenciaProcesamientoBajoVolumenDeposito: " + _manifiesto.PuntoVenta.Nombre);
                                        }
                                        string numeroctatemp = _deposito.CuentaReferencia;
                                        if (epError.GetError(txtCtaReferencia).Equals("La cuenta referencia no pertenece al Cliente y Punto de Venta asociado"))
                                        {
                                            _deposito.CuentaReferencia = string.Empty;
                                        }

                                        if ((_deposito.Cedula.Equals(string.Empty)) || (_deposito.CodigoTransaccion.Equals(string.Empty)) || (_deposito.CuentaReferencia.Equals(string.Empty)) ||
                                            (_deposito.NumeroDeposito.Equals(string.Empty)) || (_deposito.MontoDiferencia != 0)) //cambio GZH08092017
                                        {
                                            DateTime fprocesobajovolumendeposito = _mantenimiento.obtenerProcesamientoBajoVolumenDeposito(deposito.ID);
                                            depositoinc.MontoDiferencia = _deposito.MontoDiferencia;
                                            archivo.writetext("Agrega inconsistencia procesamiento bajo volumen depósito");
                                            archivo.writetext("Depositoinc: " + depositoinc.ToString() + ",monto: " + depositoinc.Monto.ToString());
                                            _mantenimiento.agregarInconsistenciaInfoProcesamientoBajoVolumenDeposito(ref depositoinc, ref _moneda, fprocesobajovolumendeposito);
                                            _deposito.CuentaReferencia = numeroctatemp;
                                        }
                                        _procesamientobajovolumen = _mantenimiento.listarProcesamientoBajoVolumenCajero(ref _colaborador);
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Se ha detectado un problema en memoria con la tula actual, favor regresar al menu principal, volver a ingresar para que se reajuste en memoria los depósitos y tulas procesados de este manifiesto.");
                            }                                                       
                        }
                    }
                }
            }
            catch (Excepcion ex)
            {
                MessageBox.Show("procesardatosprocesamientobajovolumen error: " + ex.Message);
            }            
        }

        private void cargarinfodeposito() {
            BindingList<BilleteFalso> infobilletefalso = null;
            BindingList<ChequeDeposito> infocheque = null;
            CompraVenta infocompraventa = null;
            try
            {
                if (_deposito.BilletesFalsos != null)
                    infobilletefalso = _deposito.BilletesFalsos;
                if (_deposito.ChequeDeposito != null)
                    infocheque = _deposito.ChequeDeposito;
                if (_deposito.CompraVenta != null)
                    infocompraventa = _deposito.CompraVenta;
                _deposito = new Deposito(0);
                _deposito.MontoDeposito = this.añadirlistamontosdenominacion();
                _deposito.Cedula = txtCedula.Text;
                _deposito.CodigoTransaccion = txtCodigoTransaccion.Text;
                _deposito.CodigoVD = txtCodigoVD.Text;
                _deposito.CuentaReferencia = txtCtaReferencia.Text;
                _deposito.Moneda = (Monedas)cboMonedaDeclarada.SelectedIndex;
                _deposito.MontoDeclarado = nudMontoDeclarado.Value;
                _deposito.Monto = Convert.ToDecimal(txtMontoContado.Text);
                _deposito.MontoDiferencia = Convert.ToDecimal(txtDiferencia.Text);
                _deposito.MontoNiquel = nudMontoNiquel.Value;
                if ((infocompraventa != null) && (!cboTipoMesaNiquel.SelectedItem.Equals("Mesa Níquel")))
                    _deposito.MontoNiquel += infocompraventa.MontoNiquel;
                _deposito.NumeroDeposito = txtNumDeposito.Text.Trim();
                _deposito.Depositante = pdepositante;
                if (cboTipoMesaNiquel.SelectedIndex != -1)
                {
                    if (cboTipoMesaNiquel.SelectedItem.Equals("Cajero Níquel"))
                    {
                        _deposito.TipomesaNiquel = 2;
                    }
                    if (cboTipoMesaNiquel.SelectedItem.Equals("Mesa Níquel"))
                    {
                        _deposito.TipomesaNiquel = 1;
                    }
                    if (cboTipoMesaNiquel.SelectedItem.Equals("En Mesa"))
                    {
                        _deposito.TipomesaNiquel = 0;
                    }
                }
                _deposito.BilletesFalsos = infobilletefalso;
                _deposito.ChequeDeposito = infocheque;
                _deposito.CompraVenta = infocompraventa;
            }
            catch (Exception ex)
            {
                MessageBox.Show("cargarinfodeposito error: " + ex.Message);
            }
        }

        private int procesadeposito(byte tipodeposito) //cambios GZH 30/10/2017
        {
            try
            {
                cargarinfodeposito();
                int verificadeposito = 0;
                archivo.writetext("Ingreso Depósito, Cliente en _manifiesto procesadeposito: " + _manifiesto.Cliente.Nombre);
                archivo.writetext("Ingreso Depósito, Punto de venta en _manifiesto procesadeposito: " + _manifiesto.PuntoVenta.Nombre);
                if (_manifiesto.Tulas.Count > 0)
                    foreach (Tula ntula in _manifiesto.Tulas)
                    {
                        if (ntula.Deposito.Count > 0)
                            foreach (Deposito ndeposito in ntula.Deposito)
                            {
                                archivo.writetext("Revisión depósito " + _deposito.NumeroDeposito + ", monto: " + _deposito.Monto.ToString());
                                if ((ndeposito.NumeroDeposito == _deposito.NumeroDeposito) && (!_deposito.NumeroDeposito.Equals(string.Empty)))
                                {
                                    verificadeposito = 1;
                                    break;
                                }
                            }
                        if (verificadeposito == 1)
                            break;

                    }
                if (verificadeposito == 0)
                    if (_tula.Deposito.Count > 0)
                    {
                        foreach (Deposito ndeposito in _tula.Deposito)
                        {
                            archivo.writetext("Revisión depósito " + _deposito.NumeroDeposito + ", monto: " + _deposito.Monto.ToString());
                            if ((ndeposito.NumeroDeposito == _deposito.NumeroDeposito) && (!_deposito.NumeroDeposito.Equals(string.Empty)))
                            {
                                verificadeposito = 1;
                                break;
                            }
                        }
                    //limpiardepositos(tipodeposito);
                    //if (port != null) port.Close();
                    }
                if (verificadeposito == 0)
                {
                    /*if (_mantenimiento.verificaNumDeposito(_deposito.NumeroDeposito) == true)
                    {*/
                    archivo.writetext("Agrega depósito a tula");
                    _tula.agregarDeposito(_deposito);
                    if ((_manifiesto.Tulas.Count == 0) || (_manifiesto.Tulas[_manifiesto.Tulas.Count - 1].Codigo.Equals(_tula.Codigo) == false))
                    {
                        _manifiesto.agregarTula(_tula);
                        archivo.writetext("Se añade tula a manifiesto");
                    }
                    if (tipodeposito == 1) _mantenimiento.EliminarPendienteProcesamientoBajoVolumenTula(ref _tula);
                    archivo.writetext("tipodeposito> " + tipodeposito.ToString() + ", si es uno elimina pendienteprocesamientobajovolumentula");
                    archivo.writetext("Ingreso Depósito, Cliente en _manifiesto procesadeposito2: " + _manifiesto.Cliente.Nombre);
                    archivo.writetext("Ingreso Depósito, Punto de venta en _manifiesto procesadeposito2: " + _manifiesto.PuntoVenta.Nombre);
                    //if (tipodeposito == 1) _manifiesto.agregarTula(_tula);
                    _procesamientobajovolumen.Camara = _manifiesto.Camara;
                    _procesamientobajovolumen.ColaboradorAsociado = _colaborador;
                    _procesamientobajovolumen.Fecha_Procesamiento = new DateTime();
                    _procesamientobajovolumen.Manifiesto = _manifiesto;
                    archivo.writetext("Ingreso Depósito, Cliente en _manifiesto procesadeposito3: " + _procesamientobajovolumen.Manifiesto.Cliente.Nombre);
                    archivo.writetext("Ingreso Depósito, Punto de venta en _manifiesto procesadeposito3: " + _procesamientobajovolumen.Manifiesto.PuntoVenta.Nombre);

                    if (_procesamientobajovolumen.ListaManifiestos != null)
                    {
                        archivo.writetext("Lista de manifiestos es diferente de nulo (Procesamientobajovolumen)");
                        if (!_procesamientobajovolumen.Manifiesto.Codigo.Equals(_procesamientobajovolumen.ListaManifiestos[_procesamientobajovolumen.ListaManifiestos.Count - 1].Codigo))
                        {
                            _procesamientobajovolumen.ListaManifiestos.Add(_manifiesto);
                            archivo.writetext("Añade manifiesto a Lista de manifiestos " + _manifiesto.ToString());
                        }
                    }
                    else
                    {
                        _procesamientobajovolumen.ListaManifiestos = new BindingList<ProcesamientoBajoVolumenManifiesto>();
                        _procesamientobajovolumen.ListaManifiestos.Add(_manifiesto);
                    }
                    procesardatosprocesamientobajovolumen();
                    archivo.writetext("procesardatosprocesamientobajovolumen completado.");
                    for (int i = 0; i < _manifiesto.Tulas.Count; i++)
                    {
                        if (_manifiesto.Tulas[i].ID == _tula.ID)
                        {
                            if (_manifiesto.Tulas[i].Deposito.Count != _tula.Deposito.Count)
                            {
                                _manifiesto.Tulas[i] = _tula;
                                archivo.writetext("Asocia tula " + _tula.ToString() + " a manifiesto " + _manifiesto.ToString());
                            }
                        }
                    }
                    //MessageBox.Show("El Procesamiento del depósito se ha realizado satisfactoriamente", "Depósito registrado", MessageBoxButtons.OK);
                    return 1;
                    /*}
                    else
                    {
                        return 0;
                    }*/
                }
                else
                {
                    return 0;
                }
            }
            catch (Excepcion ex)
            {
                MessageBox.Show("procesadeposito error: " + ex.Message);
                return 0;                
            }            
        }

        private void  procesacajeroniquel() {
            try
            {
                BoletaCajeroNiquel boleta = new BoletaCajeroNiquel(cajero: _colaborador.ID, fecha_generacion: new DateTime(), manifiesto: _manifiesto.IDManifiesto, tula: _tula.ID, cuenta: txtCtaReferencia.Text,
                    numerodeposito: _deposito.NumeroDeposito, montoniquel: _deposito.MontoNiquel, montodeposito: _deposito.Monto, procesobajovolumendeposito: _deposito.ID, cliente: _manifiesto.Cliente.Id);
                _mantenimiento.agregarBoletaCajeroNiquel(ref boleta);
                imprimirBoletaCajeroNiquel(_manifiesto.Cliente, _manifiesto, _colaborador, _tula, _deposito, boleta.ID);
                archivo.writetext("Ingreso Depósito, Cliente en _manifiesto procesacajeroniquel(): " + _manifiesto.Cliente.Nombre);
                archivo.writetext("Ingreso Depósito, Punto de venta en _manifiesto procesacajeroniquel(): " + _manifiesto.PuntoVenta.Nombre);

            }
            catch (Excepcion ex)
            {
                MessageBox.Show("procesacajeroniquel error: " + ex.Message);
            }
        }

        private void procesaMesaniquel()
        {
            try
            {
                BoletaMesaEntregaNiquel boleta = new BoletaMesaEntregaNiquel(cajero: _colaborador.ID, fecha_generacion: new DateTime(), manifiesto: _manifiesto.IDManifiesto, tula: _tula.ID,
                    numerodeposito: _deposito.NumeroDeposito, montoniquel: _deposito.MontoNiquel, montodeposito: _deposito.Monto, procesobajovolumendeposito: _deposito.ID);
                _mantenimiento.agregarBoletaMesaEntregaNiquel(ref boleta);
                _atencion.registrarConteoNiquel(ref conteoNiquel);
                ProcesamientoNiquel procesoNiquel = new ProcesamientoNiquel();
                procesoNiquel.Cajero = _colaborador.ID;
                procesoNiquel.conteoNiquel = conteoNiquel;
                procesoNiquel.Deposito = new ProcesamientoBajoVolumenDeposito(ID: _deposito.ID, procesamientobajovolumen: _procesamientobajovolumen, manifiesto: _manifiesto, tula: _tula, 
                    numero_deposito: txtNumDeposito.Text, codigo_VD: txtCodigoVD.Text, codigo_transaccion: txtCodigoTransaccion.Text, cuenta: txtCtaReferencia.Text, cedula: txtCedula.Text, 
                    moneda: _deposito.Moneda, MontoNiquel: nudMontoNiquel.Value, MontoDeclarado: nudMontoDeclarado.Value, MontoContado: Convert.ToDecimal(txtMontoContado.Text), 
                    Diferencia: Convert.ToDecimal(txtDiferencia.Text), tipomesa: cboTipoMesaNiquel.SelectedIndex, Depositante: pdepositante);

                procesoNiquel.Diferencia = 0;
                procesoNiquel.Fecha = new DateTime();
                procesoNiquel.Identificador = txtNumDeposito.Text;
                procesoNiquel.Manifiesto = _manifiesto;
                procesoNiquel.MontoContado = conteoNiquel.conteototal;
                procesoNiquel.TipoProcesamiento = 3;
                procesoNiquel.TotalNiquel = conteoNiquel.conteototal;
                procesoNiquel.Transportadora = null;
                _atencion.registrarProcesamientoNiquel(ref procesoNiquel);
                archivo.writetext("Ingreso Depósito, Cliente en _manifiesto procesacajeroniquel2: " + _manifiesto.Cliente.Nombre);
                archivo.writetext("Ingreso Depósito, Punto de venta en _manifiesto procesacajeroniquel2: " + _manifiesto.PuntoVenta.Nombre);

            }
            catch (Excepcion ex)
            {
                MessageBox.Show("procesamesaniquel error: " + ex.Message);
            }
        }

        private void procesaEnMesaniquel()
        {
            try
            {
                //string codigoentrega = creacodigounico();
                BoletaMesaNiquel boleta = new BoletaMesaNiquel(procesobajovolumendeposito:_deposito.ID, cajero: _colaborador.ID, fecha: new DateTime(), codigoentrega: "",
                    montoniquel: _deposito.MontoNiquel);
                _mantenimiento.agregarProaInfoEnMesaNiquel(ref boleta);                

            }
            catch (Excepcion ex)
            {
                MessageBox.Show("procesaenmesaniquel error: " + ex.Message);
            }
        }

        private void subprocesodeposito()
        {
            try
            {
                if (cboTipoMesaNiquel.SelectedItem.Equals("Cajero Níquel"))
                {
                    procesacajeroniquel();
                    archivo.writetext("Procesa cajero niquel completado");
                }
                if (cboTipoMesaNiquel.SelectedItem.Equals("En Mesa"))
                {
                    procesaEnMesaniquel();
                    archivo.writetext("Procesa niquel en mesa completado");
                }
                if ((cboTipoMesaNiquel.SelectedItem.Equals("Mesa Níquel")) && (nudMontoNiquel.Value > 0))
                {
                    procesaMesaniquel();
                    archivo.writetext("Procesa mesa niquel completado");
                }
                limpiardepositos(0);
                conteoerrores = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("subprocesodeposito error: " + ex.Message);
            }            
        }

        private void subprocesotula()
        {
            try
            {
                if (cboTipoMesaNiquel.SelectedItem.Equals("Cajero Níquel"))
                {
                    procesacajeroniquel();
                }
                if (cboTipoMesaNiquel.SelectedItem.Equals("En Mesa"))
                {
                    procesaEnMesaniquel();
                }
                if ((cboTipoMesaNiquel.SelectedItem.Equals("Mesa Níquel")) && (nudMontoNiquel.Value > 0))
                {
                    procesaMesaniquel();
                }
                if (_mantenimiento.VerificaTulasManifiesto(ref _manifiesto))
                {
                    MessageBox.Show("Se ha completado la cantidad de tulas del manifiesto. Favor presionar el botón Procesar para cerrar el manifiesto");
                    limpiardepositos(0);
                }
                else
                {
                    limpiardepositos(1);
                }
                if (port != null) port.Close();
                conteoerrores = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("subprocesotula error: " + ex.Message);                
            }
        }

        private void cerrarmanifiesto()
        {
            try
            {
                archivo.writetext("Inicia cerrarmanifiesto");
                archivo.writetext("Ingreso Deposito, Cliente en _manifiesto inicio cerrar manifiesto: " + _manifiesto.Cliente.Nombre);
                archivo.writetext("Ingreso Deposito, Punto de venta en _manifiesto inicio cerrar manifiesto: " + _manifiesto.PuntoVenta.Nombre);
                _mantenimiento.cerrarProcesamientoBajoVolumenManifiesto(ref _manifiesto);
                archivo.writetext("CerrarprocesamientobajoVolumenmanifiesto completado");
                limpiardepositos(1);
                archivo.writetext("Limpiardepositos(1) completado");
                if (port != null) port.Close();
                conteoerrores = 0;
                permisosup = false;
                actualizarmanifiestopendiente();
                archivo.writetext("actualizarmanifiestopendiente completado");
                archivo.writetext("Ingreso Deposito, Cliente en _manifiesto fin cerrar manifiesto: " + _manifiesto.Cliente.Nombre);
                archivo.writetext("Ingreso Deposito, Punto de venta en _manifiesto fin cerrar manifiesto: " + _manifiesto.PuntoVenta.Nombre);
                _manifiesto = null;
                MessageBox.Show("Se ha registrado de forma correcta la información del manifiesto en el sistema.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("cerrarmanifiesto error: " + ex.Message);
            }
        }

        private void cerrarmanifiestoinc()
        {
            try
            {
                archivo.writetext("Inicia cerrarmanifiestoinc");
                archivo.writetext("Ingreso Deposito, Cliente en _manifiesto cerrarmanifiestoinc1: " + _manifiesto.Cliente.Nombre);
                archivo.writetext("Ingreso Deposito, Punto de venta en _manifiesto cerrarmanifiestoinc1: " + _manifiesto.PuntoVenta.Nombre);
                _mantenimiento.cerrarProcesamientoBajoVolumenManifiesto(ref _manifiesto);
                archivo.writetext("cerrarProcesamientoBajoVolumenmanifiesto completado");
                actualizarmanifiestopendiente();
                archivo.writetext("actualizarmanifiestopendiente completado");
                MessageBox.Show("Se ha registrado la información de forma correcta del manifiesto con una diferencia entre el monto del manifiesto y la suma de todos los montos ingresados en los depósitos asociados.");
                limpiardepositos(1);
                archivo.writetext("limpiardepositos(1) completado");
                if (port != null) port.Close();
                conteoerrores = 0;
                permisosup = false;
                archivo.writetext("Ingreso Deposito, Cliente en _manifiesto cerrarmanifiestoinc2: " + _manifiesto.Cliente.Nombre);
                archivo.writetext("Ingreso Deposito, Punto de venta en _manifiesto cerrarmanifiestoinc2: " + _manifiesto.PuntoVenta.Nombre);
                _manifiesto = null;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("cerrarmanifiestoinc error: " + ex.Message);
            }
        }

        private void cargarpantallaresumenmanifiesto(String textomensaje)
        {
            try
            {
                archivo.writetext("Ingreso Deposito, Cliente en _manifiesto cargarpantallaresumenmanifiesto: " + _manifiesto.Cliente.Nombre);
                archivo.writetext("Ingreso Deposito, Punto de venta en _manifiesto cargarpantallaresumenmanifiesto: " + _manifiesto.PuntoVenta.Nombre);
                textomensaje = _mantenimiento.GeneraInformacionMontoManifiesto(ref _manifiesto);
                archivo.writetext("Ingreso Deposito, Cliente en _manifiesto cargarpantallaresumenmanifiesto2: " + _manifiesto.Cliente.Nombre);
                archivo.writetext("Ingreso Deposito, Punto de venta en _manifiesto cargarpantallaresumenmanifiesto2: " + _manifiesto.PuntoVenta.Nombre);
                archivo.writetext("texto de pantalla resumen: " + textomensaje);
                frmPantallaResumenManifiestoPBV pantallaresumen = new frmPantallaResumenManifiestoPBV(_manifiesto, _colaborador);
                pantallaresumen.Tag = textomensaje;
                pantallaresumen.ShowDialog();
                archivo.writetext("Ingreso Deposito, Cliente en _manifiesto cargarpantallaresumenmanifiesto3: " + _manifiesto.Cliente.Nombre);
                archivo.writetext("Ingreso Deposito, Punto de venta en _manifiesto cargarpantallaresumenmanifiesto3: " + _manifiesto.PuntoVenta.Nombre);
            }
            catch (Exception ex)
            {
                MessageBox.Show("cargarpantallaresumenmanifiesto error: " + ex.Message);
            }
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {

            ListViewItem item; //cambios GZH 16082017
            try
            {
                archivo.writetext("Inicia btnProcesar_Click");
                //string textomensaje = "";
                archivo.writetext("Ingreso Deposito, Cliente en _manifiesto inicia btnprocesar: " + _manifiesto.Cliente.Nombre);
                archivo.writetext("Ingreso Deposito, Punto de venta en _manifiesto inicia btnprocesar: " + _manifiesto.PuntoVenta.Nombre);
                if ((_manifiesto.Tulas.Count > 0) && (chkcierremanifiesto == 1))
                {
                    archivo.writetext("Tiene tulas y cierremanifiesto = 1");
                    if (_mantenimiento.VerificaTulasManifiesto(ref _manifiesto))
                    {
                        archivo.writetext("Cantidad de tulas corresponde a la cantidad que debe tener el manifiesto");
                        archivo.writetext("Ingreso Deposito, Cliente en _manifiesto verificartulasmanifiesto: " + _manifiesto.Cliente.Nombre);
                        archivo.writetext("Ingreso Deposito, Punto de venta en _manifiesto verificatulasmanifiesto: " + _manifiesto.PuntoVenta.Nombre);
                        if (MessageBox.Show("La cantidad de TULAS corresponde al MANIFIESTO. ¿Desea CERRAR la TULA y MANIFIESTO?", "Confirmación de procesamiento de tula y manifiesto", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                        {
                            archivo.writetext("Inicia cierre de manifiesto");                            
                            _mantenimiento.EliminarPendienteProcesamientoBajoVolumenTula(ref _tula);
                            archivo.writetext("Elimina manifiesto pendiente de procesar");
                            cargarpantallaresumenmanifiesto("");
                            archivo.writetext("Genera pantalla resumen de manifiesto");
                            byte errmanifiesto = 0;
                            archivo.writetext("Monto Diferencia colones manifiesto: " + _manifiesto.Monto_Diferencia_Colones.ToString());
                            if (_manifiesto.Monto_Diferencia_Colones != 0)
                            {
                                //if (Math.Abs(_manifiesto.Monto_Diferencia_Colones) > 1000)
                                //{
                                //    permisosup = false;
                                //    while (permisosup == false)
                                //    {
                                //        frmValidacionCoordinadorCE formulario = new frmValidacionCoordinadorCE(9, _colaborador);
                                //        formulario.ShowDialog(this);
                                //    }
                                //    _mantenimiento.RegistrarInconsistenciaBajoVolumenManifiesto(ref _manifiesto, ref _colaborador, comentarioincons, Monedas.Colones);
                                //}
                                //else
                                //{
                                //    _mantenimiento.RegistrarInconsistenciaBajoVolumenManifiesto(ref _manifiesto, ref _colaborador, "", Monedas.Colones);
                                //}                                                                        
                                errmanifiesto = 1;
                            }
                            archivo.writetext("Monto Diferencia dólares manifiesto: " + _manifiesto.Monto_Diferencia_Dolares.ToString());
                            if (_manifiesto.Monto_Diferencia_Dolares != 0)
                            {
                                //if (Math.Abs(_manifiesto.Monto_Diferencia_Dolares) > 2)
                                //{
                                //    permisosup = false;
                                //    while (permisosup == false)
                                //    {
                                //        frmValidacionCoordinadorCE formulario = new frmValidacionCoordinadorCE(9, _colaborador);
                                //        formulario.ShowDialog(this);
                                //    }
                                //    _mantenimiento.RegistrarInconsistenciaBajoVolumenManifiesto(ref _manifiesto, ref _colaborador, comentarioincons, Monedas.Dolares);
                                //}
                                //else
                                //{
                                //    _mantenimiento.RegistrarInconsistenciaBajoVolumenManifiesto(ref _manifiesto, ref _colaborador, "", Monedas.Dolares);
                                //}
                                errmanifiesto = 1;
                            }
                            archivo.writetext("Monto Diferencia euros manifiesto: " + _manifiesto.Monto_Diferencia_Euros.ToString());
                            if (_manifiesto.Monto_Diferencia_Euros != 0)
                            {
                                //if (Math.Abs(_manifiesto.Monto_Diferencia_Euros) > 2)
                                //{
                                //    permisosup = false;
                                //    while (permisosup == false)
                                //    {
                                //        frmValidacionCoordinadorCE formulario = new frmValidacionCoordinadorCE(9, _colaborador);
                                //        formulario.ShowDialog(this);
                                //    }
                                //    _mantenimiento.RegistrarInconsistenciaBajoVolumenManifiesto(ref _manifiesto, ref _colaborador, comentarioincons, Monedas.Euros);
                                //}
                                //else
                                //{
                                //    _mantenimiento.RegistrarInconsistenciaBajoVolumenManifiesto(ref _manifiesto, ref _colaborador, "", Monedas.Euros);
                                //}
                                    //_mantenimiento.RegistrarInconsistenciaBajoVolumenManifiesto(ref _manifiesto, ref _colaborador, "", Monedas.Euros);
                                errmanifiesto = 1;
                            }
                            if (errmanifiesto == 0)
                            {
                                archivo.writetext("Llama proceso cierra manifiesto");
                                cerrarmanifiesto();
                            }
                            else
                            {
                                archivo.writetext("Llama proceso cierra manifiesto inc");
                                cerrarmanifiestoinc();
                            }
                            /*if (_mantenimiento.VerificaMontoManifiesto(ref _manifiesto) == 0)
                            {
                                cargarpantallaresumenmanifiesto("");
                                cerrarmanifiesto();
                            }
                            else
                            {
                                Decimal DiferenciaMontoManifiesto = _mantenimiento.VerificaMontoManifiesto(ref _manifiesto);
                                if (DiferenciaMontoManifiesto == 0)
                                {
                                    cerrarmanifiesto();
                                }
                                else
                                {
                                    _mantenimiento.RegistrarInconsistenciaBajoVolumenManifiesto(ref _manifiesto, ref _colaborador, DiferenciaMontoManifiesto, "");
                                    cargarpantallaresumenmanifiesto("");
                                    cerrarmanifiestoinc();
                                }
                            }*/
                        }
                        else
                        {
                            BindingList<ProcesamientoBajoVolumenDeposito> listadeposito = _mantenimiento.listarProcesamientoBajoVolumenDeposito(_manifiesto);
                            _tula = new Tula("");
                            lstDepósitos.Items.Clear();
                            foreach (ProcesamientoBajoVolumenDeposito procesamientodeposito in listadeposito)
                            {
                                item = new ListViewItem();
                                item.SubItems[0].Text = procesamientodeposito.NumeroDeposito;
                                item.SubItems.Add(procesamientodeposito.MontoContado.ToString());
                                lstDepósitos.Items.Add(item);
                                archivo.writetext("Agrega depósito a clase: " + procesamientodeposito.NumeroDeposito.ToString());
                                archivo.writetext("Monto depósito: " + procesamientodeposito.MontoContado.ToString());
                                _deposito = new Deposito(procesamientodeposito.DB_ID, procesamientodeposito.ID, procesamientodeposito.MontoContado, 0, procesamientodeposito.Moneda,
                                procesamientodeposito.CodigoVD, procesamientodeposito.CodigoTransaccion, procesamientodeposito.Cuenta, procesamientodeposito.Cedula, procesamientodeposito.TipoMesa,
                                procesamientodeposito.MontoNiquel, procesamientodeposito.MontoDeclarado, procesamientodeposito.Diferencia, procesamientodeposito.NumeroDeposito,
                                procesamientodeposito.Depositante);
                                if (txtNumero.Text.Equals(procesamientodeposito.Tula.ToString()))
                                {
                                    if (_tula.ID == 0)
                                    {
                                        _tula = procesamientodeposito.Tula;
                                        archivo.writetext("Asocia tula de procesamiento a _tula: " + procesamientodeposito.Tula.ID.ToString());

                                    }                                    
                                    _tula.agregarDeposito(_deposito);
                                    archivo.writetext("Agrega depósito a _tula");

                                    //break;
                                }
                                
                            }
                        }
                    } else {
                        if (MessageBox.Show("¿Desea CERRAR la TULA y procesar otra?", "Confirmación de procesamiento de tula", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                        {
                            archivo.writetext("Cerrando tula " + _tula.ToString());
                            _mantenimiento.EliminarPendienteProcesamientoBajoVolumenTula(ref _tula);
                            archivo.writetext("Elimina pendiente de procesamiento bajo volumen tula");
                            txtNumero.Enabled = true;
                            txtNumero.Text = "";
                            txtNumero.Focus();
                            gbDatosDeposito.Enabled = false;
                            btnVerificar.Enabled = true;
                            btnCancelarTula.Enabled = true;
                            //btnmodificar.Enabled = true;
                            epError.SetError(btnextraerinfo, "");
                            _tula = new Tula("");
                            if (port != null)
                            {
                                if (port.IsOpen) port.Close();
                            }
                            /*if (MessageBox.Show("¿Desea CERRAR el MANIFIESTO?", "Confirmación de procesamiento de manifiesto", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                            {
                                if (_mantenimiento.VerificaTulasManifiesto(ref _manifiesto))
                                {
                                    cargarpantallaresumenmanifiesto("");
                                    byte errmanifiesto = 0;
                                    if (_manifiesto.Monto_Diferencia_Colones != 0)
                                    {
                                        if (Math.Abs(_manifiesto.Monto_Diferencia_Colones) > 1000)
                                        {
                                            permisosup = false;
                                            while (permisosup == false)
                                            {
                                                frmValidacionCoordinadorCE formulario = new frmValidacionCoordinadorCE(9, _colaborador);
                                                formulario.ShowDialog(this);
                                            }
                                            _mantenimiento.RegistrarInconsistenciaBajoVolumenManifiesto(ref _manifiesto, ref _colaborador, comentarioincons, Monedas.Colones);
                                        }
                                        else
                                        {
                                            _mantenimiento.RegistrarInconsistenciaBajoVolumenManifiesto(ref _manifiesto, ref _colaborador, "", Monedas.Colones);
                                        }                                       
                                        errmanifiesto = 1;
                                    }

                                    if (_manifiesto.Monto_Diferencia_Dolares != 0)
                                    {
                                        if (Math.Abs(_manifiesto.Monto_Diferencia_Dolares) > 2)
                                        {
                                            permisosup = false;
                                            while (permisosup == false)
                                            {
                                                frmValidacionCoordinadorCE formulario = new frmValidacionCoordinadorCE(9, _colaborador);
                                                formulario.ShowDialog(this);
                                            }
                                            _mantenimiento.RegistrarInconsistenciaBajoVolumenManifiesto(ref _manifiesto, ref _colaborador, comentarioincons, Monedas.Dolares);
                                        }
                                        else
                                        {
                                            _mantenimiento.RegistrarInconsistenciaBajoVolumenManifiesto(ref _manifiesto, ref _colaborador, "", Monedas.Dolares);
                                        }                                        
                                        errmanifiesto = 1;
                                    }

                                    if (_manifiesto.Monto_Diferencia_Euros != 0)
                                    {
                                        if (Math.Abs(_manifiesto.Monto_Diferencia_Euros) > 2)
                                        {
                                            permisosup = false;
                                            while (permisosup == false)
                                            {
                                                frmValidacionCoordinadorCE formulario = new frmValidacionCoordinadorCE(9, _colaborador);
                                                formulario.ShowDialog(this);
                                            }
                                            _mantenimiento.RegistrarInconsistenciaBajoVolumenManifiesto(ref _manifiesto, ref _colaborador, comentarioincons, Monedas.Euros);
                                        }
                                        else
                                        {
                                            _mantenimiento.RegistrarInconsistenciaBajoVolumenManifiesto(ref _manifiesto, ref _colaborador, "", Monedas.Euros);
                                        }                                        
                                        errmanifiesto = 1;
                                    }
                                    if (errmanifiesto == 0)
                                    {
                                        cerrarmanifiesto();
                                    }
                                    else
                                    {
                                        cerrarmanifiestoinc();
                                    }
                                    /*if (_mantenimiento.VerificaMontoManifiesto(ref _manifiesto) == 0)
                                    {
                                        cargarpantallaresumenmanifiesto("");
                                        cerrarmanifiesto();
                                    }
                                    else
                                    {
                                        Decimal DiferenciaMontoManifiesto = _mantenimiento.VerificaMontoManifiesto(ref _manifiesto);
                                        if (DiferenciaMontoManifiesto == 0)
                                        {
                                            cerrarmanifiesto();
                                        }
                                        else
                                        {
                                            _mantenimiento.RegistrarInconsistenciaBajoVolumenManifiesto(ref _manifiesto, ref _colaborador, DiferenciaMontoManifiesto, "");
                                            cargarpantallaresumenmanifiesto("");
                                            cerrarmanifiestoinc();
                                        }
                                    }*/
                                /*}
                                else
                                {
                                    MessageBox.Show("La cantidad de Tulas ingresadas no corresponden a la cantidad de Tulas asociadas al manifiesto");
                                }
                            }*/
                        }
                    }                    
                }
                else
                {
                    if (((validaCampos()) || (conteoerrores == 2))) //&& (nuderror2 == 0)
                    {
                        if (MessageBox.Show("¿Desea procesar otro DEPÓSITO?", "Confirmación de procesamiento", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                        {
                            archivo.writetext("Inicia procesa de depósito sobre misma tula");
                            if (conteoerrores == 2)
                            {
                                archivo.writetext("Pantalla validación coordinador");
                                frmValidacionCoordinadorCE formulario = new frmValidacionCoordinadorCE(5, _colaborador);
                                formulario.ShowDialog(this);
                                if (permisosup)
                                {
                                    archivo.writetext("Permiso coordinador correcto");
                                    if (procesadeposito(0) == 1)
                                    {
                                        archivo.writetext("Procesadeposito(0) correcto.");
                                        subprocesodeposito();
                                        archivo.writetext("Subprocesodeposito completo");
                                        permisosup = false;
                                    }
                                    else
                                    {
                                        epError.SetError(txtNumDeposito, "El número de depósito indicado ya existe, favor ingrese otro");
                                        conteoerrores = 1;
                                    }
                                }
                                else
                                {
                                    epError.SetError(txtDiferencia, "No puede registrar el depósito debido a que no tiene autorización del supervisor/coordinador");
                                    conteoerrores = 1;
                                }
                            }
                            else
                            {
                                if (conteoerrores == 0)
                                {
                                    if (procesadeposito(0) == 1)
                                    {
                                        /*if (cboTipoMesaNiquel.SelectedItem.Equals("Cajero Níquel"))
                                        {
                                            procesacajeroniquel();
                                        }
                                        if (cboTipoMesaNiquel.SelectedItem.Equals("En Mesa"))
                                        {
                                            procesaEnMesaniquel();
                                        }
                                        if (cboTipoMesaNiquel.SelectedItem.Equals("Mesa Níquel"))
                                        {
                                            procesaMesaniquel();
                                        }
                                        limpiardepositos(0);
                                        conteoerrores = 0;*/
                                        subprocesodeposito();
                                    }
                                    else
                                    {
                                        epError.SetError(txtNumDeposito, "El número de depósito indicado ya existe, favor ingrese otro");
                                    }
                                }
                            }

                        }
                        else
                        {
                            if (MessageBox.Show("¿Desea procesar otra TULA?", "Confirmación de procesamiento", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                            {
                                if (conteoerrores == 2)
                                {
                                    frmValidacionCoordinadorCE formulario = new frmValidacionCoordinadorCE(5, _colaborador);
                                    formulario.ShowDialog(this);
                                    if (permisosup)
                                    {
                                        if (procesadeposito(1) == 1)
                                        {
                                            archivo.writetext("Procesadeposito(1) completado");
                                            /*if (cboTipoMesaNiquel.SelectedItem.Equals("Cajero Níquel"))
                                            {
                                                procesacajeroniquel();
                                            }
                                            if (cboTipoMesaNiquel.SelectedItem.Equals("En Mesa"))
                                            {
                                                procesaEnMesaniquel();
                                            }
                                            if (cboTipoMesaNiquel.SelectedItem.Equals("Mesa Níquel"))
                                            {
                                                procesaMesaniquel();
                                            }
                                            if (_mantenimiento.VerificaTulasManifiesto(ref _manifiesto))
                                            {
                                                MessageBox.Show("Se ha llegado a la cantidad de tulas que posee el manifiesto. Favor presionar el botón Procesar para cerrar el manifiesto");
                                                limpiardepositos(0);
                                            }
                                            else
                                            {
                                                limpiardepositos(1);
                                            }
                                            if (port != null) port.Close();
                                            conteoerrores = 0;*/
                                            subprocesotula();
                                            archivo.writetext("subprocesatula completado");
                                            permisosup = false;
                                        }
                                        else
                                        {
                                            archivo.writetext("Procesadeposito(0) completado");
                                            epError.SetError(txtNumDeposito, "El número de depósito indicado ya existe, favor ingrese otro");
                                        }

                                    }
                                    else
                                    {
                                        epError.SetError(txtDiferencia, "No puede registrar el depósito debido a que no tiene autorización del supervisor/coordinador");
                                        conteoerrores = 0;
                                    }
                                }
                                else
                                {
                                    if (conteoerrores == 0)
                                    {
                                        archivo.writetext("Sin errores al procesar");
                                        if (procesadeposito(1) == 1)
                                        {
                                            archivo.writetext("Procesadeposito(1) completado");
                                            /*if (cboTipoMesaNiquel.SelectedItem.Equals("Cajero Níquel"))
                                            {
                                                procesacajeroniquel();
                                            }
                                            if (cboTipoMesaNiquel.SelectedItem.Equals("En Mesa"))
                                            {
                                                procesaEnMesaniquel();
                                            }
                                            if (cboTipoMesaNiquel.SelectedItem.Equals("Mesa Níquel"))
                                            {
                                                procesaMesaniquel();
                                            }
                                            if (_mantenimiento.VerificaTulasManifiesto(ref _manifiesto))
                                            {
                                                MessageBox.Show("Se ha llegado a la cantidad de tulas que posee el manifiesto. Favor presionar el botón Procesar para cerrar el manifiesto");
                                                limpiardepositos(0);
                                            }
                                            else
                                            {
                                                limpiardepositos(1);
                                            }
                                            if (port != null) port.Close();
                                            conteoerrores = 0;*/
                                            subprocesotula();
                                        }
                                        else
                                        {
                                            archivo.writetext("Procesadeposito(0) completado");
                                            epError.SetError(txtNumDeposito, "El número de depósito indicado ya existe, favor ingrese otro");
                                        }
                                    }
                                }
                            }
                            else //procesamiento manifiesto
                            {
                                if (conteoerrores == 2)
                                {
                                    archivo.writetext("Conteo errores = 2");
                                    frmValidacionCoordinadorCE formulario = new frmValidacionCoordinadorCE(5, _colaborador);
                                    formulario.ShowDialog(this);
                                    archivo.writetext("Pantalla valida coordinador completado");
                                    if (permisosup)
                                    {
                                        archivo.writetext("Procesadeposito(1) completado");
                                        /////////////
                                        if (procesadeposito(1) == 1)
                                        {
                                            archivo.writetext("Procesadeposito(1) completado");
                                            if (cboTipoMesaNiquel.SelectedItem.Equals("Cajero Níquel"))
                                            {
                                                procesacajeroniquel();
                                                archivo.writetext("Procesacajeroniquel completado");
                                            }
                                            if (cboTipoMesaNiquel.SelectedItem.Equals("En Mesa"))
                                            {
                                                procesaEnMesaniquel();
                                                archivo.writetext("Procesaenniquel completado");
                                            }
                                            if ((cboTipoMesaNiquel.SelectedItem.Equals("Mesa Níquel")) && (nudMontoNiquel.Value > 0))
                                            {
                                                procesaMesaniquel();
                                                archivo.writetext("Procesamesaniquel completado");
                                            }
                                            if (_mantenimiento.VerificaTulasManifiesto(ref _manifiesto))
                                            {
                                                archivo.writetext("Verificación cantidad tulas acorde a manifiesto");
                                                archivo.writetext("Ingreso Deposito, Cliente en _manifiesto verificatulasmanifiesto2: " + _manifiesto.Cliente.Nombre);
                                                archivo.writetext("Ingreso Deposito, Punto de venta en _manifiesto verificatulasmanifiesto2: " + _manifiesto.PuntoVenta.Nombre);
                                                /*textomensaje = _mantenimiento.GeneraInformacionMontoManifiesto(ref _manifiesto);
                                                frmPantallaResumenManifiestoPBV pantallaresumen = new frmPantallaResumenManifiestoPBV();
                                                pantallaresumen.Tag = textomensaje;
                                                pantallaresumen.ShowDialog();*/
                                                ////cargarpantallaresumenmanifiesto("");
                                                //MessageBox.Show(textomensaje, "Resumen de Procesamiento", MessageBoxButtons.OK);
                                                /*Decimal DiferenciaMontoManifiesto = _mantenimiento.VerificaMontoManifiesto(ref _manifiesto);
                                                if (DiferenciaMontoManifiesto == 0)
                                                {

                                                    /*_mantenimiento.agregarProcesamientoBajoVolumenManifiesto(ref _procesamientobajovolumen, ref _manifiesto);
                                                    limpiardepositos(1);
                                                    if (port != null) port.Close();
                                                    conteoerrores = 0;
                                                    permisosup = false;
                                                    actualizarmanifiestopendiente();
                                                    cerrarmanifiesto();
                                                    MessageBox.Show("Se ha registrado de forma correcta la información del manifiesto en el sistema.");
                                                    this.Close();
                                                    cerrarmanifiesto();
                                                }
                                                else
                                                {
                                                    _mantenimiento.RegistrarInconsistenciaBajoVolumenManifiesto(ref _manifiesto, ref _colaborador, DiferenciaMontoManifiesto, "");
                                                    /*_mantenimiento.agregarProcesamientoBajoVolumenManifiesto(ref _procesamientobajovolumen, ref _manifiesto);
                                                    actualizarmanifiestopendiente();
                                                    MessageBox.Show("Se ha registrado la información de forma correcta del manifiesto con una diferencia entre el monto del manifiesto y la suma de todos los montos ingresados en los depósitos asociados.");
                                                    limpiardepositos(1);
                                                    if (port != null) port.Close();
                                                    conteoerrores = 0;
                                                    permisosup = false;                                                
                                                    this.Close();
                                                    cerrarmanifiestoinc();
                                                }*/
                                                cargarpantallaresumenmanifiesto("");
                                                archivo.writetext("cargarpantallaresumenmanifiesto completado");
                                                archivo.writetext("Ingreso Deposito, Cliente en _manifiesto cargarpantallaresumenmanifiesto completado: " + _manifiesto.Cliente.Nombre);
                                                archivo.writetext("Ingreso Deposito, Punto de venta en _manifiesto cargarpantallaresumenmanifiesto completado: " + _manifiesto.PuntoVenta.Nombre);
                                                byte errmanifiesto = 0;
                                                if (_manifiesto.Monto_Diferencia_Colones != 0)
                                                {
                                                    archivo.writetext("Monto diferencia colones manifiesto: " + _manifiesto.Monto_Diferencia_Colones);
                                                    //if (Math.Abs(_manifiesto.Monto_Diferencia_Colones) > 1000)
                                                    //{
                                                    //    permisosup = false;
                                                    //    while (permisosup == false)
                                                    //    {
                                                    //        frmValidacionCoordinadorCE formulario2 = new frmValidacionCoordinadorCE(9, _colaborador);
                                                    //        formulario2.ShowDialog(this);
                                                    //    }
                                                    //    _mantenimiento.RegistrarInconsistenciaBajoVolumenManifiesto(ref _manifiesto, ref _colaborador, comentarioincons, Monedas.Colones);
                                                    //}
                                                    //else
                                                    //{
                                                    //    _mantenimiento.RegistrarInconsistenciaBajoVolumenManifiesto(ref _manifiesto, ref _colaborador, "", Monedas.Colones);
                                                    //}      
                                                    errmanifiesto = 1;
                                                }

                                                if (_manifiesto.Monto_Diferencia_Dolares != 0)
                                                {
                                                    archivo.writetext("Monto diferencia dolares manifiesto: " + _manifiesto.Monto_Diferencia_Dolares);
                                                    //if (Math.Abs(_manifiesto.Monto_Diferencia_Dolares) > 2)
                                                    //{
                                                    //    permisosup = false;
                                                    //    while (permisosup == false)
                                                    //    {
                                                    //        frmValidacionCoordinadorCE formulario2 = new frmValidacionCoordinadorCE(9, _colaborador);
                                                    //        formulario2.ShowDialog(this);
                                                    //    }
                                                    //    _mantenimiento.RegistrarInconsistenciaBajoVolumenManifiesto(ref _manifiesto, ref _colaborador, comentarioincons, Monedas.Dolares);
                                                    //}
                                                    //else
                                                    //{
                                                    //    _mantenimiento.RegistrarInconsistenciaBajoVolumenManifiesto(ref _manifiesto, ref _colaborador, "", Monedas.Dolares);
                                                    //}
                                                    errmanifiesto = 1;
                                                }

                                                if (_manifiesto.Monto_Diferencia_Euros != 0)
                                                {
                                                    archivo.writetext("Monto diferencia euros manifiesto: " + _manifiesto.Monto_Diferencia_Euros);
                                                    //if (Math.Abs(_manifiesto.Monto_Diferencia_Euros) > 2)
                                                    //{
                                                    //    permisosup = false;
                                                    //    while (permisosup == false)
                                                    //    {
                                                    //        frmValidacionCoordinadorCE formulario2 = new frmValidacionCoordinadorCE(9, _colaborador);
                                                    //        formulario2.ShowDialog(this);
                                                    //    }
                                                    //    _mantenimiento.RegistrarInconsistenciaBajoVolumenManifiesto(ref _manifiesto, ref _colaborador, comentarioincons, Monedas.Euros);
                                                    //}
                                                    //else
                                                    //{
                                                    //    _mantenimiento.RegistrarInconsistenciaBajoVolumenManifiesto(ref _manifiesto, ref _colaborador, "", Monedas.Euros);
                                                    //}                                                    
                                                    errmanifiesto = 1;
                                                }
                                                if (errmanifiesto == 0)
                                                {
                                                    archivo.writetext("Sin errores para cerrar manifiesto");
                                                    cerrarmanifiesto();
                                                    archivo.writetext("cerrarmanifiesto completado");
                                                }
                                                else
                                                {
                                                    archivo.writetext("Con errores para cerrar manifiesto");
                                                    cerrarmanifiestoinc();
                                                    archivo.writetext("cerrarmanifiestoinc completado");
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("La cantidad de Tulas ingresadas no corresponden a la cantidad de Tulas asociadas al manifiesto");
                                            }
                                        }
                                        else
                                        {
                                            epError.SetError(txtNumDeposito, "El número de depósito indicado ya existe, favor ingrese otro");
                                            if (conteoerrores < 2) 
                                                conteoerrores += 1;
                                            if (MessageBox.Show("El número de depósito indicado ya existe, ¿Desea desea cerrar el procesamiento de la tula y manifiesto?", "Confirmación de procesamiento de tula y manifiesto", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                                            {
                                                archivo.writetext("Ingresa if depósito ya existe, cerrar todo");
                                                if (_mantenimiento.VerificaTulasManifiesto(ref _manifiesto))
                                                {
                                                    archivo.writetext("Verificatulasmanifiesto sí");
                                                    archivo.writetext("Ingreso Deposito, Cliente en _manifiesto verificatulasmanifiesto3: " + _manifiesto.Cliente.Nombre);
                                                    archivo.writetext("Ingreso Deposito, Punto de venta en _manifiesto verificatulasmanifiesto3: " + _manifiesto.PuntoVenta.Nombre);
                                                    /*textomensaje = _mantenimiento.GeneraInformacionMontoManifiesto(ref _manifiesto);
                                                    frmPantallaResumenManifiestoPBV pantallaresumen = new frmPantallaResumenManifiestoPBV();
                                                    pantallaresumen.Tag = textomensaje;
                                                    pantallaresumen.ShowDialog();*/
                                                    //cargarpantallaresumenmanifiesto("");
                                                    //MessageBox.Show(textomensaje, "Resumen de Procesamiento", MessageBoxButtons.OK);
                                                    /*Decimal DiferenciaMontoManifiesto = _mantenimiento.VerificaMontoManifiesto(ref _manifiesto);
                                                    if (DiferenciaMontoManifiesto == 0)
                                                    {

                                                        /*_mantenimiento.agregarProcesamientoBajoVolumenManifiesto(ref _procesamientobajovolumen, ref _manifiesto);
                                                        limpiardepositos(1);
                                                        if (port != null) port.Close();
                                                        conteoerrores = 0;
                                                        permisosup = false;
                                                        actualizarmanifiestopendiente();
                                                        MessageBox.Show("Se ha registrado de forma correcta la información del manifiesto en el sistema.");
                                                        this.Close();
                                                        cerrarmanifiesto();
                                                    }
                                                    else
                                                    {
                                                        _mantenimiento.RegistrarInconsistenciaBajoVolumenManifiesto(ref _manifiesto, ref _colaborador, DiferenciaMontoManifiesto, "");
                                                        /*_mantenimiento.agregarProcesamientoBajoVolumenManifiesto(ref _procesamientobajovolumen, ref _manifiesto);
                                                        actualizarmanifiestopendiente();
                                                        MessageBox.Show("Se ha registrado la información de forma correcta del manifiesto con una diferencia entre el monto del manifiesto y la suma de todos los montos ingresados en los depósitos asociados.");
                                                        limpiardepositos(1);
                                                        if (port != null) port.Close();
                                                        conteoerrores = 0;
                                                        permisosup = false;
                                                        this.Close();
                                                        cerrarmanifiestoinc();
                                                    }*/
                                                    cargarpantallaresumenmanifiesto("");
                                                    archivo.writetext("cargarpantallaresumenmanifiesto completado");
                                                    archivo.writetext("Ingreso Deposito, Cliente en _manifiesto cargarpantallaresumenmanifiesto completado2: " + _manifiesto.Cliente.Nombre);
                                                    archivo.writetext("Ingreso Deposito, Punto de venta en _manifiesto cargarpantallaresumenmanifiesto completado2: " + _manifiesto.PuntoVenta.Nombre);
                                                    byte errmanifiesto = 0;
                                                    if (_manifiesto.Monto_Diferencia_Colones != 0)
                                                    {
                                                        archivo.writetext("Monto diferencia colones manifiesto: " + _manifiesto.Monto_Diferencia_Colones);
                                                        //if (Math.Abs(_manifiesto.Monto_Diferencia_Colones) > 1000)
                                                        //{
                                                        //    permisosup = false;
                                                        //    while (permisosup == false)
                                                        //    {
                                                        //        frmValidacionCoordinadorCE formulario2 = new frmValidacionCoordinadorCE(9, _colaborador);
                                                        //        formulario2.ShowDialog(this);
                                                        //    }
                                                        //    _mantenimiento.RegistrarInconsistenciaBajoVolumenManifiesto(ref _manifiesto, ref _colaborador, comentarioincons, Monedas.Colones);
                                                        //}
                                                        //else
                                                        //{
                                                        //    _mantenimiento.RegistrarInconsistenciaBajoVolumenManifiesto(ref _manifiesto, ref _colaborador, "", Monedas.Colones);
                                                        //}
                                                        errmanifiesto = 1;
                                                    }

                                                    if (_manifiesto.Monto_Diferencia_Dolares != 0)
                                                    {
                                                        archivo.writetext("Monto diferencia dolares manifiesto: " + _manifiesto.Monto_Diferencia_Dolares);
                                                        //if (Math.Abs(_manifiesto.Monto_Diferencia_Dolares) > 2)
                                                        //{
                                                        //    permisosup = false;
                                                        //    while (permisosup == false)
                                                        //    {
                                                        //        frmValidacionCoordinadorCE formulario2 = new frmValidacionCoordinadorCE(9, _colaborador);
                                                        //        formulario2.ShowDialog(this);
                                                        //    }
                                                        //    _mantenimiento.RegistrarInconsistenciaBajoVolumenManifiesto(ref _manifiesto, ref _colaborador, comentarioincons, Monedas.Dolares);
                                                        //}
                                                        //else
                                                        //{
                                                        //    _mantenimiento.RegistrarInconsistenciaBajoVolumenManifiesto(ref _manifiesto, ref _colaborador, "", Monedas.Dolares);
                                                        //}
                                                        errmanifiesto = 1;
                                                    }

                                                    if (_manifiesto.Monto_Diferencia_Euros != 0)
                                                    {
                                                        archivo.writetext("Monto diferencia euros manifiesto: " + _manifiesto.Monto_Diferencia_Euros);
                                                        //if (Math.Abs(_manifiesto.Monto_Diferencia_Euros) > 2)
                                                        //{
                                                        //    permisosup = false;
                                                        //    while (permisosup == false)
                                                        //    {
                                                        //        frmValidacionCoordinadorCE formulario2 = new frmValidacionCoordinadorCE(9, _colaborador);
                                                        //        formulario2.ShowDialog(this);
                                                        //    }
                                                        //    _mantenimiento.RegistrarInconsistenciaBajoVolumenManifiesto(ref _manifiesto, ref _colaborador, comentarioincons, Monedas.Euros);
                                                        //}
                                                        //else
                                                        //{
                                                        //    _mantenimiento.RegistrarInconsistenciaBajoVolumenManifiesto(ref _manifiesto, ref _colaborador, "", Monedas.Euros);
                                                        //}                                                        
                                                        errmanifiesto = 1;
                                                    }
                                                    if (errmanifiesto == 0)
                                                    {
                                                        cerrarmanifiesto();
                                                        archivo.writetext("cerrarmanifiesto completado");
                                                        archivo.writetext("Ingreso Deposito, Cliente en _manifiesto cargarpantallaresumenmanifiesto completado4: " + _manifiesto.Cliente.Nombre);
                                                        archivo.writetext("Ingreso Deposito, Punto de venta en _manifiesto cargarpantallaresumenmanifiesto completado4: " + _manifiesto.PuntoVenta.Nombre);
                                                    }
                                                    else
                                                    {
                                                        cerrarmanifiestoinc();
                                                        archivo.writetext("Ingreso Deposito, Cliente en _manifiesto cargarpantallaresumenmanifiestoinc completado: " + _manifiesto.Cliente.Nombre);
                                                        archivo.writetext("Ingreso Deposito, Punto de venta en _manifiesto cargarpantallaresumenmanifiestoinc completado: " + _manifiesto.PuntoVenta.Nombre);
                                                        archivo.writetext("Monto diferencia euros manifiesto: " + _manifiesto.Monto_Diferencia_Euros);
                                                    }
                                                }
                                                else
                                                {
                                                    MessageBox.Show("La cantidad de Tulas ingresadas no corresponden a la cantidad de Tulas asociadas al manifiesto");
                                                }
                                            }                                            
                                        }
                                    }
                                    else
                                    {
                                        epError.SetError(txtDiferencia, "No puede registrar el depósito debido a que no tiene autorización del supervisor/coordinador");
                                        conteoerrores = 0;
                                    }
                                }
                                else
                                {
                                    if (procesadeposito(1) == 1)
                                    {
                                        if (cboTipoMesaNiquel.SelectedItem.Equals("Cajero Níquel"))
                                        {
                                            procesacajeroniquel();
                                        }
                                        if (cboTipoMesaNiquel.SelectedItem.Equals("En Mesa"))
                                        {
                                            procesaEnMesaniquel();
                                        }
                                        if ((cboTipoMesaNiquel.SelectedItem.Equals("Mesa Níquel")) && (nudMontoNiquel.Value > 0))
                                        {
                                            procesaMesaniquel();
                                        }
                                        if (_mantenimiento.VerificaTulasManifiesto(ref _manifiesto))
                                        {
                                            archivo.writetext(" ");
                                            archivo.writetext("Ingreso Deposito, Cliente en _manifiesto VerificaTulasManifiesto2: " + _manifiesto.Cliente.Nombre);
                                            archivo.writetext("Ingreso Deposito, Punto de venta en _manifiesto VerificaTulasManifiesto2: " + _manifiesto.PuntoVenta.Nombre);
                                            if (_mantenimiento.VerificaMontoManifiesto(ref _manifiesto) == 0)
                                            {
                                                archivo.writetext("Verifica monto manifiesto completado.");
                                                archivo.writetext("Ingreso Deposito, Cliente en _manifiesto VerificaMontoManifiesto: " + _manifiesto.Cliente.Nombre);
                                                archivo.writetext("Ingreso Deposito, Punto de venta en _manifiesto VerificaMontoManifiesto: " + _manifiesto.PuntoVenta.Nombre);
                                                /*textomensaje = _mantenimiento.GeneraInformacionMontoManifiesto(ref _manifiesto);
                                                frmPantallaResumenManifiestoPBV pantallaresumen = new frmPantallaResumenManifiestoPBV();
                                                pantallaresumen.Tag = textomensaje;
                                                pantallaresumen.ShowDialog();*/
                                                cargarpantallaresumenmanifiesto("");
                                                archivo.writetext("cargarpantallaresumenmanifiesto completada");
                                                archivo.writetext("Ingreso Deposito, Cliente en _manifiesto cargarpantallaresumenmanifiesto5: " + _manifiesto.Cliente.Nombre);
                                                archivo.writetext("Ingreso Deposito, Punto de venta en _manifiesto cargarpantallaresumenmanifiesto5: " + _manifiesto.PuntoVenta.Nombre);
                                                //MessageBox.Show(textomensaje, "Resumen de Procesamiento", MessageBoxButtons.OK);
                                                /*_mantenimiento.agregarProcesamientoBajoVolumenManifiesto(ref _procesamientobajovolumen, ref _manifiesto);
                                                limpiardepositos(1);
                                                if (port != null) port.Close();
                                                conteoerrores = 0;
                                                actualizarmanifiestopendiente();
                                                MessageBox.Show("Se ha registrado de forma correcta la información del manifiesto en el sistema.");
                                                _manifiesto = null;
                                                this.Close();*/
                                                cerrarmanifiesto();
                                                archivo.writetext("cerrarmanifiesto completado.");
                                            }
                                            else
                                            {
                                                limpiardepositos(0);
                                                conteoerrores += 1;
                                                if (_manifiesto.Monto_Diferencia_Colones != 0)
                                                {
                                                    MessageBox.Show("El monto del manifiesto en Colones no corresponde a la suma de todos los montos ingresados en los depósitos asociados");
                                                }
                                                if (_manifiesto.Monto_Diferencia_Dolares != 0)
                                                {
                                                    MessageBox.Show("El monto del manifiesto en Dólares no corresponde a la suma de todos los montos ingresados en los depósitos asociados");
                                                }
                                                if (_manifiesto.Monto_Diferencia_Euros != 0)
                                                {
                                                    MessageBox.Show("El monto del manifiesto en Euros no corresponde a la suma de todos los montos ingresados en los depósitos asociados");
                                                }
                                            }
                                        }
                                        else
                                        {
                                            limpiardepositos(0);
                                            MessageBox.Show("La cantidad de Tulas ingresadas no corresponden a la cantidad de Tulas asociadas al manifiesto");
                                        }
                                    }
                                    else
                                    {
                                        epError.SetError(txtNumDeposito, "El número de depósito indicado ya existe, favor ingrese otro");
                                        if (MessageBox.Show("El número de depósito indicado ya existe, ¿Desea desea cerrar el procesamiento de la tula y manifiesto?", "Confirmación de procesamiento de tula y manifiesto", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                                        {
                                            if (_mantenimiento.VerificaTulasManifiesto(ref _manifiesto))
                                            {
                                                archivo.writetext("Ingreso Deposito, Cliente en _manifiesto VerificaTulasManifiesto3: " + _manifiesto.Cliente.Nombre);
                                                archivo.writetext("Ingreso Deposito, Punto de venta en _manifiesto VerificaTulasManifiesto3: " + _manifiesto.PuntoVenta.Nombre);
                                                if (_mantenimiento.VerificaMontoManifiesto(ref _manifiesto) == 0)
                                                {
                                                    /*textomensaje = _mantenimiento.GeneraInformacionMontoManifiesto(ref _manifiesto);
                                                    frmPantallaResumenManifiestoPBV pantallaresumen = new frmPantallaResumenManifiestoPBV();
                                                    pantallaresumen.Tag = textomensaje;
                                                    pantallaresumen.ShowDialog();*/
                                                    cargarpantallaresumenmanifiesto("");
                                                    archivo.writetext("Ingreso Deposito, Cliente en _manifiesto cargarpantallaresumenmanifiesto5: " + _manifiesto.Cliente.Nombre);
                                                    archivo.writetext("Ingreso Deposito, Punto de venta en _manifiesto cargarpantallaresumenmanifiesto5: " + _manifiesto.PuntoVenta.Nombre);
                                                    //MessageBox.Show(textomensaje, "Resumen de Procesamiento", MessageBoxButtons.OK);
                                                    /*_mantenimiento.agregarProcesamientoBajoVolumenManifiesto(ref _procesamientobajovolumen, ref _manifiesto);
                                                    limpiardepositos(1);
                                                    if (port != null) port.Close();
                                                    conteoerrores = 0;
                                                    actualizarmanifiestopendiente();
                                                    MessageBox.Show("Se ha registrado de forma correcta la información del manifiesto en el sistema.");
                                                    _manifiesto = null;
                                                    this.Close();*/
                                                    cerrarmanifiesto();
                                                }
                                                else
                                                {
                                                    limpiardepositos(0);
                                                    conteoerrores += 1;
                                                    if (_manifiesto.Monto_Diferencia_Colones != 0)
                                                    {
                                                        MessageBox.Show("El monto del manifiesto en Colones no corresponde a la suma de todos los montos ingresados en los depósitos asociados");
                                                    }
                                                    if (_manifiesto.Monto_Diferencia_Dolares != 0)
                                                    {
                                                        MessageBox.Show("El monto del manifiesto en Dólares no corresponde a la suma de todos los montos ingresados en los depósitos asociados");
                                                    }
                                                    if (_manifiesto.Monto_Diferencia_Euros != 0)
                                                    {
                                                        MessageBox.Show("El monto del manifiesto en Euros no corresponde a la suma de todos los montos ingresados en los depósitos asociados");
                                                    }                                                    
                                                }
                                            }
                                            else
                                            {
                                                limpiardepositos(0);
                                                MessageBox.Show("La cantidad de Tulas ingresadas no corresponden a la cantidad de Tulas asociadas al manifiesto");
                                            }
                                        }
                                    }
                                    /*if (conteoerrores == 0)
                                    {
                                                                        
                                    }*/
                                }
                            }

                        }
                    }                    
                }
                datos = "";
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
                datos = "";
            }
        }      

        private void btnbilletesfalsos_Click(object sender, EventArgs e)
        {
            try
            {
                BindingList<BilleteFalso> listabilletefalso = new BindingList<BilleteFalso>();
                listabilletefalso = _deposito.BilletesFalsos;
                Monedas _monedadeposito = (Monedas)cboMonedaDeclarada.SelectedIndex;
                frmRegistroBilletesFalsos formulario = new frmRegistroBilletesFalsos(ref listabilletefalso, ref _colaborador, ref _monedadeposito);
                formulario.ShowDialog(this);
                datos = "";
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
                datos = "";
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                limpiardepositos(1);
                chkcierremanifiesto = 0;
                datos = "";
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
                datos = "";
            }            
        }

        private void nudCincuentamil_Leave(object sender, EventArgs e)
        {
            try
            {
                if (cancelact == 0)
                {
                    VerificaMonto = ValidarMontos(nud50000CRC.Value, 50000, nud50000CRC);
                }
                revisarprocesovacio();
            }
            catch (Exception ex)
            {
                MessageBox.Show("nudcincuentamil_leave error: " + ex.Message);
            }
        }

        private void nudCincomil_Leave(object sender, EventArgs e)
        {
            try
            {
                if (cancelact == 0)
                {
                    VerificaMonto = ValidarMontos(nud5000CRC.Value, 5000, nud5000CRC);
                }
                revisarprocesovacio();
            }
            catch (Exception ex)
            {
                MessageBox.Show("nudcincomil_leave error: " + ex.Message);
            }
        }

        private void nudVeintemil_Leave(object sender, EventArgs e)
        {
            try
            {
                if (cancelact == 0)
                {
                    VerificaMonto = ValidarMontos(nud20000CRC.Value, 20000, nud20000CRC);
                }
                revisarprocesovacio();
            }
            catch (Exception ex)
            {
                MessageBox.Show("nudveintemil_leave error: " + ex.Message);
            }
        }

        private void nudDosmil_Leave(object sender, EventArgs e)
        {
            try
            {
                if (cancelact == 0)
                {
                    VerificaMonto = ValidarMontos(nud2000CRC.Value, 2000, nud2000CRC);
                }
                revisarprocesovacio();
            }
            catch (Exception ex)
            {
                MessageBox.Show("nuddosmil_leave error: " + ex.Message);
            }
        }

        private void nudDiezmil_Leave(object sender, EventArgs e)
        {
            try
            {
                if (cancelact == 0)
                {
                    VerificaMonto = ValidarMontos(nud10000CRC.Value, 10000, nud10000CRC);
                }
                revisarprocesovacio();
            }
            catch (Exception ex)
            {
                MessageBox.Show("nuddiezmil_leave error: " + ex.Message);
            }
        }

        private void nudMil_Leave(object sender, EventArgs e)
        {
            try
            {
                if (cancelact == 0)
                {
                    VerificaMonto = ValidarMontos(nud1000CRC.Value, 1000, nud1000CRC);
                }
                revisarprocesovacio();
            }
            catch (Exception ex)
            {
                MessageBox.Show("nudmil_leave error: " + ex.Message);
            }
        }

        private void nudcincoeur_Leave(object sender, EventArgs e)
        {
            try
            {
                if (cancelact == 0)
                {
                    VerificaMonto = ValidarMontos(nud5EUR.Value, 5, nud5EUR);
                }
                revisarprocesovacio();
            }
            catch (Exception ex)
            {
                MessageBox.Show("nudcincoeur_leave error: " + ex.Message);
            }
        }

        private void nudcieneur_Leave(object sender, EventArgs e)
        {
            try
            {
                if (cancelact == 0)
                {
                    VerificaMonto = ValidarMontos(nud100EUR.Value, 100, nud100EUR);
                }
                revisarprocesovacio();
            }
            catch (Exception ex)
            {
                MessageBox.Show("nudcieneur_leave error: " + ex.Message);
            }
        }

        private void nuddiezeur_Leave(object sender, EventArgs e)
        {
            try
            {
                if (cancelact == 0)
                {
                    VerificaMonto = ValidarMontos(nud10EUR.Value, 10, nud10EUR);
                }
                revisarprocesovacio();
            }
            catch (Exception ex)
            {
                MessageBox.Show("nuddiezeur_leave error: " + ex.Message);
            }
        }

        private void nuddoscientoseur_Leave(object sender, EventArgs e)
        {
            try
            {
                if (cancelact == 0)
                {
                    VerificaMonto = ValidarMontos(nud200EUR.Value, 200, nud200EUR);
                }
                revisarprocesovacio();
            }
            catch (Exception ex)
            {
                MessageBox.Show("nuddoscientoseur_leave error: " + ex.Message);
            }
        }

        private void nudveinteeur_Leave(object sender, EventArgs e)
        {
            try
            {
                if (cancelact == 0)
                {
                    VerificaMonto = ValidarMontos(nud20EUR.Value, 20, nud20EUR);
                }
                revisarprocesovacio();
            }
            catch (Exception ex)
            {
                MessageBox.Show("nudveinteeur_leave error: " + ex.Message);
            }
        }

        private void nudquinientoseur_Leave(object sender, EventArgs e)
        {
            try
            {
                if (cancelact == 0)
                {
                    VerificaMonto = ValidarMontos(nud500EUR.Value, 500, nud500EUR);
                }
                revisarprocesovacio();
            }
            catch (Exception ex)
            {
                MessageBox.Show("nudquinientoseur_leave error: " + ex.Message);
            }
        }

        private void nudcincuentaeur_Leave(object sender, EventArgs e)
        {
            try
            {
                if (cancelact == 0)
                {
                    VerificaMonto = ValidarMontos(nud50EUR.Value, 50, nud50EUR);
                }
                revisarprocesovacio();
            }
            catch (Exception ex)
            {
                MessageBox.Show("nudcincuentaeur_leave error: " + ex.Message);
            }
        }

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
            try
            {
                if (cancelact == 0)
                {
                    VerificaMonto = ValidarMontos(nud20USD.Value, 20, nud20USD);
                }
                revisarprocesovacio();
            }
            catch (Exception ex)
            {
                MessageBox.Show("nudveinteusd_leave error: " + ex.Message);
            }
        }

        private void nudcincousd_Leave(object sender, EventArgs e)
        {
            try
            {
                if (cancelact == 0)
                {
                    VerificaMonto = ValidarMontos(nud5USD.Value, 5, nud5USD);
                }
                revisarprocesovacio();
            }
            catch (Exception ex)
            {
                MessageBox.Show("nudcincousd_leave error: " + ex.Message);
            }
        }

        private void nudcincuentausd_Leave(object sender, EventArgs e)
        {
            try
            {
                if (cancelact == 0)
                {
                    VerificaMonto = ValidarMontos(nud50USD.Value, 50, nud50USD);
                }
                revisarprocesovacio();
            }
            catch (Exception ex)
            {
                MessageBox.Show("nudcincuentausd_leave error: " + ex.Message);
            }
        }

        private void nuddiezusd_Leave(object sender, EventArgs e)
        {
            try
            {
                if (cancelact == 0)
                {
                    VerificaMonto = ValidarMontos(nud10USD.Value, 10, nud10USD);
                }
                revisarprocesovacio();
            }
            catch (Exception ex)
            {
                MessageBox.Show("nuddiezusd_leave error: " + ex.Message);
            }
        }

        private void nudcienusd_Leave(object sender, EventArgs e)
        {
            try
            {
                if (cancelact == 0)
                {
                    VerificaMonto = ValidarMontos(nud100USD.Value, 100, nud10USD);
                }
                revisarprocesovacio();
            }
            catch (Exception ex)
            {
                MessageBox.Show("nudcienusd_leave error: " + ex.Message);
            }
        }
        private void cboMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                datos = "";
                mostrarcamposmoneda(cboMoneda.SelectedIndex);
                sumarTotales();
                if (cboMonedaDeclarada.SelectedIndex != cboMoneda.SelectedIndex)
                {
                    epError.SetError(cboMoneda, "La moneda declarada es diferente a la moneda seleccionada");
                }
                else
                {
                    epError.SetError(cboMoneda, "");
                }
                if (!txtCtaReferencia.Text.Equals(""))
                {
                    long n;
                    bool isNumeric = long.TryParse(txtCtaReferencia.Text, out n);
                    if (isNumeric)
                    {
                        if (_mantenimiento.VerificaCuentaReferenciaDeposito(txtCtaReferencia.Text, (Monedas)cboMoneda.SelectedIndex, _manifiesto) == 0)
                        {
                            epError.SetError(txtCtaReferencia, "La cuenta referencia no corresponde a la moneda seleccionada o al Cliente y Punto de Venta asociado");
                            //txtCtaReferencia.Focus();
                        }
                        else
                        {
                            epError.SetError(txtCtaReferencia, "");
                        }
                    }
                    else
                    {
                        epError.SetError(txtCtaReferencia, "El formato del número de cuenta es incorrecto");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("cbomoneda_selectedindex error: " + ex.Message);
                datos = "";
            }
        }

        private void nudMontoDeclarado_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                epError.SetError(nudMontoDeclarado, "");
                sumarTotales();
                conteoerrores = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("nudmontodeclarado_valuechanged error: " + ex.Message);
            }
        }

        private void nudMontoNiquel_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                epError.SetError(nudMontoNiquel, "");
                conteoerrores = 0;
                origendiferenciadeposito = 1;
                sumarTotales();
            }
            catch (Exception ex)
            {
                MessageBox.Show("nudmontoniquel_valuechanged error: " + ex.Message);
            }
        }

        #endregion Eventos                                                                      
        

        #region Métodos Privados

        /// <summary>
        /// Imprimir los datos del cajero Niquel.
        /// </summary>
        private void imprimirBoletaCajeroNiquel(Cliente c, ProcesamientoBajoVolumenManifiesto m, Colaborador co, Tula t, Deposito d, int id)
        {

            try
            {
                DocumentoExcel documento = new DocumentoExcel(Application.StartupPath + "\\Plantillas\\plantilla boleta_niquel_cajero_niquel.xlsx", false);                

                documento.seleccionarHoja(1);

                //documento.seleccionarCelda("D2");
                //documento.actualizarValorCelda("BOLETA DE EFECTIVO No. " + Convert.ToString(id));

                documento.seleccionarCelda("C4");
                if (c != null)
                {
                    documento.actualizarValorCelda(c.Nombre + " " + m.PuntoVenta.ToString());
                }
                //danilo --
                documento.seleccionarCelda("F2");
                documento.actualizarValorCelda(DateTime.Today.ToString("dd/MM/yyyy"));
                // --
                documento.seleccionarCelda("C6");
                documento.actualizarValorCelda(co.Nombre + " " + co.Primer_apellido + " " + co.Segundo_apellido);

                documento.seleccionarCelda("C8");
                documento.actualizarValorCelda(d.CuentaReferencia);

                documento.seleccionarCelda("C10");
                documento.actualizarValorCelda(d.Monto.ToString());

                documento.seleccionarCelda("C12");
                documento.actualizarValorCelda(d.MontoNiquel.ToString());

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

        private void imprimirInconsistenciaDeposito(Cliente c, ProcesamientoBajoVolumenManifiesto m, Colaborador co, Tula t, Deposito d, DateTime pbv, byte origendiferencia)
        {

            try
            {
                DocumentoExcel documento = new DocumentoExcel(Application.StartupPath + "\\Plantillas\\plantilla Detalle_Inconsistencias_Tesoreria.xlsx", false);

                documento.seleccionarHoja(1);
                if (d.MontoDiferencia < 0)
                {
                    documento.seleccionarCelda("D9");
                }
                else
                {
                    documento.seleccionarCelda("I9");
                }
                documento.actualizarValorCelda("X");
                switch (d.Moneda)
                {
                    case Monedas.Colones:
                        documento.seleccionarCelda("D11");
                        break;
                    case Monedas.Dolares:
                        documento.seleccionarCelda("I11");
                        break;
                    default:
                        break;

                }
                documento.actualizarValorCelda("X");                

                //documento.seleccionarCelda("E15");
                if (c != null)
                {
                    //documento.actualizarValorCelda(c.Nombre + " " + m.PuntoVenta.ToString());
                    documento.llenarcuadrodetexto("Rectangle 13", c.Nombre + " " + m.PuntoVenta.ToString());
                }

                //documento.seleccionarCelda("L15");
                //documento.actualizarValorCelda(d.NumeroDeposito);
                documento.llenarcuadrodetexto("Rectangle 14", d.NumeroDeposito);

                //documento.seleccionarCelda("E17");
                documento.llenarcuadrodetexto("Rectangle 17", m.Codigo);
                //documento.actualizarValorCelda(m.Codigo);

                //documento.seleccionarCelda("L17");
                documento.llenarcuadrodetexto("Rectangle 15", t.Codigo);
                //documento.actualizarValorCelda(t.Codigo);

                //documento.seleccionarCelda("D19");
                documento.llenarcuadrodetexto("Rectangle 18", d.CuentaReferencia);
                //documento.actualizarValorCelda(d.CuentaReferencia);

                //documento.seleccionarCelda("H19");
                documento.llenarcuadrodetexto("Rectangle 16", m.Camara.ToString());
                //documento.actualizarValorCelda(m.Camara.ToString());

                //documento.seleccionarCelda("N19");
                documento.llenarcuadrodetexto("Rectangle 19", pbv.ToLongTimeString());
                //documento.actualizarValorCelda(pbv.ToLongTimeString());

                documento.seleccionarCelda("G33");
                documento.actualizarValorCelda(d.MontoDiferencia);

                documento.seleccionarCelda("C36");
                documento.actualizarValorCelda("Monto declarado por cliente: " + d.MontoDeclarado);

                documento.seleccionarCelda("C37");
                documento.actualizarValorCelda("Monto recibido: " + d.Monto);

                switch (origendiferencia)
                {
                    case 0:
                        documento.seleccionarCelda("D26"); //DIFERENCIA EN BILLETE
                        documento.actualizarValorCelda("X");
                        break;
                    case 1:
                        documento.seleccionarCelda("H26"); //DIFERENCIA EN MONEDA
                        documento.actualizarValorCelda("X");
                        break;
                    case 2:
                        documento.seleccionarCelda("D28"); //DIFERENCIA BILLETE FALSO
                        documento.actualizarValorCelda("X");
                        break;
                    case 3:
                        documento.seleccionarCelda("H28"); //DIFERENCIA CHEQUES
                        documento.actualizarValorCelda("X");
                        break;
                    case 4:
                        documento.seleccionarCelda("D30"); //DIFERENCIA EN SOBRES
                        documento.actualizarValorCelda("X");                                            
                        break;
                    default:
                        break;
                }

                if (d.BilletesFalsos != null)
                {
                    if (d.BilletesFalsos.Count > 0)
                    {
                        for (int i = 0; i < d.BilletesFalsos.Count; i++)
                        {
                            int j = 36;
                            if (i > 2)
                            {
                                break;
                            }
                            else
                            {
                                documento.seleccionarCelda("C" + Convert.ToString(j+i));
                                documento.actualizarValorCelda("Billete falso con No. Serie: " + d.BilletesFalsos[i].SerieBillete);
                            }
                        }
                    }
                }

                // Mostrar el archivo

                documento.mostrar();
                documento.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("imprimirinconsistenciadeposito error: " + ex.Message);
                //Excepcion.mostrarMensaje("ErrorExcel");
            }

        }

        public void actualizartula(Colaborador coordinador)
        {
            frmModificarTula formulario = new frmModificarTula(_colaborador, coordinador, _manifiesto);
            formulario.ShowDialog();
        }

        private void sumarTotales()
        {
            decimal totalDiferencia;
            decimal totalcheques = 0;
            //decimal totalbilletesfalso = 0;
            decimal totalcompraventa = 0;
            decimal totalniquel = 0;
            decimal totalcontado = 0;
            try
            {
                if (_deposito != null)
                {
                    /*if (_deposito.BilletesFalsos != null)
                    {
                        if (_deposito.BilletesFalsos.Count > 0)
                        {
                            foreach (BilleteFalso billetefalso in _deposito.BilletesFalsos)
                            {
                                totalbilletesfalso += billetefalso.denominacion.Valor;
                            }
                        }
                    }*/
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
                if (_deposito != null)
                {
                    _deposito.Monto = totalcontado;
                    _deposito.Moneda = (Monedas)cboMonedaDeclarada.SelectedIndex;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("sumartotales error: " + ex.Message);
            }
            //montodep = new MontoDeposito(denominacion: new Denominacion(moneda: ((Monedas)cboMonedaDeclarada.SelectedIndex)), cantidad_asignada: totalcontado);                        
        }

        private bool ValidarMontos(Decimal monto, Decimal denominacion, NumericUpDown t)
        {
            bool bStatus = true;
            try
            {
                if ((monto % denominacion) != 0)
                {
                    //if (epError.GetError(t).Contains("No se puede ingresar ese monto") == false)
                    //nuderror2 += 1;
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
                            epError.SetError(t, "");
                        }
                        /*if (nuderror2 > 0) 
                            nuderror2 -= 1;
                        /*else
                        {
                            if (epError.GetError(t).Equals("") == false)
                            nuderror2 -= 1;
                        }*/
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("validarmontos error: " + ex.Message);
                bStatus = false;
            }

            return bStatus;

        }        

        #endregion Métodos Privados

        public static string GetNumbers(string input)
        {
            try
            {
                return new string(input.Where(c => char.IsDigit(c)).ToArray());
            }            
            catch(Excepcion ex)
            {
                MessageBox.Show(ex.Message);
                return "";
            }
        }

        public Boolean revisarlimiteBD(Decimal limiteBD)
        {            
            return false;
        }

        public Boolean revisarlimiteAD(Decimal limiteAD)
        {
            return false;
        }

        public Boolean revisarlimiteDOL(Decimal limiteDOL)
        {
            return false;
        }
        

        public void actualizarlistachequesDeposito(BindingList<ChequeDeposito> listachequesdeposito)
        {
            try
            {
                _deposito.ChequeDeposito = listachequesdeposito;
                origendiferenciadeposito = 3;
                sumarTotales();
            }
            catch (Exception ex)
            {
                MessageBox.Show("actualizarlistachequesdeposito error: " + ex.Message);
            }
        }

        public void actualizarmontocontadoManifiesto(decimal Monto)
        {
            try
            {
                MontoContadoManifiesto = Monto;
            }
            catch(Excepcion ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }

        public void actualizarcompraventa(CompraVenta compraventa)
        {
            try
            {
                _deposito.CompraVenta = compraventa;
                if ((_deposito.CompraVenta.MontoNiquel > 0) && (_deposito.CompraVenta.MontoBillete == 0)) //Cambio GZH 21/11/2017
                { //Cambio GZH 21/11/2017
                    origendiferenciadeposito = 1; //Cambio GZH 21/11/2017
                } //Cambio GZH 21/11/2017
                else //Cambio GZH 21/11/2017
                { //Cambio GZH 21/11/2017
                    origendiferenciadeposito = 0; //Cambio GZH 21/11/2017
                } //Cambio GZH 21/11/2017
                sumarTotales();
            }
            catch (Exception ex)
            {
                MessageBox.Show("actualizarcompraventa error: " + ex.Message);
            }
        }
        public void actualizarbilletesfalsos(BindingList<BilleteFalso> listabilletefalso)
        {
            try
            {
                _deposito.BilletesFalsos = listabilletefalso;
                origendiferenciadeposito = 2;
                sumarTotales();
            }
            catch (Exception ex)
            {
                MessageBox.Show("actualizarbilletesfalsos error: " + ex.Message);
            }
        }

        public void limpiardepositos(byte tipo) //Cambio GZH 28/12/2017
        {
            try
            {
                txtNumDeposito.Text = "";
                txtCtaReferencia.Text = "";
                txtCodigoVD.Text = "";
                txtCedula.Text = "";
                if (cboTipoMesaNiquel.Items.Count > 0)
                    cboTipoMesaNiquel.SelectedIndex = 0;
                mostrarcamposmoneda(cboMoneda.SelectedIndex);
                if (cboTipoMesaNiquel.Items.Count > 0)
                    cboTipoMesaNiquel.SelectedIndex = 0;
                txtCodigoTransaccion.Text = "";
                _deposito = new Deposito(0);
                cboMoneda.SelectedIndex = (byte)Monedas.Colones;
                cboMonedaDeclarada.SelectedIndex = (byte)Monedas.Colones;
                _coordinador = 0;
                cancelact = 1;
                foreach (Control control in gbcolones.Controls)
                {
                    NumericUpDown numControls = control as NumericUpDown;
                    if (numControls != null)
                    {
                        numControls.Value = 0;
                        numControls.Tag = numControls.Value;
                        epError.SetError(numControls, "");
                    }
                }
                foreach (Control control in gbdolares.Controls)
                {
                    NumericUpDown numControls = control as NumericUpDown;
                    if (numControls != null)
                    {
                        numControls.Value = 0;
                        numControls.Tag = numControls.Value;
                        epError.SetError(numControls, "");
                    }
                }
                foreach (Control control in gbeuros.Controls)
                {
                    NumericUpDown numControls = control as NumericUpDown;
                    if (numControls != null)
                    {
                        numControls.Value = 0;
                        numControls.Tag = numControls.Value;
                        epError.SetError(numControls, "");
                    }
                }
                foreach (Control control in gbDatosDeposito.Controls)
                {
                    NumericUpDown numControls = control as NumericUpDown;
                    if (numControls != null)
                    {
                        numControls.Value = 0;
                        numControls.Tag = numControls.Value;
                        epError.SetError(numControls, "");
                    }
                }

                cancelact = 0;
                sumarTotales();
                txtMontoContado.Text = "0";
                txtDiferencia.Text = "0";
                chkcierremanifiesto = 1;
                origendiferenciadeposito = 0; //Cambio GZH 28/12/2017
                if (tipo == 1)
                {
                    txtNumero.Enabled = true;
                    txtNumero.Text = "";
                    txtNumero.Focus();
                    gbDatosDeposito.Enabled = false;
                    btnVerificar.Enabled = true;
                    btnCancelarTula.Enabled = true;
                    //btnmodificar.Enabled = true;
                    epError.SetError(btnextraerinfo, "");
                    _tula = new Tula("");
                    if (port != null)
                    {
                        if (port.IsOpen) port.Close();
                    }
                }
                else
                {
                    txtCodigoVD.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("limpiardepositos error: " + ex.Message);
            }
        }

        private void btnEntregaAV_Click(object sender, EventArgs e)
        {
            try
            {
                if (validaCampos())
                {
                    if (MessageBox.Show("¿Está seguro que desea realizar una entrega de alto volumen? Recuerde que requiere aprobación de coordinador/supervisor", "Confirmación de procesamiento", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        _deposito.MontoDeposito = this.añadirlistamontosdenominacion();
                        _tula.agregarDeposito(_deposito);
                        _manifiesto.agregarTula(_tula);
                        _procesamientobajovolumen.Camara = _manifiesto.Camara;
                        _procesamientobajovolumen.ColaboradorAsociado = _colaborador;
                        _procesamientobajovolumen.Fecha_Procesamiento = new DateTime();
                        _procesamientobajovolumen.Manifiesto = _manifiesto;
                        frmValidacionCoordinadorCE formulario = new frmValidacionCoordinadorCE(4, _colaborador, procesoBAV: _procesamientobajovolumen);
                        formulario.ShowDialog();
                        _mantenimiento.agregarProcesamientoBajoVolumen(ref _procesamientobajovolumen);
                        _mantenimiento.agregarProcesamientoBajoVolumenManifiesto(ref _manifiesto, _colaborador);
                        limpiardepositos(1);
                        this.Close();
                    }
                }
                datos = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnentregaAV_Click error: " + ex.Message);
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

        private void frmBajoVolumenIngresoDepositos_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (port != null)
                {
                    if (port.IsOpen)
                    {
                        port.Close();
                    }
                }
            }
            catch(Excepcion ex)
            {
                MessageBox.Show("Error cerrando puerto magner en el formulario Ingreso Depósitos" + ex.Message);
            }            
        }

        private void frmBajoVolumenIngresoDepositos_Load(object sender, EventArgs e)
        {
            //CheckForIllegalCrossThreadCalls = false;
            try
            {
                if (port == null)
                {
                    int i = 0;
                    var ports = SerialPort.GetPortNames().OrderByDescending(name => name);
                    foreach (var portName in ports)
                    {
                        i += 1;
                        nompuerto = portName;
                        break;
                    }
                    if (i > 0)
                    {
                        port = new SerialPort(nompuerto, 9600, Parity.None, 8, StopBits.One);
                        port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
                    }
                    else
                    {
                        port = null;
                        nompuerto = "";
                    }
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmbajovolumendepositos_load" + ex.Message);
                //Interaction.MsgBox(ex.Message);
            }
        }

        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string lecturapuerto;
            try
            {                
                lecturapuerto = port.ReadExisting();
                datos += lecturapuerto;
            } 
            catch(Exception ex)
            {
                MessageBox.Show("Error en lectura de puerto: " + ex.Message);
                if (port.IsOpen)
                {
                    port.Close();
                    MessageBox.Show("Debido al error en el puerto se acaba de cerrar el puerto, favor procese el depósito de forma manual indicando los montos en las denominaciones.");
                    //btnCancelar_Click(sender, e);
                }                
            }
            //if (datos.Contains("Total sum:"))
            //{
            //    ExtraeInformacionMagner();
            //}
        }

        public void permisocoordinador(int ID_Coordinador)
        {
            try
            {
                permisosup = true;
                _coordinador = ID_Coordinador;
            }
            catch(Excepcion ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }

        public void permisocoordinadorinconsistencia(int ID_Coordinador, string comentarios)
        {
            try
            {
                permisosup = true;
                _coordinador = ID_Coordinador;
                comentarioincons = comentarios;
            }
            catch(Excepcion ex)
            {
                MessageBox.Show(ex.Message);
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

        private string creacodigounico()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[8];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            return finalString;
        }

        private void txtCtaReferencia_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!txtCtaReferencia.Text.Equals(""))
                {
                    long n;
                    bool isNumeric = long.TryParse(txtCtaReferencia.Text, out n);
                    if (isNumeric)
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
                        epError.SetError(txtCtaReferencia, "El número de cuenta posee un formato incorrecto");
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

        private void actualizarmanifiestopendiente() {
            frmBajoVolumenIngresoManifiesto padre = (frmBajoVolumenIngresoManifiesto)this.Owner; //MANIFIESTO
            padre.actualizarmanifiestopendiente();
        }

        private void ExtraeInformacionMagner()
        {
            try
            {
                ArrayList arreglodatos = new ArrayList();
                int conteo = 0;
                int posicion = 0;
                int posicionant = 0;
                int i;
                string linea = "";
                //Interaction.MsgBox(datos);
                //MessageBox.Show(datos);
                if (!datos.Equals(string.Empty))
                {
                    archivo.writetext("Info de datos extraidos: " + datos);
                    foreach (char c in datos)
                    {
                        // Count c
                        if (c.Equals('\n'))//cambio de \r a \n
                        {
                            if (posicion != posicionant)
                            {
                                linea = datos.Substring((posicionant + 1), ((posicion) - (posicionant + 1)));
                                archivo.writetext("línea después de substring: " + linea);
                                posicionant = posicion;
                            }
                            if (!string.IsNullOrEmpty(linea.Trim()))
                            {
                                arreglodatos.Add(linea);
                                archivo.writetext("línea: " + linea);
                            }
                            conteo += 1;
                        }
                        posicion += 1;
                    }
                    //MessageBox.Show(datos);
                    if (datos.Contains("@@@ \0")) //magner 175 FF
                    {
                        for (i = 0; i <= arreglodatos.Count - 1; i++)
                        {

                            string infodatos = arreglodatos[i].ToString();
                            archivo.writetext("arreglodatos " + i.ToString() + ", Infodatos: " + infodatos);
                            if (i == 4)
                            {
                                if (infodatos.Contains("CRC"))
                                {
                                    cboMoneda.SelectedIndex = 0;
                                }
                                if (infodatos.Contains("USD"))
                                {
                                    cboMoneda.SelectedIndex = 1;
                                }
                                if (infodatos.Contains("EUR"))
                                {
                                    cboMoneda.SelectedIndex = 2;
                                }
                            }
                            if (infodatos.Length > 0)
                            {
                                if ((infodatos.Substring(0, 1) == "*") && (infodatos.Contains("None") == false) && (infodatos.Contains("TOTAL") == false))
                                {
                                    string[] words = infodatos.Split(' ');
                                    if (cboMoneda.SelectedIndex == 0)
                                    {
                                        for (int z = 0; z < words.Count(); z++)
                                        {
                                            if ((words[z].Equals(string.Empty) == false) && (words[z].Equals("*") == false))
                                            {
                                                words[0] = words[z].Replace(",", "") + "CRC";
                                                break;
                                            }
                                        }
                                        //words[0] = words[0].Substring(3, words[0].Length - 3) + words[0].Substring(0, 3);
                                        foreach (Control control in gbcolones.Controls)
                                        {
                                            NumericUpDown numControls = control as NumericUpDown;
                                            if (numControls != null)
                                            {
                                                if (numControls.Name.Contains(words[0]))
                                                {
                                                    words[words.Length - 1] = GetNumbers(words[words.Length - 1].Replace(",", ""));
                                                    if (!words[words.Length - 1].Equals("0"))
                                                    {
                                                        /*if (chksumarmonto.Checked == true)
                                                        {
                                                            numControls.Value += Convert.ToDecimal(words[words.Length - 1]);
                                                        }
                                                        else
                                                        {
                                                            numControls.Value = Convert.ToDecimal(words[words.Length - 1]);
                                                        }*/
                                                        numControls.Value = Convert.ToDecimal(words[words.Length - 1]);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    if (cboMoneda.SelectedIndex == 1)
                                    {
                                        //words[0] = words[0].Substring(3, words[0].Length - 3) + words[0].Substring(0, 3);
                                        for (int z = 0; z < words.Count(); z++)
                                        {
                                            if ((words[z].Equals(string.Empty) == false) && (words[z].Equals("*") == false))
                                            {
                                                words[0] = words[z].Replace(",", "") + "USD";
                                                break;
                                            }
                                        }
                                        //words[0] = words[4].Replace(",", "") + "USD";
                                        foreach (Control control in gbdolares.Controls)
                                        {
                                            NumericUpDown numControls = control as NumericUpDown;
                                            if (numControls != null)
                                            {
                                                if (numControls.Name.Contains(words[0]))
                                                {
                                                    words[words.Length - 1] = GetNumbers(words[words.Length - 1].Replace(",", ""));
                                                    if (!words[words.Length - 1].Equals("0"))
                                                    {
                                                        //numControls.Value = Convert.ToDecimal(words[words.Length - 1]);
                                                        /*if (chksumarmonto.Checked == true)
                                                        {
                                                            numControls.Value += Convert.ToDecimal(words[words.Length - 1]);
                                                        }
                                                        else
                                                        {
                                                            numControls.Value = Convert.ToDecimal(words[words.Length - 1]);
                                                        }*/
                                                        numControls.Value = Convert.ToDecimal(words[words.Length - 1]);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    if (cboMoneda.SelectedIndex == 2)
                                    {
                                        //words[0] = words[0].Substring(3, words[0].Length - 3) + words[0].Substring(0, 3);
                                        for (int z = 0; z < words.Count(); z++)
                                        {
                                            if ((words[z].Equals(string.Empty) == false) && (words[z].Equals("*") == false))
                                            {
                                                words[0] = words[z].Replace(",", "") + "EUR";
                                                break;
                                            }
                                        }
                                        //words[0] = words[4].Replace(",", "") + "EUR";
                                        foreach (Control control in gbeuros.Controls)
                                        {
                                            NumericUpDown numControls = control as NumericUpDown;
                                            if (numControls != null)
                                            {
                                                if (numControls.Name.Contains(words[0]))
                                                {
                                                    words[words.Length - 1] = GetNumbers(words[words.Length - 1].Replace(",", ""));
                                                    if (!words[words.Length - 1].Equals("0"))
                                                    {
                                                        numControls.Value = Convert.ToDecimal(words[words.Length - 1]);
                                                        /*if (chksumarmonto.Checked == true)
                                                        {
                                                            numControls.Value += Convert.ToDecimal(words[words.Length - 1]);
                                                        }
                                                        else
                                                        {
                                                            numControls.Value = Convert.ToDecimal(words[words.Length - 1]);
                                                        }*/
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }                            
                            //Interaction.MsgBox(arreglodatos(i));
                        }
                    }
                    else
                    {
                        for (i = 0; i <= arreglodatos.Count - 1; i++)
                        {

                            string infodatos = arreglodatos[i].ToString();
                            if (i == 5)
                            {
                                if (infodatos.Contains("CRC"))
                                {
                                    cboMoneda.SelectedIndex = 0;
                                }
                                if (infodatos.Contains("USD"))
                                {
                                    cboMoneda.SelectedIndex = 1;
                                }
                                if (infodatos.Contains("EUR"))
                                {
                                    cboMoneda.SelectedIndex = 2;
                                }
                            }
                            if ((infodatos.Contains("CRC")) || (infodatos.Contains("USD")) || (infodatos.Contains("EUR")))
                            {
                                string[] words = infodatos.Split(' ');
                                words[0] = words[0].Replace("'", "");
                                if (infodatos.Contains("CRC"))
                                {
                                    archivo.writetext("Words: " + words[0]);
                                    words[0] = words[0].Substring(3, words[0].Length - 3) + words[0].Substring(0, 3);
                                    archivo.writetext("Words después de substring: " + words[0]);
                                    foreach (Control control in gbcolones.Controls)
                                    {
                                        NumericUpDown numControls = control as NumericUpDown;
                                        if (numControls != null)
                                        {
                                            if (numControls.Name.Contains(words[0]))
                                            {
                                                words[words.Length - 1] = GetNumbers(words[words.Length - 1].Replace("'", ""));
                                                if (!words[words.Length - 1].Equals("0"))
                                                {
                                                    /*if (chksumarmonto.Checked == true)
                                                    {
                                                        numControls.Value += Convert.ToDecimal(words[words.Length - 1]);
                                                    }
                                                    else
                                                    {
                                                        numControls.Value = Convert.ToDecimal(words[words.Length - 1]);
                                                    }*/
                                                    numControls.Value = Convert.ToDecimal(words[words.Length - 1]);
                                                }
                                            }
                                        }
                                    }
                                }
                                if (infodatos.Contains("USD"))
                                {
                                    archivo.writetext("Words: " + words[0]);
                                    words[0] = words[0].Substring(3, words[0].Length - 3) + words[0].Substring(0, 3);
                                    archivo.writetext("Words después de substring: " + words[0]);
                                    foreach (Control control in gbdolares.Controls)
                                    {
                                        NumericUpDown numControls = control as NumericUpDown;
                                        if (numControls != null)
                                        {
                                            if (numControls.Name.Contains(words[0]))
                                            {
                                                words[words.Length - 1] = GetNumbers(words[words.Length - 1].Replace("'", ""));
                                                if (!words[words.Length - 1].Equals("0"))
                                                {
                                                    numControls.Value = Convert.ToDecimal(words[words.Length - 1]);
                                                    /*if (chksumarmonto.Checked == true)
                                                    {
                                                        numControls.Value += Convert.ToDecimal(words[words.Length - 1]);
                                                    }
                                                    else
                                                    {
                                                        numControls.Value = Convert.ToDecimal(words[words.Length - 1]);
                                                    }*/
                                                }
                                            }
                                        }
                                    }
                                }
                                if (infodatos.Contains("EUR"))
                                {
                                    archivo.writetext("Words: " + words[0]);
                                    words[0] = words[0].Substring(3, words[0].Length - 3) + words[0].Substring(0, 3);
                                    archivo.writetext("Words después de substring: "+ words[0]);
                                    foreach (Control control in gbeuros.Controls)
                                    {
                                        NumericUpDown numControls = control as NumericUpDown;
                                        if (numControls != null)
                                        {
                                            if (numControls.Name.Contains(words[0]))
                                            {
                                                words[words.Length - 1] = GetNumbers(words[words.Length - 1].Replace("'", ""));
                                                if (!words[words.Length - 1].Equals("0"))
                                                {
                                                    numControls.Value = Convert.ToDecimal(words[words.Length - 1]);
                                                    /*if (chksumarmonto.Checked == true)
                                                    {
                                                        numControls.Value += Convert.ToDecimal(words[words.Length - 1]);
                                                    }
                                                    else
                                                    {
                                                        numControls.Value = Convert.ToDecimal(words[words.Length - 1]);
                                                    }*/
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            //Interaction.MsgBox(arreglodatos(i));
                        }
                    }
                    //sumarTotales();
                }                
                datos = "";
                arreglodatos.Clear();                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de lectura de datos provenientes de magner: " + ex.Message + ", favor volver a procesar los billetes en la magner y presionar el botón de extracción");
                datos = "";
            }
        }

        private void btnextraerinfo_Click(object sender, EventArgs e)
        {
            ExtraeInformacionMagner();
        }

        private void nudMontoNiquel_MouseClick(object sender, MouseEventArgs e)
        {
            frmRegistroDenominacionesNiquel formulario = null;
            if (cboTipoMesaNiquel.SelectedItem.Equals("Mesa Níquel"))
            {
                formulario = new frmRegistroDenominacionesNiquel();
                formulario.ShowDialog(this);
            }
        }

        public void actualizarmontoNiquel(Decimal monto)
        {
            nudMontoNiquel.Value = monto;
        }

        public void actualizarconteoNiquel(ConteoNiquel cNiquel)
        {
            conteoNiquel = cNiquel;
        }

        private void revisarprocesovacio() {
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

        private void nudMontoDeclarado_Leave(object sender, EventArgs e)
        {
            revisarprocesovacio();
            txtCodigoVD.Text = "";
        /*if ((chklecturacodigo == 1))
            {
                nudMontoDeclarado.Focus();
                chklecturacodigo = 0;
            }
        }*/
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
            try
            {
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
                    /*case "8003":
                        cboMoneda.SelectedIndex = 0;
                        cboMonedaDeclarada.SelectedIndex = 0;
                        break;*/
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
                        txtCodigoTransaccion.Text = "";
                        break;
                }
            }
            catch (Excepcion ex)
            {
                MessageBox.Show("btncodigotransaccion_leave error: " + ex.Message);
            }
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
                if ((!txtCodigoTransaccion.Text.Equals(string.Empty)) && (contecodigoVDenter == 0))
                {
                    nudMontoDeclarado.Focus();
                    contecodigoVDenter = 1;
                }                    
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

        private void txtnumdeposito2_TextChanged(object sender, EventArgs e)
        {
            /*try
            {
                // if (txtNumDeposito.Text.Length == 4)
                if (chktab == 1)
                {
                    chktab = 0;
                    if ((tiempo < 3500) && (txtnumdeposito2.Text.Length > 10))
                    {
                        txtNumDeposito.Text = "";
                        numdeposito = txtnumdeposito2.Text.Substring(22, 9);
                        String codigotrans = txtnumdeposito2.Text.Substring(0, 4);
                        String ctaref = txtnumdeposito2.Text.Substring(4, 9);
                        String cedula = txtnumdeposito2.Text.Substring(31, 9);
                        txtCodigoTransaccion.Text = codigotrans;
                        txtCtaReferencia.Text = ctaref;
                        txtCedula.Text = cedula;
                        txtNumDeposito.Text = numdeposito;                        
                        txtnumdeposito2.Text = "";
                        System.Threading.Thread.Sleep(1000);
                        txtCodigoVD.Focus();
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

        private void txtCodigoVD_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Tab)
                    conteotabs += 1;
                if ((_manifiesto.Cliente.Id == 119) && (e.KeyCode == Keys.ShiftKey))
                    conteoshift += 1;
                if ((e.KeyCode == Keys.Left) || (e.KeyCode == Keys.Right) || (e.KeyCode == Keys.Delete) || (e.KeyCode == Keys.Back) || ((e.Modifiers == Keys.Shift) && (conteoshift == 0)) || (e.Modifiers == Keys.ControlKey))
                {
                    if (sw != null)
                    {
                        if (sw.IsRunning == true)
                        {
                            sw.Stop();
                            sw.Reset();
                            chktime = 0;
                            conteotabs = 0;
                            conteoshift = 0;
                        }
                        //nudMontoDeclarado.Focus();
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
                                conteoshift = 0;
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
                if (chktime == 0) {
                    FirstCharacterEntered();
                }                
                if ((txtCodigoVD.Text.Length > 0) && (txtCodigoVD.Text.Length < 48) && (e.KeyValue == 9) && (sw.ElapsedMilliseconds / txtCodigoVD.Text.Length > 250))
                {
                    nudMontoDeclarado.Focus();
                }
                if ((_manifiesto.Cliente.Id != 119) && (_manifiesto.Cliente.Id != 120))
                {
                    if (((txtCodigoVD.Text.Length == 48) && (e.KeyValue == 9)) || ((txtCodigoVD.Text.Length > 60) && (e.KeyValue == 9)))
                    {
                        if (sw != null)
                        {
                            if (sw.IsRunning == true)
                            {
                                chktab = 1;
                                conteoshift = 0;
                                sw.Stop();
                                tiempo = sw.ElapsedMilliseconds;
            txtCodigoVD.Text = txtCodigoVD.Text.Replace("\t", "");
                                chktime = 0;
nudMontoDeclarado.Focus();
                            }
                        }
                    }
                }
                else
                {
                    // if ((txtCodigoVD.Text.Length == 73) && (conteotabs == 7))
                    if ((txtCodigoVD.Text.Length > 72) && (conteotabs > 6))
                    {
                        if (sw != null)
                        {
                            if (sw.IsRunning == true)
                            {
                                chktab = 1;
                                conteoshift = 0;
                                sw.Stop();
                                tiempo = sw.ElapsedMilliseconds;
                                txtCodigoVD.Text = txtCodigoVD.Text.Replace("\t", "") + (char)e.KeyValue;
                                chktime = 0;                                
                                nudMontoDeclarado.Focus();
                                txtCodigoVD.Text = "";
                            }
                        }
                    }
                    else
                    {
                        if ((txtCodigoVD.Text.Length > 72) && (_manifiesto.Cliente.Id == 120)) //&& (conteotabs == 6) 
                        {
                            if (sw != null)
                            {
                                if (sw.IsRunning == true)
                                {
                                    chktab = 1;
                                    conteoshift = 0;
                                    sw.Stop();
                                    tiempo = sw.ElapsedMilliseconds;
                                    txtCodigoVD.Text = txtCodigoVD.Text.Replace("\t", "") + (char)e.KeyValue;
                                    chktime = 0;
                                    nudMontoDeclarado.Focus();
                                    txtCodigoVD.Text = "";
                                }
                            }
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

        private void txtCodigoVD_TextChanged(object sender, EventArgs e) //Cambios GZH 30/10/2017
        {
            bool result = false;
            long number = 0;
            try
            {
                // if (txtNumDeposito.Text.Length == 4)

                if (chktab == 1)
                {
                    chktab = 0;
                    if ((tiempo < 4500) && (txtCodigoVD.Text.Length > 10))
                    {
                        pdepositante = "";
                        if (_manifiesto.Cliente.Id == 67)
                        {
                            txtNumDeposito.Text = "";
                            numdeposito = txtCodigoVD.Text.Substring(txtCodigoVD.Text.Length - 21, 9);
                            String codigotrans = txtCodigoVD.Text.Substring(0, 4);
                            String ctaref = txtCodigoVD.Text.Substring(6, 9);
                            String cedula = txtCodigoVD.Text.Substring(txtCodigoVD.Text.Length - 9, 9);
                            txtCodigoTransaccion.Text = codigotrans;
                            txtCtaReferencia.Text = ctaref;
                            txtCedula.Text = cedula;
                            txtNumDeposito.Text = numdeposito;
                            txtCodigoVD.Text = "";
                            tiempo = 0;
                            nudMontoDeclarado.Focus();
                        }
                        else if ((_manifiesto.Cliente.Id == 119) || (_manifiesto.Cliente.Id == 120))
                        {
                            txtNumDeposito.Text = "";
                            numdeposito = txtCodigoVD.Text.Substring(txtCodigoVD.Text.Length - 31, 9);
                            String codigotrans = txtCodigoVD.Text.Substring(0, 4);
                            String ctaref = txtCodigoVD.Text.Substring(6, 9);
                            String cedula = txtCodigoVD.Text.Substring(txtCodigoVD.Text.Length - 9, 9);
			    pdepositante= txtCodigoVD.Text.Substring(txtCodigoVD.Text.Length - 22, 13);
                            txtCodigoTransaccion.Text = codigotrans;
                            txtCtaReferencia.Text = ctaref;
                            txtCedula.Text = cedula;
                            txtNumDeposito.Text = numdeposito;
                            txtCodigoVD.Text = "";
                            tiempo = 0;
                            nudMontoDeclarado.Focus();
                        } 
                        else {
                            txtNumDeposito.Text = "";                            
                            numdeposito = txtCodigoVD.Text.Substring(22, 9);                            
                            String codigotrans = txtCodigoVD.Text.Substring(0, 4);
                            String ctaref = txtCodigoVD.Text.Substring(4, 9);
                            String cedula = txtCodigoVD.Text.Substring(txtCodigoVD.Text.Length - 9, 9);
                            if ((txtCodigoVD.Text.Length - 9) != 31)
                                pdepositante = txtCodigoVD.Text.Substring(31, (txtCodigoVD.Text.Length - 9) - 31);
                            txtCodigoTransaccion.Text = codigotrans;
                            txtCtaReferencia.Text = ctaref;
                            txtCedula.Text = cedula;
                            txtNumDeposito.Text = numdeposito;
                            txtCodigoVD.Text = "";
                            tiempo = 0;
                            contecodigoVDenter = 0;
                            chklecturacodigo = 1;
                            nudMontoDeclarado.Focus();
                        }
                        txtCtaReferencia_Leave(sender, e);
                        txtCodigoTransaccion_Leave(sender, e);
                        result = Int64.TryParse(txtCedula.Text.Trim(), out number);
                        if (!result)
                        {                            
                            txtCedula.Text = "";
                        }
                        result = Int64.TryParse(txtNumDeposito.Text.Trim(), out number);
                        if (!result)
                        {
                            txtNumDeposito.Text = "";
                        }
                        /*if (Convert.ToInt32(txtCodigoTransaccion.Text.Trim()) == 0)
                        {
                            txtCodigoTransaccion.Text = "";
                        }*/

                        //chktab = 2;                                   
                        //MessageBox.Show(numdeposito);
                    }
                }
                epError.SetError(txtNumDeposito, "");
                conteoerrores = 0;
                //nudMontoDeclarado.Focus();
            }
            catch (Excepcion ex)
            {
                MessageBox.Show("Error txtNumDeposito text changed: " + ex.Message);
                nudMontoDeclarado.Focus();
            }
        }

        private void txtNumero_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                btnVerificar_Click(sender, e);
            }
        }

        private void nud1USD_Enter(object sender, EventArgs e)
        {
            nud1USD.Select(0, nud1USD.Text.Length);
        }

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

        private void nudMontoDeclarado_Enter(object sender, EventArgs e)
        {            
            nudMontoDeclarado.Select(0, nudMontoDeclarado.Text.Length);                        
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

        private void nudMontoDeclarado_Click(object sender, EventArgs e)
        {
            nudMontoDeclarado.Select(0, nudMontoDeclarado.Text.Length);
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

        private void nud1USD_Click(object sender, EventArgs e)
        {
            nud1USD.Select(0, nud1USD.Text.Length);
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

        private bool revisardenominacionesbillete()
        {
            bool retorno = true;
            switch (cboMoneda.SelectedIndex)
            {
                case 0:
                    foreach (Control control in gbcolones.Controls)
                    {
                        NumericUpDown numControls = control as NumericUpDown;
                        if (numControls != null)
                        {
                            if (epError.GetError(numControls).Equals("No se puede ingresar ese monto, tiene que ser en montos de acuerdo a la denominación asociada") == true)
                            //(epError.GetError(numControls).Equals("") == false)
                            {
                                retorno = false;
                                break;
                            }
                        }
                    }
                    break;
                case 1:
                    foreach (Control control in gbdolares.Controls)
                    {
                        NumericUpDown numControls = control as NumericUpDown;
                        if (numControls != null)
                        {
                            if (epError.GetError(numControls).Equals("No se puede ingresar ese monto, tiene que ser en montos de acuerdo a la denominación asociada") == true)
                                //(epError.GetError(numControls).Equals("") == false)
                            {
                                retorno = false;
                                break;
                            }
                        }
                    }
                    break;
                case 2:
                    foreach (Control control in gbeuros.Controls)
                    {
                        NumericUpDown numControls = control as NumericUpDown;
                        if (numControls != null)
                        {
                            if (epError.GetError(numControls).Equals("No se puede ingresar ese monto, tiene que ser en montos de acuerdo a la denominación asociada") == true)
                                //(epError.GetError(numControls).Equals("") == false)
                            {
                                retorno = false;
                                break;
                            }
                        }
                    }
                    break;
            }
            return retorno;
        }

        private void txtCtaReferencia_Enter(object sender, EventArgs e)
        {
            if (chklecturacodigo == 1)
            {                
                nudMontoDeclarado.Focus();
                chklecturacodigo = 0;
            }
if ((!pdepositante.Equals(string.Empty)) && (!txtCtaReferencia.Text.Equals(string.Empty)))
            {
                nudMontoDeclarado.Focus();
            }
        }

        private void nudMontoDeclarado_KeyDown(object sender, KeyEventArgs e)
        {
            /*if ((chklecturacodigo == 1) && (e.KeyCode == Keys.Tab))
            {
                nudMontoDeclarado.Focus();
                chklecturacodigo = 0;
            }*/
        }

        private void btnlimpiarinfodeposito_Click(object sender, EventArgs e)
        {
            try
            {
                if ((nud10000CRC.Value == 0) && (nud20000CRC.Value == 0) && (nud5000CRC.Value == 0) && (nud1000CRC.Value == 0) && (nud2000CRC.Value == 0)
                    && (nud1USD.Value == 0) && (nud5USD.Value == 0) && (nud10USD.Value == 0) && (nud20USD.Value == 0) && (nud50USD.Value == 0) && (nud100USD.Value == 0)
                    && (nud5EUR.Value == 0) && (nud10EUR.Value == 0) && (nud20EUR.Value == 0) && (nud50EUR.Value == 0) && (nud100EUR.Value == 0) && (nud200EUR.Value == 0)
                    && (nud500EUR.Value == 0))
                {
                    chkcierremanifiesto = 1;
                }
                else
                {
                    chkcierremanifiesto = 0;
                }
                txtCodigoVD.Text = string.Empty;
                txtCodigoTransaccion.Text = string.Empty;
                txtCedula.Text = string.Empty;
                txtCtaReferencia.Text = string.Empty;
                txtNumDeposito.Text = string.Empty;
                nudMontoDeclarado.Value = 0;
                nudMontoNiquel.Value = 0;
                txtCodigoVD.Focus();
                datos = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                datos = "";
            }
        }

        private void btnlimpiarden_Click(object sender, EventArgs e)
        {
            try
            {
                datos = "";
                nud1000CRC.Tag = Decimal.Parse("0");
                nud2000CRC.Tag = Decimal.Parse("0");
                nud5000CRC.Tag = Decimal.Parse("0");
                nud10000CRC.Tag = Decimal.Parse("0");
                nud20000CRC.Tag = Decimal.Parse("0");
                nud50000CRC.Tag = Decimal.Parse("0");
                nud1USD.Tag = Decimal.Parse("0");
                nud5USD.Tag = Decimal.Parse("0");
                nud10USD.Tag = Decimal.Parse("0");
                nud20USD.Tag = Decimal.Parse("0");
                nud50USD.Tag = Decimal.Parse("0");
                nud100USD.Tag = Decimal.Parse("0");
                nud5EUR.Tag = Decimal.Parse("0");
                nud10EUR.Tag = Decimal.Parse("0");
                nud20EUR.Tag = Decimal.Parse("0");
                nud50EUR.Tag = Decimal.Parse("0");
                nud100EUR.Tag = Decimal.Parse("0");
                nud200EUR.Tag = Decimal.Parse("0");
                nud500EUR.Tag = Decimal.Parse("0");                                                                                                                                                                                                                                       
                nud1000CRC.Value = 0;
                nud2000CRC.Value = 0;
                nud5000CRC.Value = 0;
                nud10000CRC.Value = 0;
                nud20000CRC.Value = 0;                
                nud50000CRC.Value = 0;
                nud1USD.Value = 0;                
                nud5USD.Value = 0;
                nud10USD.Value = 0;
                nud20USD.Value = 0;
                nud50USD.Value = 0;
                nud100USD.Value = 0;
                nud5EUR.Value = 0;
                nud10EUR.Value = 0;
                nud20EUR.Value = 0;
                nud50EUR.Value = 0;
                nud100EUR.Value = 0;
                nud200EUR.Value = 0;                                                                
                nud500EUR.Value = 0;
                epError.SetError(nud1000CRC, "");
                epError.SetError(nud2000CRC, "");
                epError.SetError(nud5000CRC, "");
                epError.SetError(nud10000CRC, "");
                epError.SetError(nud20000CRC, "");
                epError.SetError(nud50000CRC, "");
                epError.SetError(nud5EUR, "");
                epError.SetError(nud10EUR, "");
                epError.SetError(nud20EUR, "");
                epError.SetError(nud50EUR, "");
                epError.SetError(nud100EUR, "");
                epError.SetError(nud200EUR, "");
                epError.SetError(nud500EUR, "");
                epError.SetError(nud1USD, "");
                epError.SetError(nud5USD, "");
                epError.SetError(nud10USD, "");
                epError.SetError(nud20USD, "");
                epError.SetError(nud50USD, "");
                epError.SetError(nud100USD, "");
                if ((txtNumDeposito.Text.Equals("")) && (txtCedula.Text.Equals("")) && (txtCtaReferencia.Text.Equals("")) & (nudMontoDeclarado.Value == 0) 
                    && (txtCodigoTransaccion.Text.Equals("")) && (txtCodigoVD.Text.Equals("")))
                {
                    chkcierremanifiesto = 1;
                }
                else
                {
                    chkcierremanifiesto = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                datos = "";
            }
        }

        private void pbLogo_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (port != null)
                {
                    if (port.IsOpen) port.Close();
                }
                if (port != null)
                {
                    if (port.IsOpen == false) port.Open();
                    btnextraerinfo.Enabled = true;
                    lbldestadolector.BackColor = Color.Green;
                    //epError.SetError(btnextraerinfo, "");
                }
                else
                {
                    btnextraerinfo.Enabled = false;
                    lbldestadolector.BackColor = Color.Red;
                    //epError.SetError(btnextraerinfo, "El puerto del equipo Magner no se encuentra disponible, favor verificar que se encuentra conectado");
                }
                datos = "";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /*private void txtNumDeposito_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                chktab = 1;
            }
            else
            {
                chktab = 0;
            }
        }*/

        //danilo--
        private Boolean validaTXTNumOVacio(TextBox t)
        {
            //if texto vacio: inconsistencia
            Boolean condicion = t.Text == "" || Convert.ToInt32(t.Text) != 0;
            String msj = condicion ? "" : "Este espacio debe ser únicamente numérico";
            epError.SetError(t, msj);
            return condicion;
        }

        private Boolean validaCamposNumericos()
        {
            return validaTXTNumOVacio(txtCedula) && validaTXTNumOVacio(txtNumDeposito) && validaTXTNumOVacio(txtCtaReferencia) && validaTXTNumOVacio(txtCodigoTransaccion);
        }

        //--







    }
}
