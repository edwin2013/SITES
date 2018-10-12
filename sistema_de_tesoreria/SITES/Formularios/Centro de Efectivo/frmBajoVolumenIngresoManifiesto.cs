using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BussinessLayer;
using CommonObjects;
using LibreriaMensajes;
using CommonObjects.Clases;

namespace GUILayer.Formularios.Centro_de_Efectivo
{
    public partial class frmBajoVolumenIngresoManifiesto : Form
    {
         #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private BindingList<Camara> listacamara = new BindingList<Camara>();
        private ProcesamientoBajoVolumenManifiesto _manifiesto = null;
        private Colaborador _colaborador = null;
        private AtencionBL _atencion = AtencionBL.Instancia;
        private ProcesamientoBajoVolumen _procesobajovolumen = null;
        private Boolean permisosup = false;
        private Boolean _manifiestos_pendientes = false;
        private Boolean ingresoform = true;
        private Archivos archivo = null;
        TipoCambio _tipocambio = null;        

        #endregion Atributos

        #region Constructor

        public frmBajoVolumenIngresoManifiesto(Colaborador colaborador)
        {              
            InitializeComponent();
            archivo = new Archivos(@"c:\bitacora\bitacora" + colaborador.ID.ToString() + "-" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt");
            archivo.writetext("Inicia constructor frmBajoVolumenIngresoManifiesto");
            _colaborador = colaborador;
            _tipocambio = _mantenimiento.obtenerTipoCambio(DateTime.Today);
            if (_tipocambio == null)
            {
                MessageBox.Show("No se ha definido el tipo de cambio para trabajar hoy, favor ingresarlo para poder continuar");
                ingresoform = false;
            }
            listacamara = _mantenimiento.listarCamarasPorArea(Areas.CentroEfectivo);
            cboCamara.ListaMostrada = listacamara;
            cboCliente.ListaMostrada = _mantenimiento.listarClientes(string.Empty);
            _manifiesto = new ProcesamientoBajoVolumenManifiesto();
            ProcesamientoBajoVolumenManifiesto man = new ProcesamientoBajoVolumenManifiesto();
            man = _mantenimiento.VerificaManifiestoPendiente(_colaborador.ID);            
            _procesobajovolumen = _mantenimiento.listarProcesamientoBajoVolumenCajero(ref colaborador);            
            if (_procesobajovolumen != null)
            {
                archivo.writetext("Carga procesamiento bajo volumen existente. AD: " + _procesobajovolumen.MontoAD.ToString() + ", BD:" + _procesobajovolumen.MontoBD.ToString() + ",DOL:" +
                    _procesobajovolumen.MontoDOL.ToString() + ", EUR: " + _procesobajovolumen.MontoEUR.ToString() + ", COLTOT: " + _procesobajovolumen.MontoCOL.ToString());
                if ((_procesobajovolumen.Excedelimite == true) && (man == null))
                {
                    MessageBox.Show("El Procesamiento de Bajo Volumen ya alcanzó su límite de efectivo. Favor realizar un procesamiento de alto volumen");                    
                    frmEntregaBajoAltoVolumen formularioEntrega = new frmEntregaBajoAltoVolumen(ref _procesobajovolumen, ref _colaborador);
                    formularioEntrega.ShowDialog(this);
                    _procesobajovolumen = _mantenimiento.listarProcesamientoBajoVolumenCajero(ref colaborador);
                    archivo.writetext("Carga procesamiento bajo volumen existente. AD: " + _procesobajovolumen.MontoAD.ToString() + ", BD:" + _procesobajovolumen.MontoBD.ToString() + ",DOL:" +
                    _procesobajovolumen.MontoDOL.ToString() + ", EUR: " + _procesobajovolumen.MontoEUR.ToString() + ", COLTOT: " + _procesobajovolumen.MontoCOL.ToString());
                    if (_procesobajovolumen.Excedelimite)
                        ingresoform = false;
                }
            }                                    
            //formatoVentana();
        }

        /*private void formatoVentana()
        {
            cboMoneda.SelectedIndex = (byte)Monedas.Colones;
            //cboTipoMesaNiquel.SelectedIndex = (byte)Monedas.Colones;
        }*/

        #endregion Constructor       

        #region Eventos

        private void cboCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cliente cliente = (Cliente)cboCliente.SelectedItem;
            //if (cboCliente.SelectedIndex != -1)
            //{
            //    epError.SetError(cboCliente, "");
            //}
            archivo.writetext("Seleccion de cliente: " + cliente.Nombre);
            cboPuntoVenta.ListaMostrada = cliente.Puntos_venta;
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            try
            {
                if ((cboCamara.SelectedIndex < 0) || (cboCamara.SelectedItem.ToString().Contains("Todos")))
                {
                    epError.SetError(cboCamara, "Favor seleccionar alguna cámara adecuada para continuar.");
                }
                else
                {
                    Camara camara = (Camara)cboCamara.SelectedItem;
                    Cliente cliente = (Cliente)cboCliente.SelectedItem;
                    PuntoVenta puntoventa = (PuntoVenta)cboPuntoVenta.SelectedItem;

                    archivo.writetext("Ingreso Manifiesto, Cliente a procesar: " + cliente.Nombre);
                    archivo.writetext("Ingreso Manifiesto, Punto de venta a procesar: " + puntoventa.Nombre);
                    //Monedas moneda = (Monedas)cboMoneda.SelectedIndex;                    
                    decimal montocolones = (decimal)nudMontoCOL.Value;
                    decimal montodolares = (decimal)nudMontoUSD.Value;
                    decimal montoeuros = (decimal)nudMontoEUR.Value;

                    _manifiesto.Camara = camara;
                    _manifiesto.Cliente = cliente;
                    _manifiesto.PuntoVenta = puntoventa;
                    archivo.writetext("Ingreso Manifiesto, Cliente en _manifiesto a procesar: " + _manifiesto.Cliente.Nombre);
                    archivo.writetext("Ingreso Manifiesto, Punto de venta en _manifiesto a procesar: " + _manifiesto.PuntoVenta.Nombre);

                    //_manifiesto.Monedas = moneda;                        
                    _manifiesto.Monto_Colones = montocolones;
                    _manifiesto.Monto_Dolares = montodolares;
                    _manifiesto.Monto_Euros = montoeuros;
                    _manifiesto.Tulas = new BindingList<Tula>();                    
                    if (validaCampos())
                    {
                        if ((nudMontoCOL.Value != 0) || (nudMontoUSD.Value != 0) || (nudMontoEUR.Value != 0))
                        {
                            if (_manifiestos_pendientes == false)
                            {
                                archivo.writetext("Crea nuevo registro de procesamiento bajo volumen manifiesto");
                                archivo.writetext("Ingreso Manifiesto, Cliente en _manifiesto a agregarProcesamientoBajoVolumenManifiesto: " + _manifiesto.Cliente.Nombre);
                                archivo.writetext("Ingreso Manifiesto, Punto de venta en _manifiesto a agregarProcesamientoBajoVolumenManifiesto: " + _manifiesto.PuntoVenta.Nombre);
                                _mantenimiento.agregarProcesamientoBajoVolumenManifiesto(ref _manifiesto, _colaborador);
                                archivo.writetext("Crea registro de pendiente de procesamientobajovolumenmanifiesto");
                                _mantenimiento.agregarPendienteProcesamientoBajoVolumenManifiesto(ref _manifiesto, ref _colaborador);
                                _manifiestos_pendientes = true;
                            }
                            else
                            {
                                archivo.writetext("Ingreso Manifiesto, Cliente en _manifiesto actualizarProcesamientoBajoVolumenManifiesto: " + _manifiesto.Cliente.Nombre);
                                archivo.writetext("Ingreso Manifiesto, Punto de venta en _manifiesto actualizarProcesamientoBajoVolumenManifiesto: " + _manifiesto.PuntoVenta.Nombre);
                                _mantenimiento.actualizarProcesamientoBajoVolumenManifiesto(ref _manifiesto);
                                archivo.writetext("Actualiza registro de procesamiento bajo volumen manifiesto");
                            }
                            frmBajoVolumenIngresoDepositos formulario = new frmBajoVolumenIngresoDepositos(ref _manifiesto, ref _procesobajovolumen, _manifiestos_pendientes, ref _colaborador);
                            formulario.ShowDialog(this);
                            if (_manifiesto == null)
                            {
                                _manifiestos_pendientes = false;
                                if (_procesobajovolumen != null)
                                {
                                    
                                    _procesobajovolumen = _mantenimiento.listarProcesamientoBajoVolumenCajero(ref _colaborador);

                                    while (_procesobajovolumen.Excedelimite)
                                    {
                                        archivo.writetext("Procesamiento bajo volumen excede límite, hora de realizar entrega");
                                        _procesobajovolumen.Camara = (Camara)cboCamara.SelectedItem;
                                        frmEntregaBajoAltoVolumen formularioEntrega = new frmEntregaBajoAltoVolumen(ref _procesobajovolumen, ref _colaborador);
                                        formularioEntrega.ShowDialog(this);
                                        _procesobajovolumen = _mantenimiento.listarProcesamientoBajoVolumenCajero(ref _colaborador);
                                    }
                                    //if (_procesobajovolumen.Excedelimite == true)
                                    //{
                                    //    archivo.writetext("Procesamiento bajo volumen excede límite, hora de realizar entrega");
                                    //    _procesobajovolumen.Camara = (Camara)cboCamara.SelectedItem;
                                    //    frmEntregaBajoAltoVolumen formularioEntrega = new frmEntregaBajoAltoVolumen(ref _procesobajovolumen, ref _colaborador);
                                    //    formularioEntrega.ShowDialog(this);
                                    //    _procesobajovolumen = _mantenimiento.listarProcesamientoBajoVolumenCajero(ref _colaborador);                                        
                                    //}
                                }                                
                                limpiarcampos();
                                _manifiesto = new ProcesamientoBajoVolumenManifiesto();
                            }
                        }
                        else
                        {
                            frmValidacionCoordinadorCE formulario = new frmValidacionCoordinadorCE(6, _colaborador);
                                formulario.ShowDialog(this);
                                if (permisosup)
                                {
                                    if (_manifiestos_pendientes == false)
                                    {
                                        archivo.writetext("Ingreso Manifiesto, Cliente en _manifiesto _manifiestos_pendientes == false validacion coordinador: " + _manifiesto.Cliente.Nombre);
                                        archivo.writetext("Ingreso Manifiesto, Punto de venta en _manifiesto _manifiestos_pendientes == false validacion coordinador: " + _manifiesto.PuntoVenta.Nombre);
                                        _mantenimiento.agregarPendienteProcesamientoBajoVolumenManifiesto(ref _manifiesto, ref _colaborador);
                                    }
                                    frmBajoVolumenIngresoDepositos formulario2 = new frmBajoVolumenIngresoDepositos(ref _manifiesto, ref _procesobajovolumen, _manifiestos_pendientes, ref _colaborador);
                                    formulario2.ShowDialog(this);
                                    if (_manifiesto == null)
                                    {
                                        _manifiestos_pendientes = false;
                                        if (_procesobajovolumen != null)
                                        {
                                            if (_procesobajovolumen.Excedelimite == true)
                                            {
                                                _procesobajovolumen.Camara = (Camara)cboCamara.SelectedItem;
                                                frmEntregaBajoAltoVolumen formularioEntrega = new frmEntregaBajoAltoVolumen(ref _procesobajovolumen, ref _colaborador);
                                                formularioEntrega.ShowDialog(this);
                                                _procesobajovolumen = _mantenimiento.listarProcesamientoBajoVolumenCajero(ref _colaborador);
                                            }
                                        }                                        
                                        limpiarcampos();
                                        _manifiesto = new ProcesamientoBajoVolumenManifiesto();
                                    }
                                }
                        }
                    }
                    archivo.writetext("Carga procesamiento bajo volumen existente. AD: " + _procesobajovolumen.MontoAD.ToString() + ", BD:" + _procesobajovolumen.MontoBD.ToString() + ",DOL:" +
                    _procesobajovolumen.MontoDOL.ToString() + ", EUR: " + _procesobajovolumen.MontoEUR.ToString() + ", COLTOT: " + _procesobajovolumen.MontoCOL.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnProcesar error: " + ex.Message);
                //falta agregar excepción
            }
        }

        private void frmBajoVolumenIngresoManifiesto_Load(object sender, EventArgs e)
        {
            try
            {
                if (ingresoform == true)
                {
                    ProcesamientoBajoVolumenManifiesto man = new ProcesamientoBajoVolumenManifiesto();
                    man = _mantenimiento.VerificaManifiestoPendiente(_colaborador.ID);
                    archivo.writetext("Verifica manifiestos pendientes de procesar...");
                    if (man != null)
                    {
                        _manifiestos_pendientes = true;
                        _manifiesto = man;
                        archivo.writetext("Ingreso Manifiesto, Cliente en _manifiesto frmBajoVolumenIngresoManifiesto_Load: " + _manifiesto.Cliente.Nombre);
                        archivo.writetext("Ingreso Manifiesto, Punto de venta en _manifiesto frmBajoVolumenIngresoManifiesto_Load: " + _manifiesto.PuntoVenta.Nombre);
                        txtNumero.Text = _manifiesto.Codigo;
                        nudMontoCOL.Value = _manifiesto.Monto_Colones;
                        nudMontoUSD.Value = _manifiesto.Monto_Dolares;
                        nudMontoEUR.Value = _manifiesto.Monto_Euros;
                        cboCamara.SelectedItem = _manifiesto.Camara;
                        cboCliente.SelectedItem = _manifiesto.Cliente;
                        //cboMoneda.SelectedIndex = (byte)_manifiesto.Monedas;
                        cboPuntoVenta.SelectedItem = _manifiesto.PuntoVenta;
                        archivo.writetext("Hay un manifiesto pendiente de procesar...(" + txtNumero.Text + ")");
                    }
                    else
                    {
                        _manifiestos_pendientes = false;
                        archivo.writetext("No hay manifiestos pendientes de procesar...");
                    }
                }
                else
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmbajovolumenIngresoManifiesto_Load error: " + ex.Message);
                //falta agregar excepción
            }
        }

        private void btnmodificar_Click(object sender, EventArgs e)
        {
            try
            {                
                frmValidacionCoordinadorCE formulario = new frmValidacionCoordinadorCE(1, _colaborador); //1 = MANIFIESTO
                formulario.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnmodificar error: " + ex.Message);
                //falta agregar excepción
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("btncancelar error: " + ex.Message);
                //falta agregar excepción
            }
        }

        private void cboCamara_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboCamara.SelectedIndex != -1)
                {
                    epError.SetError(cboCamara, "");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("cboCamara_SelectedIndexChanged error: " + ex.Message);
            }
        }

        private void txtNumero_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtNumero.Text != "")
                {
                    epError.SetError(txtNumero, "");
                    string codigo = txtNumero.Text;
                    _manifiesto.Codigo = codigo;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("txtNumero_TextChanged error: " + ex.Message);
            }
        }

        private void nudMonto_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (nudMontoCOL.Value != 0)
                {
                    epError.SetError(nudMontoCOL, "");
                    epError.SetError(nudMontoUSD, "");
                    epError.SetError(nudMontoEUR, "");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("nudMonto_ValueChanged error: " +  ex.Message);
            }
        }

        private bool ValidarMontos(Decimal monto, Decimal denominacion, NumericUpDown t)
        {
            bool bStatus = true;
            if ((monto % denominacion) != 0)
            {
                epError.SetError(t, "No se puede ingresar ese monto");
                bStatus = false;
            }
            else
                epError.SetError(t, "");


            return bStatus;

        }

        private void nudMonto_Leave(object sender, EventArgs e)
        {
            ValidarMontos(nudMontoCOL.Value, 1, nudMontoCOL);
        }

        private void cboPuntoVenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboPuntoVenta.SelectedIndex != -1)
                {
                    epError.SetError(cboPuntoVenta, "");                   
                    archivo.writetext("Ingreso Manifiesto, Punto de venta en cboPuntoVenta_SelectedIndexChanged: " + cboPuntoVenta.SelectedItem.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("cbopuntoventa_selectedindexchanged error: " + ex.Message);
            }
        }

        #endregion Eventos        

        #region Métodos Privados

        public void actualizarmanifiesto(Colaborador coordinador)
        {
            frmModificarManifiesto formulario = new frmModificarManifiesto(_colaborador, coordinador);
            formulario.ShowDialog();
        }

        public void actualizarmanifiestopendiente()
        {
            _manifiesto = null;
        }

        private Boolean validaCampos()
        {
            try
            {
                if (_manifiesto.Camara == null)
                {
                    epError.SetError(cboCamara, "Favor seleccionar una cámara");
                    return false;
                }
                if (_manifiesto.Codigo == "" || _manifiesto.Codigo == null)
                {
                    epError.SetError(txtNumero, "No se puede ingresar ese codigo de manifiesto");
                    return false;
                }
                /*if (_manifiesto.Monedas == null)
                {
                    epError.SetError(cboMoneda, "Favor seleccionar una moneda");
                    return false;
                }*/
                if ((_manifiesto.Monto_Colones == 0) && (_manifiesto.Monto_Dolares == 0) && (_manifiesto.Monto_Euros == 0))
                {
                    epError.SetError(nudMontoCOL, "No hay monto registrado");
                    epError.SetError(nudMontoUSD, "No hay monto registrado");
                    epError.SetError(nudMontoEUR, "No hay monto registrado");
                    return false;
                }
                if (_manifiesto.Cliente == null)
                {
                    epError.SetError(cboCliente, "Favor seleccionar un Cliente");
                    return false;
                }
                if (_manifiesto.PuntoVenta == null)
                {
                    epError.SetError(cboPuntoVenta, "Favor seleccionar un punto de venta");
                    return false;
                }                                                
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("validacampos" + ex.Message);
                return false;
            }                        
        }

        #endregion Métodos Privados

        public void permisocoordinador(int ID_Coordinador)
        {
            permisosup = true;            
        }
 
        private void limpiarcampos()
        {
            nudMontoCOL.Value = 0;
            nudMontoEUR.Value = 0;
            nudMontoUSD.Value = 0;
            txtNumero.Text = "";
        }

        private void txtNumero_Leave(object sender, EventArgs e)
        {
            if (txtNumero.Text != "")   
            {
                if (_manifiesto.Cliente != null)
                {
                    archivo.writetext("Ingreso Manifiesto, Cliente en _manifiesto txtNumero_Leave1: " + _manifiesto.Cliente.Nombre.ToString());
                    if (_manifiesto.PuntoVenta != null)
                        archivo.writetext("Ingreso Manifiesto, Punto de venta en _manifiesto txtNumero_Leave1: " + _manifiesto.PuntoVenta.Nombre);
                }                
                if (_atencion.VerificarManifiestoExiste(ref _manifiesto, _manifiestos_pendientes) == false)
                {
                    //archivo.writetext("Ingreso Manifiesto, Cliente en _manifiesto txtNumero_Leave2: " + _manifiesto.Cliente.Nombre);
                    //archivo.writetext("Ingreso Manifiesto, Punto de venta en _manifiesto txtNumero_Leave2: " + _manifiesto.PuntoVenta.Nombre.ToString());
                    if (_manifiestos_pendientes == false)
                    {
                        epError.SetError(txtNumero, "El manifiesto indicado no existe en el sistema");
                        _manifiesto.Codigo = "";
                    }
                    else
                    {
                        epError.SetError(txtNumero, "");
                    }

                }
                else
                {
                    epError.SetError(txtNumero, "");
                }
            }
        }

        private void nudMontoUSD_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (nudMontoUSD.Value != 0)
                {
                    epError.SetError(nudMontoCOL, "");
                    epError.SetError(nudMontoUSD, "");
                    epError.SetError(nudMontoEUR, "");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("nudmontousd_valuechanged error: " + ex.Message);
            }
        }

        private void nudMontoEUR_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (nudMontoEUR.Value != 0)
                {
                    epError.SetError(nudMontoCOL, "");
                    epError.SetError(nudMontoUSD, "");
                    epError.SetError(nudMontoEUR, "");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("nudmontoeur_valuechanged error: " + ex.Message);
            }
        }

        private void nudMontoCOL_Click(object sender, EventArgs e)
        {
            nudMontoCOL.Select(0, nudMontoCOL.Text.Length);
        }

        private void nudMontoCOL_Enter(object sender, EventArgs e)
        {
            nudMontoCOL.Select(0, nudMontoCOL.Text.Length);
        }

        private void btnEntregaAV_Click(object sender, EventArgs e)
        {
            try
            {
                frmValidacionCoordinadorCE formulario = new frmValidacionCoordinadorCE(10, _colaborador, procesoBAV: _procesobajovolumen);
                formulario.ShowDialog();                
                _procesobajovolumen = _mantenimiento.listarProcesamientoBajoVolumenCajero(ref _colaborador);
            }
            catch(Excepcion ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
