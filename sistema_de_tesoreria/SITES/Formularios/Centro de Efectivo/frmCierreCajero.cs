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
using LibreriaReportesOffice;
using CommonObjects.Clases;

namespace GUILayer.Formularios.Centro_de_Efectivo
{
    public partial class frmCierreCajero : Form
    {


        #region Atributos

        private AtencionBL _atencion = AtencionBL.Instancia;
        private SeguridadBL _seguridad = SeguridadBL.Instancia;
        private Colaborador _colaborador = null;
        private int _coordinador = 0;
        private byte tipocajero = 0;
        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;
        private DataTable datoscierre;
        private DataTable datosniquel;
        private DateTime _fecha;
        private Boolean permisosup = false;
        private int perfil = 0;
        private CierreCajeroPROA _cierre = null;
        private short canttulas = 0;
        private short cantcheques = 0;
        private DocumentoExcel documento = null;
        private short cantdepositos = 0;
        private bool seleccionarcajero = false;
        Decimal ntotalniquel = 0;
        private TipoCambio _tipo_cambio_impresion;
        BindingList<BoletaMesaNiquel> listaboletas = new BindingList<BoletaMesaNiquel>();
        private int chkcoordinador = 0;
        //private BindingList<Colaborador> listacajero = new BindingList<Colaborador>();

        #endregion Atributos

        #region Constructor

        public frmCierreCajero(Colaborador colaborador)
        {
            InitializeComponent();
            cboMoneda.Enabled = false;
            nudMonto.Enabled = false;
            nudNiquel.Enabled = false;
            chkcoordinador = 0;
            //listacajero = _seguridad.listarColaboradoresPorPuestoArea(Areas.CentroEfectivo, Puestos.CajeroA, Puestos.CajeroB, Puestos.CajeroC);
            cboCoordinador.ListaMostrada = _seguridad.listarColaboradoresPorPuestoArea(Areas.CentroEfectivo, Puestos.Coordinador);
            cboCoordinadorImpresion.ListaMostrada = _seguridad.listarColaboradoresPorPuestoArea(Areas.CentroEfectivo, Puestos.Coordinador);
            cboDigitador.ListaMostrada = _seguridad.listarColaboradoresPorPuestoArea(Areas.CentroEfectivo, Puestos.Digitador);
            cboDigitadorMontos.ListaMostrada = _seguridad.listarColaboradoresPorPuestoArea(Areas.CentroEfectivo, Puestos.Digitador);
            cboImpresionDigitador.ListaMostrada = _seguridad.listarColaboradoresPorPuestoArea(Areas.CentroEfectivo, Puestos.Digitador);
            cboImpresionCajero.ListaMostrada = _seguridad.listarColaboradoresPorPuestoArea(Areas.CentroEfectivo, Puestos.CajeroA, Puestos.CajeroB, Puestos.CajeroC, Puestos.CajeroD, Puestos.CajeroE);
            cboCajero.ListaMostrada = _seguridad.listarColaboradoresPorPuestoArea(Areas.CentroEfectivo, Puestos.CajeroA, Puestos.CajeroB, Puestos.CajeroC, Puestos.CajeroD, Puestos.CajeroE);
            cboCajeroMontos.ListaMostrada = _seguridad.listarColaboradoresPorPuestoArea(Areas.CentroEfectivo, Puestos.CajeroA, Puestos.CajeroB, Puestos.CajeroC, Puestos.CajeroD, Puestos.CajeroE);
            dgvConsolidado.Rows.Clear();
            crearTablaConsolidado(dgvConsolidado, 0);
            btnAñadirSI.Enabled = false;            
            this.crearTabla(dgvCierre, 0);
            _colaborador = colaborador;
            _coordinador = _colaborador.ID;
            foreach (Perfil perfil in _colaborador.Perfiles)
            {
                //if ((perfil.ID == 46) || (perfil.ID == 50) || (perfil.ID == 53) || (perfil.ID == 54) || (perfil.ID == 56) || (perfil.ID == 59)) //produccion descomentar
                if ((perfil.ID == 50) || (perfil.ID == 53) || (perfil.ID == 56) || (perfil.ID == 59))  //comentar para produccion
                {
                    btnGuardar.Visible = true;
                    cboCoordinador.SelectedItem = _colaborador;
                    //cboCoordinador.Enabled = false;
                    break;
                }                
            }

            this.obtenerTipoCambioImpresion();
            this.actualizarListaCierres();
            chkcoordinador = 1;


        }

        #endregion Constructor       

        #region Eventos

        private void btnSalir_Click(object sender, EventArgs e)
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

        private void btnSaldoInicial_Click(object sender, EventArgs e)
        {
            try
            {                
                frmValidacionCoordinadorCE formulario = new frmValidacionCoordinadorCE(3, _colaborador);
                formulario.ShowDialog(this);
                if (permisosup == true)
                {
                    cboMoneda.Enabled = true;
                    cboMoneda.SelectedIndex = 0;
                    //nudMonto.Enabled = true;
                    //nudNiquel.Enabled = true;
                    btnAñadirSI.Enabled = true;
                    permisosup = false;
                }
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }            
        }

        #endregion Eventos        

        private void frmCierreCajero_Load(object sender, EventArgs e)
        {
            dtpFecha_ValueChanged(sender, e);
        }

        private Decimal calculartotalniquel()
        {
            Decimal total = 0;
            foreach (BoletaMesaNiquel nboleta in listaboletas)
            {
                total += nboleta.MontoNiquel;
            }
            return total;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            listaboletas = _atencion.ObtenerInfoFormularioBoletaNiquelMesa((Colaborador)cboCajero.SelectedItem);
            ntotalniquel = calculartotalniquel();
            if ((cboCajero.SelectedIndex > -1) && (cboCoordinador.SelectedIndex > -1) && (cboDigitador.SelectedIndex > -1) && ntotalniquel == 0)
            {
                guardarinfocierre(tipocajero);
                this.actualizarListaCierres();
            }                
            else
            {
                if (cboCajero.SelectedIndex == -1)
                    epError.SetError(cboCajero, "No ha seleccionado cajero.");
                if (cboCoordinador.SelectedIndex == -1)
                    epError.SetError(cboCoordinador, "No ha seleccionado coordinador.");
                if (cboDigitador.SelectedIndex == -1)
                    epError.SetError(cboDigitador, "No ha seleccionado digitador.");
                if (ntotalniquel != 0)
                {
                    epError.SetError(cboCajero, "El cajero tiene pendiente la entrega de niquel.");
                }
            }
        }        

        #region Métodos Privados

        private void guardarinfocierre(byte tipocajero)
        {
            CierreCajeroPROA cierrecajero;
            if (tipocajero == 0)
            {
                cierrecajero = new CierreCajeroPROA(cajero: (Colaborador)cboCajero.SelectedItem, digitador: (Colaborador)cboDigitador.SelectedItem, 
                    coordinador: (Colaborador)cboCoordinador.SelectedItem);
                cierrecajero.Total_Suma_Manifiestos_Colones = Convert.ToDecimal(dgvCierre.Rows[1].Cells[1].Value);
                cierrecajero.Total_Suma_Manifiestos_dolares = Convert.ToDecimal(dgvCierre.Rows[1].Cells[2].Value);
                cierrecajero.Total_Suma_Manifiestos_euros = Convert.ToDecimal(dgvCierre.Rows[1].Cells[3].Value);
                cierrecajero.Cheques_locales_colones = Convert.ToDecimal(dgvCierre.Rows[2].Cells[1].Value);
                cierrecajero.Cheques_exterior_colones = Convert.ToDecimal(dgvCierre.Rows[3].Cells[1].Value);
                cierrecajero.Cheques_bac_colones = Convert.ToDecimal(dgvCierre.Rows[4].Cells[1].Value);
                cierrecajero.Cheques_locales_dolares = Convert.ToDecimal(dgvCierre.Rows[2].Cells[2].Value);
                cierrecajero.Cheques_exterior_dolares = Convert.ToDecimal(dgvCierre.Rows[3].Cells[2].Value);
                cierrecajero.Cheques_bac_dolares = Convert.ToDecimal(dgvCierre.Rows[4].Cells[2].Value);
                cierrecajero.Cheques_locales_euros = Convert.ToDecimal(dgvCierre.Rows[2].Cells[3].Value);
                cierrecajero.Cheques_exterior_euros = Convert.ToDecimal(dgvCierre.Rows[3].Cells[3].Value);
                cierrecajero.Cheques_bac_euros = Convert.ToDecimal(dgvCierre.Rows[4].Cells[3].Value);
                /*if (cboCoordinador.SelectedIndex > -1)
                    cierrecajero.Coordinador = (Colaborador)cboCoordinador.SelectedItem;*/
                cierrecajero.Faltante_clientes_colones = Convert.ToDecimal(dgvCierre.Rows[13].Cells[1].Value);
                cierrecajero.Faltante_clientes_dolares = Convert.ToDecimal(dgvCierre.Rows[13].Cells[2].Value);
                cierrecajero.Faltante_clientes_euros = Convert.ToDecimal(dgvCierre.Rows[13].Cells[3].Value);
                cierrecajero.Faltante_quinientos_colones = Convert.ToDecimal(dgvCierre.Rows[15].Cells[1].Value);
                cierrecajero.Faltante_quinientos_dolares = Convert.ToDecimal(dgvCierre.Rows[15].Cells[2].Value);
                cierrecajero.Faltante_quinientos_euros = Convert.ToDecimal(dgvCierre.Rows[15].Cells[3].Value);
                cierrecajero.Sobrante_clientes_colones = Convert.ToDecimal(dgvCierre.Rows[14].Cells[1].Value);
                cierrecajero.Sobrante_clientes_dolares = Convert.ToDecimal(dgvCierre.Rows[14].Cells[2].Value);
                cierrecajero.Sobrante_clientes_euros = Convert.ToDecimal(dgvCierre.Rows[14].Cells[3].Value);
                cierrecajero.TipoCierre = tipocajero;
                cierrecajero.Total_Entregas_colones = Convert.ToDecimal(dgvCierre.Rows[8].Cells[1].Value);
                cierrecajero.Total_Entregas_dolares = Convert.ToDecimal(dgvCierre.Rows[8].Cells[2].Value);
                cierrecajero.Total_Entregas_euros = Convert.ToDecimal(dgvCierre.Rows[8].Cells[3].Value);
                cierrecajero.Compra_dolares_col = Convert.ToDecimal(dgvCierre.Rows[9].Cells[1].Value);
                cierrecajero.Venta_dolares_dol = Convert.ToDecimal(dgvCierre.Rows[10].Cells[2].Value);
                cierrecajero.Compra_dolares_dol = Convert.ToDecimal(dgvCierre.Rows[9].Cells[2].Value);
                cierrecajero.Venta_dolares_col = Convert.ToDecimal(dgvCierre.Rows[10].Cells[1].Value);
                cierrecajero.Compra_euros_col = Convert.ToDecimal(dgvCierre.Rows[11].Cells[1].Value);
                cierrecajero.Venta_euros_eur = Convert.ToDecimal(dgvCierre.Rows[12].Cells[3].Value);
                cierrecajero.Compra_euros_eur = Convert.ToDecimal(dgvCierre.Rows[11].Cells[3].Value);
                cierrecajero.Venta_euros_col = Convert.ToDecimal(dgvCierre.Rows[12].Cells[1].Value);
                cierrecajero.Sobrante_quinientos_colones = Convert.ToDecimal(dgvCierre.Rows[16].Cells[1].Value);
                cierrecajero.Sobrante_quinientos_dolares = Convert.ToDecimal(dgvCierre.Rows[16].Cells[2].Value);
                cierrecajero.Sobrante_quinientos_euros = Convert.ToDecimal(dgvCierre.Rows[16].Cells[3].Value);
                cierrecajero.Saldo_final_colones = Convert.ToDecimal(dgvCierre.Rows[17].Cells[1].Value);
                cierrecajero.Saldo_final_dolares = Convert.ToDecimal(dgvCierre.Rows[17].Cells[2].Value);
                cierrecajero.Saldo_final_euros = Convert.ToDecimal(dgvCierre.Rows[17].Cells[3].Value);
                cierrecajero.Saldo_inicial_colones = Convert.ToDecimal(dgvCierre.Rows[0].Cells[1].Value);
                cierrecajero.Saldo_inicial_dolares = Convert.ToDecimal(dgvCierre.Rows[0].Cells[2].Value);
                cierrecajero.Saldo_inicial_euros = Convert.ToDecimal(dgvCierre.Rows[0].Cells[3].Value);
                cierrecajero.Niquel_enmesa_colones = Convert.ToDecimal(dgvCierre.Rows[5].Cells[1].Value);
                cierrecajero.Niquel_enmesa_dolares = Convert.ToDecimal(dgvCierre.Rows[5].Cells[2].Value);
                cierrecajero.Niquel_enmesa_euros = Convert.ToDecimal(dgvCierre.Rows[5].Cells[3].Value);
                cierrecajero.Niquel_Total_colones = Convert.ToDecimal(dgvCierre.Rows[7].Cells[1].Value);
                cierrecajero.Niquel_Total_dolares = Convert.ToDecimal(dgvCierre.Rows[7].Cells[2].Value);
                cierrecajero.Niquel_Total_euros = Convert.ToDecimal(dgvCierre.Rows[7].Cells[3].Value);
                cierrecajero.Total_Entregas_Niquel_colones = Convert.ToDecimal(dgvCierre.Rows[6].Cells[1].Value);
                cierrecajero.Total_Entregas_Niquel_dolares = Convert.ToDecimal(dgvCierre.Rows[6].Cells[2].Value);
                cierrecajero.Total_Entregas_Niquel_euros = Convert.ToDecimal(dgvCierre.Rows[6].Cells[3].Value);
                cierrecajero.Manifiestos = Convert.ToInt16(lblNumManifiestos.Text);
                cierrecajero.Comentarios = txtObservaciones.Text;
                cierrecajero.Fecha = dtpFecha.Value;
                cierrecajero.TipoCierre = tipocajero;
                cierrecajero.Cheques = cantcheques;
                cierrecajero.Depositos = cantdepositos;
                cierrecajero.Tulas = canttulas;
                if (_mantenimiento.verificacierrecajero(ref cierrecajero) == 0)
                {
                    _mantenimiento.agregarinfocierrecajero(ref cierrecajero);
                    cboMoneda.Enabled = false;
                    nudMonto.Enabled = false;
                    btnAñadirSI.Enabled = false;
                    permisosup = false;
                    MessageBox.Show("Se registró la información del cierre de cajero", "Registro realizado", MessageBoxButtons.OK);
                }
                else
                {
                    frmValidacionCoordinadorCE formulario = new frmValidacionCoordinadorCE(7, _colaborador);
                    formulario.ShowDialog(this);
                    if (permisosup)
                    {
                        _mantenimiento.agregarinfocierrecajero2(ref cierrecajero, _coordinador);
                        cboMoneda.Enabled = false;
                        nudMonto.Enabled = false;
                        btnAñadirSI.Enabled = false;
                        permisosup = false;
                        MessageBox.Show("Se actualizó la información del cierre de cajero", "Actualizacion realizada", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show("No tiene permiso para actualizar el cierre de cajero", "Actualizacion No autorizada", MessageBoxButtons.OK);
                    }
                }
            }
            else
            {
                cierrecajero = new CierreCajeroPROA(cajero: (Colaborador)cboCajero.SelectedItem, digitador: (Colaborador)cboDigitador.SelectedItem,
                    coordinador: (Colaborador)cboCoordinador.SelectedItem);
                cierrecajero.Total_clientes_Directos_colones = Convert.ToDecimal(dgvCierre.Rows[1].Cells[1].Value);
                cierrecajero.Total_clientes_Directos_dolares = Convert.ToDecimal(dgvCierre.Rows[1].Cells[2].Value);
                cierrecajero.Total_clientes_Directos_euros = Convert.ToDecimal(dgvCierre.Rows[1].Cells[3].Value);
                cierrecajero.Niquel_cola_Cajeros_colones = Convert.ToDecimal(dgvCierre.Rows[2].Cells[1].Value);
                cierrecajero.Niquel_cola_Cajeros_dolares = Convert.ToDecimal(dgvCierre.Rows[2].Cells[2].Value);
                cierrecajero.Niquel_cola_Cajeros_euros = Convert.ToDecimal(dgvCierre.Rows[2].Cells[3].Value);
                cierrecajero.Niquel_entrega_Cajeros_colones = Convert.ToDecimal(dgvCierre.Rows[3].Cells[1].Value);
                cierrecajero.Niquel_entrega_Cajeros_dolares = Convert.ToDecimal(dgvCierre.Rows[3].Cells[2].Value);
                cierrecajero.Niquel_entrega_Cajeros_euros = Convert.ToDecimal(dgvCierre.Rows[3].Cells[3].Value);
                cierrecajero.Niquel_procesamiento_colones = Convert.ToDecimal(dgvCierre.Rows[4].Cells[1].Value);
                cierrecajero.Niquel_procesamiento_dolares = Convert.ToDecimal(dgvCierre.Rows[4].Cells[2].Value);
                cierrecajero.Niquel_procesamiento_euros = Convert.ToDecimal(dgvCierre.Rows[4].Cells[3].Value);
                cierrecajero.Niquel_enmesa_colones = Convert.ToDecimal(dgvCierre.Rows[5].Cells[1].Value);
                cierrecajero.Niquel_enmesa_dolares = Convert.ToDecimal(dgvCierre.Rows[5].Cells[2].Value);
                cierrecajero.Niquel_enmesa_euros = Convert.ToDecimal(dgvCierre.Rows[5].Cells[3].Value);
                cierrecajero.Total_Entregas_Niquel_colones = Convert.ToDecimal(dgvCierre.Rows[6].Cells[1].Value);
                cierrecajero.Total_Entregas_Niquel_dolares = Convert.ToDecimal(dgvCierre.Rows[6].Cells[2].Value);
                cierrecajero.Total_Entregas_Niquel_euros = Convert.ToDecimal(dgvCierre.Rows[6].Cells[3].Value);
                cierrecajero.Niquel_Total_colones = Convert.ToDecimal(dgvCierre.Rows[7].Cells[1].Value);
                cierrecajero.Niquel_Total_dolares = Convert.ToDecimal(dgvCierre.Rows[7].Cells[2].Value);
                cierrecajero.Niquel_Total_euros = Convert.ToDecimal(dgvCierre.Rows[7].Cells[3].Value);
                cierrecajero.Total_Entregas_billetes_colones = Convert.ToDecimal(dgvCierre.Rows[8].Cells[1].Value);
                cierrecajero.Total_Entregas_billetes_dolares = Convert.ToDecimal(dgvCierre.Rows[8].Cells[2].Value);
                cierrecajero.Total_Entregas_billetes_euros = Convert.ToDecimal(dgvCierre.Rows[8].Cells[3].Value);                
                cierrecajero.Cheques_locales_colones = Convert.ToDecimal(dgvCierre.Rows[9].Cells[1].Value);
                cierrecajero.Cheques_locales_dolares = Convert.ToDecimal(dgvCierre.Rows[9].Cells[2].Value);
                cierrecajero.Cheques_locales_euros = Convert.ToDecimal(dgvCierre.Rows[9].Cells[3].Value);
                cierrecajero.Cheques_exterior_colones = Convert.ToDecimal(dgvCierre.Rows[10].Cells[1].Value);
                cierrecajero.Cheques_exterior_dolares = Convert.ToDecimal(dgvCierre.Rows[10].Cells[2].Value);
                cierrecajero.Cheques_exterior_euros = Convert.ToDecimal(dgvCierre.Rows[10].Cells[3].Value);
                cierrecajero.Cheques_bac_colones = Convert.ToDecimal(dgvCierre.Rows[11].Cells[1].Value);
                cierrecajero.Cheques_bac_dolares = Convert.ToDecimal(dgvCierre.Rows[11].Cells[2].Value);
                cierrecajero.Cheques_bac_euros = Convert.ToDecimal(dgvCierre.Rows[11].Cells[3].Value);
                if (cboCoordinador.SelectedIndex > -1)
                    cierrecajero.Coordinador = (Colaborador)cboCoordinador.SelectedItem;                
                cierrecajero.Faltante_clientes_colones = Convert.ToDecimal(dgvCierre.Rows[17].Cells[1].Value);
                cierrecajero.Faltante_clientes_dolares = Convert.ToDecimal(dgvCierre.Rows[17].Cells[2].Value);
                cierrecajero.Faltante_clientes_euros = Convert.ToDecimal(dgvCierre.Rows[17].Cells[3].Value);
                cierrecajero.Faltante_quinientos_colones = Convert.ToDecimal(dgvCierre.Rows[19].Cells[1].Value);
                cierrecajero.Faltante_quinientos_dolares = Convert.ToDecimal(dgvCierre.Rows[19].Cells[2].Value);
                cierrecajero.Faltante_quinientos_euros = Convert.ToDecimal(dgvCierre.Rows[19].Cells[3].Value);
                cierrecajero.Sobrante_clientes_colones = Convert.ToDecimal(dgvCierre.Rows[18].Cells[1].Value); 
                cierrecajero.Sobrante_clientes_dolares = Convert.ToDecimal(dgvCierre.Rows[18].Cells[2].Value);
                cierrecajero.Sobrante_clientes_euros = Convert.ToDecimal(dgvCierre.Rows[18].Cells[3].Value);
                cierrecajero.TipoCierre = tipocajero;                                
                cierrecajero.Sobrante_quinientos_colones = Convert.ToDecimal(dgvCierre.Rows[20].Cells[1].Value);
                cierrecajero.Sobrante_quinientos_dolares = Convert.ToDecimal(dgvCierre.Rows[20].Cells[2].Value);
                cierrecajero.Sobrante_quinientos_euros = Convert.ToDecimal(dgvCierre.Rows[20].Cells[3].Value);
                cierrecajero.Saldo_final_colones = Convert.ToDecimal(dgvCierre.Rows[21].Cells[1].Value);
                cierrecajero.Saldo_final_dolares = Convert.ToDecimal(dgvCierre.Rows[21].Cells[2].Value);
                cierrecajero.Saldo_final_euros = Convert.ToDecimal(dgvCierre.Rows[21].Cells[3].Value);
                cierrecajero.Saldo_inicial_colones = Convert.ToDecimal(dgvCierre.Rows[0].Cells[1].Value);
                cierrecajero.Saldo_inicial_dolares = Convert.ToDecimal(dgvCierre.Rows[0].Cells[2].Value);
                cierrecajero.Saldo_inicial_euros = Convert.ToDecimal(dgvCierre.Rows[0].Cells[3].Value);                                                
                cierrecajero.Manifiestos = Convert.ToInt16(lblNumManifiestos.Text);
                cierrecajero.Fecha = dtpFecha.Value;
                cierrecajero.Compra_dolares_col = Convert.ToDecimal(dgvCierre.Rows[13].Cells[1].Value);
                cierrecajero.Venta_dolares_dol = Convert.ToDecimal(dgvCierre.Rows[14].Cells[2].Value);
                cierrecajero.Compra_dolares_dol = Convert.ToDecimal(dgvCierre.Rows[13].Cells[2].Value);
                cierrecajero.Venta_dolares_col = Convert.ToDecimal(dgvCierre.Rows[14].Cells[1].Value);
                cierrecajero.Compra_euros_col = Convert.ToDecimal(dgvCierre.Rows[15].Cells[1].Value);
                cierrecajero.Venta_euros_eur = Convert.ToDecimal(dgvCierre.Rows[16].Cells[3].Value);
                cierrecajero.Compra_euros_eur = Convert.ToDecimal(dgvCierre.Rows[15].Cells[3].Value);
                cierrecajero.Venta_euros_col = Convert.ToDecimal(dgvCierre.Rows[16].Cells[1].Value);
                cierrecajero.Comentarios = txtObservaciones.Text;
                cierrecajero.TipoCierre = tipocajero;
                cierrecajero.Cheques = cantcheques;
                cierrecajero.Depositos = cantdepositos;
                cierrecajero.Tulas = canttulas;
                if (_mantenimiento.verificacierrecajeroNiquel(ref cierrecajero) == 0)
                {
                    _mantenimiento.agregarinfocierrecajeroNiquel(ref cierrecajero);
                    cboMoneda.Enabled = false;
                    nudMonto.Enabled = false;
                    btnAñadirSI.Enabled = false;
                    permisosup = false;
                    MessageBox.Show("Se registró la información del cierre de cajero", "Registro realizado", MessageBoxButtons.OK);
                }
                else
                {
                    frmValidacionCoordinadorCE formulario = new frmValidacionCoordinadorCE(7, _colaborador);
                    formulario.ShowDialog(this);
                    if (permisosup)
                    {
                        _mantenimiento.agregarinfocierrecajeroNiquel2(ref cierrecajero, _coordinador);                        
                        cboMoneda.Enabled = false;
                        nudMonto.Enabled = false;
                        btnAñadirSI.Enabled = false;
                        permisosup = false;
                        MessageBox.Show("Se actualizó la información del cierre de cajero", "Actualizacion realizada", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show("No tiene permiso para actualizar el cierre de cajero", "Actualizacion No autorizada", MessageBoxButtons.OK);
                    }
                }                
            }
        }

        private void protegerCeldas2(DataGridView tabla)
        {            
            this.formatoCeldaSoloLectura(tabla, 0, 1, 2, 3, 4, 5, 7, 8, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 , 26, 27, 28, 29);
            this.formatoCeldaSoloLecturaColumna(tabla, MontoColonesConsolidado.Index, 7, 8, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29);
            this.formatoCeldaSoloLecturaColumna(tabla, MontoDolaresConsolidado.Index, 7, 8, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29);
            this.formatoCeldaSoloLecturaColumna(tabla, clmMontoEurosCierre.Index, 7, 8, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29);
            this.formatoCeldaSeparador(tabla, 6);

            //this.formatoCeldaSoloLecturaColumna(tabla, MontoColones.Index, 30);
            //this.formatoCeldaSoloLecturaColumna(tabla, MontoDolares.Index, 31);

            this.formatoCeldaFormato(tabla, MontoColones.Index, "N0", 0, 1, 2, 3, 4, 5);
        }

        private void crearTabla(DataGridView tabla, byte tipocierre)
        {
            tabla.Rows.Add("SALDO INICIAL", 0, 0, 0);
            if (chkNiquel.Checked == true)
            {
                tabla.Rows.Add("TOTAL CLIENTES DIRECTOS", 0, 0, 0);
                tabla.Rows.Add("NIQUEL COLA CAJEROS", 0, 0, 0);
                tabla.Rows.Add("NIQUEL ENTREGAS CAJEROS", 0, 0, 0);
                tabla.Rows.Add("NIQUEL PROCESAMIENTO EXTERNO", 0, 0, 0);
                tabla.Rows.Add("NIQUEL EN MESA", 0, 0, 0);
                tabla.Rows.Add("TOTAL ENTREGAS NIQUEL", 0, 0, 0);
                tabla.Rows.Add("TOTAL NIQUEL", 0, 0, 0);
                tabla.Rows.Add("TOTAL ENTREGAS BILLETE", 0, 0, 0);
            }
            else
            {
                tabla.Rows.Add("TOTAL SUMA DE MANIFIESTOS", 0, 0, 0);                
            }
            tabla.Rows.Add("TOTAL CHEQUES LOCALES", 0, 0, 0);
            tabla.Rows.Add("TOTAL CHEQUES EXTERIOR", 0, 0, 0);
            tabla.Rows.Add("TOTAL CHEQUES BAC", 0, 0, 0);
            if (chkNiquel.Checked == false)
            {
                tabla.Rows.Add("NIQUEL EN MESA", 0, 0, 0);
                tabla.Rows.Add("ENTREGAS NIQUEL", 0, 0, 0);
                tabla.Rows.Add("NIQUEL TOTAL", 0, 0, 0);
                tabla.Rows.Add("TOTAL ENTREGAS", 0, 0, 0);                
            }
            else
            {
                tabla.Rows.Add("TOTAL CHEQUES", 0, 0, 0);
            }
            tabla.Rows.Add("COMPRAS DOLARES", 0, 0, 0);
            tabla.Rows.Add("VENTAS DOLARES", 0, 0, 0);
            tabla.Rows.Add("COMPRAS EUROS", 0, 0, 0);
            tabla.Rows.Add("VENTAS EUROS", 0, 0, 0);
            tabla.Rows.Add("FALTANTE CLIENTES", 0, 0, 0);
            tabla.Rows.Add("SOBRANTE CLIENTES", 0, 0, 0);
            tabla.Rows.Add("FALTANTE MENORES 500", 0, 0, 0);
            tabla.Rows.Add("SOBRANTE MENORES 500", 0, 0, 0);
            tabla.Rows.Add("SALDO FINAL", 0, 0, 0);            


            this.protegerCeldas(tabla);
        }

        private void crearTablaConsolidado(DataGridView tabla, byte tipocierre)
        {
            tabla.Rows.Add("MANIFIESTOS", 0, string.Empty, string.Empty);
            tabla.Rows.Add("TULAS", 0, string.Empty, string.Empty);
            tabla.Rows.Add("DEPOSITOS", 0, string.Empty, string.Empty);
            tabla.Rows.Add("CHEQUES", 0, string.Empty, string.Empty);
            tabla.Rows.Add("SOBRES", 0, string.Empty, string.Empty);
            tabla.Rows.Add("DISCONFORMIDADES", 0, string.Empty, string.Empty);
            tabla.Rows.Add(string.Empty, string.Empty, string.Empty, string.Empty);
            tabla.Rows.Add("SALDO INICIAL", 0, 0, 0);
            tabla.Rows.Add("TOTAL SUMA DE MANIFIESTOS", 0, 0, 0);
            tabla.Rows.Add("TOTAL CLIENTES DIRECTOS", 0, 0, 0);
            tabla.Rows.Add("NIQUEL COLA CAJEROS", 0, 0, 0);
            tabla.Rows.Add("NIQUEL ENTREGAS CAJEROS", 0, 0, 0);
            tabla.Rows.Add("NIQUEL PROCESAMIENTO EXTERNO", 0, 0, 0);
            tabla.Rows.Add("NIQUEL EN MESA", 0, 0, 0);
            tabla.Rows.Add("TOTAL ENTREGAS NIQUEL", 0, 0, 0);
            tabla.Rows.Add("TOTAL NIQUEL", 0, 0, 0);                                                
            tabla.Rows.Add("TOTAL ENTREGAS BILLETE", 0, 0, 0);
            tabla.Rows.Add("TOTAL CHEQUES LOCALES", 0, 0, 0);
            tabla.Rows.Add("TOTAL CHEQUES EXTERIOR", 0, 0, 0);
            tabla.Rows.Add("TOTAL CHEQUES BAC", 0, 0, 0);
            tabla.Rows.Add("TOTAL CHEQUES", 0, 0, 0);            
            tabla.Rows.Add("COMPRAS DOLARES", 0, 0, 0);
            tabla.Rows.Add("VENTAS DOLARES", 0, 0, 0);
            tabla.Rows.Add("COMPRAS EUROS", 0, 0, 0);
            tabla.Rows.Add("VENTAS EUROS", 0, 0, 0);
            tabla.Rows.Add("FALTANTE CLIENTES", 0, 0, 0);
            tabla.Rows.Add("SOBRANTE CLIENTES", 0, 0, 0);
            tabla.Rows.Add("FALTANTE MENORES 500", 0, 0, 0);
            tabla.Rows.Add("SOBRANTE MENORES 500", 0, 0, 0);
            tabla.Rows.Add("SALDO FINAL", 0, 0, 0);

            this.protegerCeldas2(tabla);
        }

        private void actualizarConsolidado()
        {
            decimal manifiestos = 0;
            decimal tulas = 0;
            decimal depositos = 0;

            decimal cheques = 0;
            decimal sobres = 0;
            decimal disconformidades = 0;

            decimal Cheques_bac_colones = 0;
            decimal Cheques_exterior_colones = 0;
            decimal Cheques_locales_colones = 0;
            decimal total_cheques_colones = 0;
            decimal Faltante_clientes_colones = 0;
            decimal Faltante_quinientos_colones = 0;
            decimal Niquel_cola_Cajeros_colones = 0;
            decimal Niquel_enmesa_colones = 0;
            decimal Niquel_entrega_Cajeros_colones = 0;
            decimal Niquel_procesamiento_colones = 0;
            decimal Niquel_Total_colones = 0;
            decimal Saldo_final_colones = 0;
            decimal Saldo_inicial_colones = 0;
            decimal Sobrante_clientes_colones = 0;
            decimal Sobrante_quinientos_colones = 0;
            decimal Total_clientes_Directos_colones = 0;
            decimal Total_Entregas_billetes_colones = 0;
            decimal Total_Entregas_colones = 0;
            decimal Total_Entregas_Niquel_colones = 0;
            decimal Total_Suma_Manifiestos_Colones = 0;

            decimal Cheques_bac_dolares = 0;
            decimal Cheques_exterior_dolares = 0;
            decimal Cheques_locales_dolares = 0;
            decimal total_cheques_dolares = 0;
            decimal Faltante_clientes_dolares = 0;
            decimal Faltante_quinientos_dolares = 0;
            decimal Niquel_cola_Cajeros_dolares = 0;
            decimal Niquel_enmesa_dolares = 0;
            decimal Niquel_entrega_Cajeros_dolares = 0;
            decimal Niquel_procesamiento_dolares = 0;
            decimal Niquel_Total_dolares = 0;
            decimal Saldo_final_dolares = 0;
            decimal Saldo_inicial_dolares = 0;
            decimal Sobrante_clientes_dolares = 0;
            decimal Sobrante_quinientos_dolares = 0;
            decimal Total_clientes_Directos_dolares = 0;
            decimal Total_Entregas_billetes_dolares = 0;
            decimal Total_Entregas_dolares = 0;
            decimal Total_Entregas_Niquel_dolares = 0;
            decimal Total_Suma_Manifiestos_dolares = 0;

            decimal Cheques_bac_euros = 0;
            decimal Cheques_exterior_euros = 0;
            decimal Cheques_locales_euros = 0;
            decimal total_cheques_euros = 0;
            decimal Faltante_clientes_euros = 0;
            decimal Faltante_quinientos_euros = 0;
            decimal Niquel_cola_Cajeros_euros = 0;
            decimal Niquel_enmesa_euros = 0;
            decimal Niquel_entrega_Cajeros_euros = 0;
            decimal Niquel_procesamiento_euros = 0;
            decimal Niquel_Total_euros = 0;
            decimal Saldo_final_euros = 0;
            decimal Saldo_inicial_euros = 0;
            decimal Sobrante_clientes_euros = 0;
            decimal Sobrante_quinientos_euros = 0;
            decimal Total_clientes_Directos_euros = 0;
            decimal Total_Entregas_billetes_euros = 0;
            decimal Total_Entregas_euros = 0;
            decimal Total_Entregas_Niquel_euros = 0;
            decimal Total_Suma_Manifiestos_euros = 0;

            decimal compra_dolares_col = 0;
            decimal venta_dolares_dol = 0;
            decimal compra_dolares_dol = 0;
            decimal venta_dolares_col = 0;

            decimal compra_euros_col = 0;
            decimal venta_euros_eur = 0;
            decimal compra_euros_eur = 0;
            decimal venta_euros_col = 0;

            foreach (CierreCajeroPROA cierre in clbCajeros.CheckedItems)
            {
                CierreCajeroPROA copia = new CierreCajeroPROA(fecha: cierre.Fecha, cajero: cierre.Cajero, digitador: null, tipocierre:cierre.TipoCierre);

                _coordinacion.obtenerDatosCierrePROA(ref copia);

                manifiestos += copia.Manifiestos;
                tulas += copia.Tulas;
                depositos += copia.Depositos;

                cheques += copia.Cheques;

                Cheques_bac_colones += copia.Cheques_bac_colones;
                Cheques_exterior_colones += copia.Cheques_exterior_colones;
                Cheques_locales_colones += copia.Cheques_locales_colones;
                total_cheques_colones = copia.Cheques_bac_colones + copia.Cheques_exterior_colones + copia.Cheques_locales_colones;
                Faltante_clientes_colones += copia.Faltante_clientes_colones;
                Faltante_quinientos_colones += copia.Faltante_quinientos_colones;
                Niquel_cola_Cajeros_colones += copia.Niquel_cola_Cajeros_colones;
                Niquel_enmesa_colones += copia.Niquel_enmesa_colones;
                Niquel_entrega_Cajeros_colones += copia.Niquel_entrega_Cajeros_colones;
                Niquel_procesamiento_colones += copia.Niquel_procesamiento_colones;
                Niquel_Total_colones += copia.Niquel_Total_colones;
                Saldo_final_colones += copia.Saldo_final_colones;
                Saldo_inicial_colones += copia.Saldo_inicial_colones;
                Sobrante_clientes_colones += copia.Sobrante_clientes_colones;
                Sobrante_quinientos_colones += copia.Sobrante_quinientos_colones;
                Total_clientes_Directos_colones += copia.Total_clientes_Directos_colones;
                Total_Entregas_billetes_colones += copia.Total_Entregas_billetes_colones;
                Total_Entregas_colones += copia.Total_Entregas_colones;
                Total_Entregas_Niquel_colones += copia.Total_Entregas_Niquel_colones;
                Total_Suma_Manifiestos_Colones += copia.Total_Suma_Manifiestos_Colones;

                Cheques_bac_dolares += copia.Cheques_bac_dolares;
                Cheques_exterior_dolares += copia.Cheques_exterior_dolares;
                Cheques_locales_dolares += copia.Cheques_locales_dolares;
                total_cheques_dolares = copia.Cheques_bac_dolares + copia.Cheques_exterior_dolares + copia.Cheques_locales_dolares;
                Faltante_clientes_dolares += copia.Faltante_clientes_dolares;
                Faltante_quinientos_dolares += copia.Faltante_quinientos_dolares;
                Niquel_cola_Cajeros_dolares += copia.Niquel_cola_Cajeros_dolares;
                Niquel_enmesa_dolares += copia.Niquel_enmesa_dolares;
                Niquel_entrega_Cajeros_dolares += copia.Niquel_entrega_Cajeros_dolares;
                Niquel_procesamiento_dolares += copia.Niquel_procesamiento_dolares;
                Niquel_Total_dolares += copia.Niquel_Total_dolares;
                Saldo_final_dolares += copia.Saldo_final_dolares;
                Saldo_inicial_dolares += copia.Saldo_inicial_dolares;
                Sobrante_clientes_dolares += copia.Sobrante_clientes_dolares;
                Sobrante_quinientos_dolares += copia.Sobrante_quinientos_dolares;
                Total_clientes_Directos_dolares += copia.Total_clientes_Directos_dolares;
                Total_Entregas_billetes_dolares += copia.Total_Entregas_billetes_dolares;
                Total_Entregas_dolares += copia.Total_Entregas_dolares;
                Total_Entregas_Niquel_dolares += copia.Total_Entregas_Niquel_dolares;
                Total_Suma_Manifiestos_dolares += copia.Total_Suma_Manifiestos_dolares;

                Cheques_bac_euros += copia.Cheques_bac_euros;
                Cheques_exterior_euros += copia.Cheques_exterior_euros;
                Cheques_locales_euros = copia.Cheques_locales_euros;
                total_cheques_euros = copia.Cheques_bac_euros + copia.Cheques_exterior_euros + copia.Cheques_locales_euros;
                Faltante_clientes_euros += copia.Faltante_clientes_euros;
                Faltante_quinientos_euros += copia.Faltante_quinientos_euros;
                Niquel_cola_Cajeros_euros += copia.Niquel_cola_Cajeros_euros;
                Niquel_enmesa_euros += copia.Niquel_enmesa_euros;
                Niquel_entrega_Cajeros_euros += copia.Niquel_entrega_Cajeros_euros;
                Niquel_procesamiento_euros += copia.Niquel_procesamiento_euros;
                Niquel_Total_euros += copia.Niquel_Total_euros;
                Saldo_final_euros += copia.Saldo_final_euros;
                Saldo_inicial_euros += copia.Saldo_inicial_euros;
                Sobrante_clientes_euros += copia.Sobrante_clientes_euros;
                Sobrante_quinientos_euros += copia.Sobrante_quinientos_euros;
                Total_clientes_Directos_euros += copia.Total_clientes_Directos_euros;
                Total_Entregas_billetes_euros += copia.Total_Entregas_billetes_euros;
                Total_Entregas_euros += copia.Total_Entregas_euros;
                Total_Entregas_Niquel_euros += copia.Total_Entregas_Niquel_euros;
                Total_Suma_Manifiestos_euros += copia.Total_Suma_Manifiestos_euros;

                compra_dolares_col += copia.Compra_dolares_col;
                venta_dolares_dol += copia.Venta_dolares_dol;
                compra_dolares_dol += copia.Compra_dolares_dol;
                venta_dolares_col += copia.Venta_dolares_col;

                compra_euros_col += copia.Compra_euros_col;
                venta_euros_eur += copia.Venta_euros_eur;
                compra_euros_eur += copia.Compra_euros_eur;
                venta_euros_col += copia.Venta_euros_col;

            }



            // Mostrar los  valores

            dgvConsolidado[MontoColones.Index, 0].Value = manifiestos;
            dgvConsolidado[MontoColones.Index, 1].Value = tulas;
            dgvConsolidado[MontoColones.Index, 2].Value = depositos;

            dgvConsolidado[MontoColones.Index, 3].Value = cheques;
            dgvConsolidado[MontoColones.Index, 4].Value = sobres;
            dgvConsolidado[MontoColones.Index, 5].Value = disconformidades;

            dgvConsolidado[MontoColones.Index, 7].Value = Saldo_inicial_colones;
            dgvConsolidado[MontoColones.Index, 8].Value = Total_Suma_Manifiestos_Colones;
            dgvConsolidado[MontoColones.Index, 9].Value = Total_clientes_Directos_colones;
            dgvConsolidado[MontoColones.Index, 10].Value = Niquel_cola_Cajeros_colones;
            dgvConsolidado[MontoColones.Index, 11].Value = Niquel_entrega_Cajeros_colones;
            dgvConsolidado[MontoColones.Index, 12].Value = Niquel_procesamiento_colones;
            dgvConsolidado[MontoColones.Index, 13].Value = Niquel_enmesa_colones;
            dgvConsolidado[MontoColones.Index, 14].Value = Total_Entregas_Niquel_colones;
            dgvConsolidado[MontoColones.Index, 15].Value = Niquel_Total_colones;
            dgvConsolidado[MontoColones.Index, 16].Value = Total_Entregas_billetes_colones;
            dgvConsolidado[MontoColones.Index, 17].Value = Cheques_locales_colones;
            dgvConsolidado[MontoColones.Index, 18].Value = Cheques_exterior_colones;
            dgvConsolidado[MontoColones.Index, 19].Value = Cheques_bac_colones;
            dgvConsolidado[MontoColones.Index, 20].Value = total_cheques_colones;
            dgvConsolidado[MontoColones.Index, 21].Value = compra_dolares_col;
            dgvConsolidado[MontoColones.Index, 22].Value = venta_dolares_col;
            dgvConsolidado[MontoColones.Index, 23].Value = compra_euros_col;
            dgvConsolidado[MontoColones.Index, 24].Value = venta_euros_col;
            dgvConsolidado[MontoColones.Index, 25].Value = Faltante_clientes_colones;
            dgvConsolidado[MontoColones.Index, 26].Value = Sobrante_clientes_colones;
            dgvConsolidado[MontoColones.Index, 27].Value = Faltante_quinientos_colones;
            dgvConsolidado[MontoColones.Index, 28].Value = Sobrante_quinientos_colones;
            dgvConsolidado[MontoColones.Index, 29].Value = Saldo_final_colones;

            dgvConsolidado[MontoDolares.Index, 7].Value = Saldo_inicial_dolares;
            dgvConsolidado[MontoDolares.Index, 8].Value = Total_Suma_Manifiestos_dolares;
            dgvConsolidado[MontoDolares.Index, 9].Value = Total_clientes_Directos_dolares;
            dgvConsolidado[MontoDolares.Index, 10].Value = Niquel_cola_Cajeros_dolares;
            dgvConsolidado[MontoDolares.Index, 11].Value = Niquel_entrega_Cajeros_dolares;
            dgvConsolidado[MontoDolares.Index, 12].Value = Niquel_procesamiento_dolares;
            dgvConsolidado[MontoDolares.Index, 13].Value = Niquel_enmesa_dolares;
            dgvConsolidado[MontoDolares.Index, 14].Value = Total_Entregas_Niquel_dolares;
            dgvConsolidado[MontoDolares.Index, 15].Value = Niquel_Total_dolares;
            dgvConsolidado[MontoDolares.Index, 16].Value = Total_Entregas_billetes_dolares;
            dgvConsolidado[MontoDolares.Index, 17].Value = Cheques_locales_dolares;
            dgvConsolidado[MontoDolares.Index, 18].Value = Cheques_exterior_dolares;
            dgvConsolidado[MontoDolares.Index, 19].Value = Cheques_bac_dolares;
            dgvConsolidado[MontoDolares.Index, 20].Value = total_cheques_dolares;
            dgvConsolidado[MontoDolares.Index, 21].Value = compra_dolares_dol;
            dgvConsolidado[MontoDolares.Index, 22].Value = venta_dolares_dol;
            dgvConsolidado[MontoDolares.Index, 23].Value = 0;
            dgvConsolidado[MontoDolares.Index, 24].Value = 0;
            dgvConsolidado[MontoDolares.Index, 25].Value = Faltante_clientes_dolares;
            dgvConsolidado[MontoDolares.Index, 26].Value = Sobrante_clientes_dolares;
            dgvConsolidado[MontoDolares.Index, 27].Value = Faltante_quinientos_dolares;
            dgvConsolidado[MontoDolares.Index, 28].Value = Sobrante_quinientos_dolares;
            dgvConsolidado[MontoDolares.Index, 29].Value = Saldo_final_dolares;



            dgvConsolidado[clmMontoEurosCierre.Index, 7].Value = Saldo_inicial_euros;
            dgvConsolidado[clmMontoEurosCierre.Index, 8].Value = Total_Suma_Manifiestos_euros;
            dgvConsolidado[clmMontoEurosCierre.Index, 9].Value = Total_clientes_Directos_euros;
            dgvConsolidado[clmMontoEurosCierre.Index, 10].Value = Niquel_cola_Cajeros_euros;
            dgvConsolidado[clmMontoEurosCierre.Index, 11].Value = Niquel_entrega_Cajeros_euros;
            dgvConsolidado[clmMontoEurosCierre.Index, 12].Value = Niquel_procesamiento_euros;
            dgvConsolidado[clmMontoEurosCierre.Index, 13].Value = Niquel_enmesa_euros;
            dgvConsolidado[clmMontoEurosCierre.Index, 14].Value = Total_Entregas_Niquel_euros;
            dgvConsolidado[clmMontoEurosCierre.Index, 15].Value = Niquel_Total_euros;
            dgvConsolidado[clmMontoEurosCierre.Index, 16].Value = Total_Entregas_billetes_euros;
            dgvConsolidado[clmMontoEurosCierre.Index, 17].Value = Cheques_locales_euros;
            dgvConsolidado[clmMontoEurosCierre.Index, 18].Value = Cheques_exterior_euros;
            dgvConsolidado[clmMontoEurosCierre.Index, 19].Value = Cheques_bac_euros;
            dgvConsolidado[clmMontoEurosCierre.Index, 20].Value = total_cheques_euros;
            //dgvConsolidado[clmMontoEurosCierre.Index, 21].Value = 0;
            //dgvConsolidado[clmMontoEurosCierre.Index, 22].Value = 0;
            dgvConsolidado[clmMontoEurosCierre.Index, 23].Value = compra_euros_eur;
            dgvConsolidado[clmMontoEurosCierre.Index, 24].Value = venta_euros_eur;
            dgvConsolidado[clmMontoEurosCierre.Index, 25].Value = Faltante_clientes_euros;
            dgvConsolidado[clmMontoEurosCierre.Index, 26].Value = Sobrante_clientes_euros;
            dgvConsolidado[clmMontoEurosCierre.Index, 27].Value = Faltante_quinientos_euros;
            dgvConsolidado[clmMontoEurosCierre.Index, 28].Value = Sobrante_quinientos_euros;
            dgvConsolidado[clmMontoEurosCierre.Index, 29].Value = Saldo_final_euros;

            
        }

        private void actualizartabla(byte tipocajero, DataTable datos)
        {
            switch (tipocajero)
            {
                case 0:
                    dgvCierre.Rows[1].Cells[1].Value = datos.Rows[0][0]; //suma manifiestos
                    dgvCierre.Rows[1].Cells[2].Value = datos.Rows[0][1];
                    dgvCierre.Rows[1].Cells[3].Value = datos.Rows[0][2];
                    dgvCierre.Rows[2].Cells[1].Value = datos.Rows[0][3]; //cheques locales
                    dgvCierre.Rows[2].Cells[2].Value = datos.Rows[0][4];
                    dgvCierre.Rows[2].Cells[3].Value = datos.Rows[0][5];
                    dgvCierre.Rows[3].Cells[1].Value = datos.Rows[0][6];//cheques exterior
                    dgvCierre.Rows[3].Cells[2].Value = datos.Rows[0][7];
                    dgvCierre.Rows[3].Cells[3].Value = datos.Rows[0][8];
                    dgvCierre.Rows[4].Cells[1].Value = datos.Rows[0][9];//cheques bac
                    dgvCierre.Rows[4].Cells[2].Value = datos.Rows[0][10];
                    dgvCierre.Rows[4].Cells[3].Value = datos.Rows[0][11];
                    dgvCierre.Rows[5].Cells[1].Value = datos.Rows[0][12];//niquel mesa
                    dgvCierre.Rows[6].Cells[1].Value = datos.Rows[0][13];//entregas niquel
                    dgvCierre.Rows[7].Cells[1].Value = datos.Rows[0][33];//Niquel total
                    dgvCierre.Rows[8].Cells[1].Value = datos.Rows[0][14];//total entregas (Billete)
                    dgvCierre.Rows[8].Cells[2].Value = datos.Rows[0][15];
                    dgvCierre.Rows[8].Cells[3].Value = datos.Rows[0][16];
                    dgvCierre.Rows[9].Cells[1].Value = datos.Rows[0][17];//compras dolares crc
                    dgvCierre.Rows[9].Cells[2].Value = datos.Rows[0][18];//compras dolares usd
                    dgvCierre.Rows[10].Cells[1].Value = datos.Rows[0][19];//ventas dolares crc
                    dgvCierre.Rows[10].Cells[2].Value = datos.Rows[0][20];//ventas dolares usd
                    dgvCierre.Rows[11].Cells[1].Value = datos.Rows[0][34];//compras euros crc
                    dgvCierre.Rows[11].Cells[3].Value = datos.Rows[0][35];//compras euros eur
                    dgvCierre.Rows[12].Cells[1].Value = datos.Rows[0][36];//ventas euros crc
                    dgvCierre.Rows[12].Cells[3].Value = datos.Rows[0][37];//ventas euros eur
                    dgvCierre.Rows[13].Cells[1].Value = datos.Rows[0][21];//faltantes clientes
                    dgvCierre.Rows[13].Cells[2].Value = datos.Rows[0][22];
                    dgvCierre.Rows[13].Cells[3].Value = datos.Rows[0][23];
                    dgvCierre.Rows[14].Cells[1].Value = datos.Rows[0][24];//sobrantes clientes
                    dgvCierre.Rows[14].Cells[2].Value = datos.Rows[0][25];
                    dgvCierre.Rows[14].Cells[3].Value = datos.Rows[0][26];
                    dgvCierre.Rows[15].Cells[1].Value = datos.Rows[0][27];//faltantes clientes 500
                    dgvCierre.Rows[15].Cells[2].Value = datos.Rows[0][28];
                    dgvCierre.Rows[15].Cells[3].Value = datos.Rows[0][29];
                    dgvCierre.Rows[16].Cells[1].Value = datos.Rows[0][30];//sobrantes clientes 500
                    dgvCierre.Rows[16].Cells[2].Value = datos.Rows[0][31];
                    dgvCierre.Rows[16].Cells[3].Value = datos.Rows[0][32];
                    lblNumManifiestos.Text = datos.Rows[0][38].ToString();
                    txtObservaciones.Text = "";
                    if (datos.Columns.Count > 45)
                    {
                        dgvCierre.Rows[0].Cells[1].Value = datos.Rows[0][48]; //saldo inicial
                        dgvCierre.Rows[0].Cells[2].Value = datos.Rows[0][49];
                        dgvCierre.Rows[0].Cells[3].Value = datos.Rows[0][50];
                        dgvCierre.Rows[17].Cells[1].Value = datos.Rows[0][45]; //saldo final
                        dgvCierre.Rows[17].Cells[2].Value = datos.Rows[0][46];
                        dgvCierre.Rows[17].Cells[3].Value = datos.Rows[0][47];
                        txtObservaciones.Text = datos.Rows[0]["Comentarios"].ToString();
                    }
                    break;
                case 1:
                    dgvCierre.Rows[1].Cells[1].Value = datos.Rows[0][0]; //Clientes Directos
                    dgvCierre.Rows[1].Cells[2].Value = datos.Rows[0][1];
                    dgvCierre.Rows[1].Cells[3].Value = datos.Rows[0][2];
                    dgvCierre.Rows[2].Cells[1].Value = datos.Rows[0][3];//niquel cola cajeros
                    dgvCierre.Rows[3].Cells[1].Value = datos.Rows[0][4];//niquel entregas cajeros
                    dgvCierre.Rows[4].Cells[1].Value = datos.Rows[0][5];//Niquel procesamiento externo
                    dgvCierre.Rows[5].Cells[1].Value = datos.Rows[0][6];//niquel en mesa
                    dgvCierre.Rows[6].Cells[1].Value = datos.Rows[0][7];//total entregas niquel
                    dgvCierre.Rows[7].Cells[1].Value = datos.Rows[0][8];//total niquel
                    dgvCierre.Rows[8].Cells[1].Value = datos.Rows[0][9]; //total entrega billete (incluye tipo cambio)
                    dgvCierre.Rows[8].Cells[2].Value = datos.Rows[0][10];
                    dgvCierre.Rows[8].Cells[3].Value = datos.Rows[0][11];
                    dgvCierre.Rows[9].Cells[1].Value = datos.Rows[0][12]; //cheques locales
                    dgvCierre.Rows[9].Cells[2].Value = datos.Rows[0][13];
                    dgvCierre.Rows[9].Cells[3].Value = datos.Rows[0][14];
                    dgvCierre.Rows[10].Cells[1].Value = datos.Rows[0][15];//cheques exterior
                    dgvCierre.Rows[10].Cells[2].Value = datos.Rows[0][16];
                    dgvCierre.Rows[10].Cells[3].Value = datos.Rows[0][17];
                    dgvCierre.Rows[11].Cells[1].Value = datos.Rows[0][18];//cheques bac
                    dgvCierre.Rows[11].Cells[2].Value = datos.Rows[0][19];
                    dgvCierre.Rows[11].Cells[3].Value = datos.Rows[0][20];                                                                            
                    dgvCierre.Rows[12].Cells[1].Value = datos.Rows[0][21];//total cheques
                    dgvCierre.Rows[12].Cells[2].Value = datos.Rows[0][22];
                    dgvCierre.Rows[12].Cells[3].Value = datos.Rows[0][23];
                    /*if (datos.Columns.Count > 44)
                    {
                        dgvCierre.Rows[13].Cells[1].Value = datos.Rows[0][34];//compras dolares crc
                        dgvCierre.Rows[13].Cells[2].Value = datos.Rows[0][35];//compras dolares usd
                        dgvCierre.Rows[14].Cells[1].Value = datos.Rows[0][36];//ventas dolares crc
                        dgvCierre.Rows[14].Cells[2].Value = datos.Rows[0][37];//ventas dolares usd
                    }
                    else
                    {
                        dgvCierre.Rows[13].Cells[1].Value = datos.Rows[0][39];//compras dolares crc
                        dgvCierre.Rows[13].Cells[2].Value = datos.Rows[0][38];//compras dolares usd
                        dgvCierre.Rows[14].Cells[1].Value = datos.Rows[0][37];//ventas dolares crc
                        dgvCierre.Rows[14].Cells[2].Value = datos.Rows[0][40];//ventas dolares usd
                    }*/                                       
                    dgvCierre.Rows[13].Cells[1].Value = datos.Rows[0][37];//compras dolares crc
                    dgvCierre.Rows[13].Cells[2].Value = datos.Rows[0][38];//compras dolares usd
                    dgvCierre.Rows[14].Cells[1].Value = datos.Rows[0][39];//ventas dolares crc
                    dgvCierre.Rows[14].Cells[2].Value = datos.Rows[0][40];//ventas dolares usd
                    dgvCierre.Rows[15].Cells[1].Value = datos.Rows[0][41];//compras euros crc
                    dgvCierre.Rows[15].Cells[3].Value = datos.Rows[0][42];//compras euros eur
                    dgvCierre.Rows[16].Cells[1].Value = datos.Rows[0][43];//ventas euros crc
                    dgvCierre.Rows[16].Cells[3].Value = datos.Rows[0][44];//ventas euros eur
                    dgvCierre.Rows[17].Cells[1].Value = datos.Rows[0][24];//faltantes clientes
                    dgvCierre.Rows[17].Cells[2].Value = datos.Rows[0][25];
                    dgvCierre.Rows[17].Cells[3].Value = datos.Rows[0][26];
                    dgvCierre.Rows[18].Cells[1].Value = datos.Rows[0][27];//sobrantes clientes
                    dgvCierre.Rows[18].Cells[2].Value = datos.Rows[0][28];
                    dgvCierre.Rows[18].Cells[3].Value = datos.Rows[0][29];
                    dgvCierre.Rows[19].Cells[1].Value = datos.Rows[0][30];//faltantes clientes 500
                    dgvCierre.Rows[19].Cells[2].Value = datos.Rows[0][31];
                    dgvCierre.Rows[19].Cells[3].Value = datos.Rows[0][32];
                    dgvCierre.Rows[20].Cells[1].Value = datos.Rows[0][33];//sobrantes clientes 500
                    dgvCierre.Rows[20].Cells[2].Value = datos.Rows[0][34];
                    dgvCierre.Rows[20].Cells[3].Value = datos.Rows[0][35];
                    lblNumManifiestos.Text = datos.Rows[0][36].ToString();
                    txtObservaciones.Text = "";
                    if (datos.Columns.Count > 51)
                    {
                        dgvCierre.Rows[0].Cells[1].Value = datos.Rows[0][48]; //saldo inicial
                        dgvCierre.Rows[0].Cells[2].Value = datos.Rows[0][49];
                        dgvCierre.Rows[0].Cells[3].Value = datos.Rows[0][50];
                        dgvCierre.Rows[21].Cells[1].Value = datos.Rows[0][45]; //saldo final
                        dgvCierre.Rows[21].Cells[2].Value = datos.Rows[0][46];
                        dgvCierre.Rows[21].Cells[3].Value = datos.Rows[0][47];
                        txtObservaciones.Text = datos.Rows[0]["Comentarios"].ToString();
                    }
                    break;
            }
            cantcheques = Convert.ToInt16(datos.Rows[0]["Cantidad Cheques"]);
            cantdepositos = Convert.ToInt16(datos.Rows[0]["Cantidad Depositos"]);
            canttulas = Convert.ToInt16(datos.Rows[0]["Cantidad Tulas"]);
        }

        private void obtenerTipoCambioImpresion()
        {

            try
            {
                DateTime fecha = dtpFechaImpresion.Value;

                _tipo_cambio_impresion = _mantenimiento.obtenerTipoCambio(fecha); //cambio marzo 17032017

                bool estado = _tipo_cambio_impresion != null;

                if (_tipo_cambio_impresion == null)
                {
                    MessageBox.Show("El tipo de cambio del día seleccionado no ha sido agregado. Favor añadirlo para realizar consultas de impresión.");
                }

                //btnExportarExcel.Enabled = estado;
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Proteger las celdas para evitar su edición.
        /// </summary>
        private void protegerCeldas(DataGridView tabla)
        {
            /*this.formatoCeldaSoloLectura(tabla, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12);
            this.formatoCeldaSoloLecturaColumna(tabla, MontoDolares.Index, 3, 4, 5);            

            this.formatoCeldaSeparador(tabla, 6, 10, 29, 32);

            this.formatoCeldaSoloLecturaColumna(tabla, MontoColones.Index, 30);
            this.formatoCeldaSoloLecturaColumna(tabla, MontoDolares.Index, 31);*/
            if (chkNiquel.Checked == true)
            {
                this.formatoCeldaSoloLectura(tabla, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21);
                this.formatoCeldaSoloLecturaColumna(tabla, MontoDolares.Index, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21);
                this.formatoCeldaSoloLecturaColumna(tabla, MontoColones.Index, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21);
                this.formatoCeldaSoloLecturaColumna(tabla, clmMontoEuros.Index, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21);
                this.formatoCeldaFormato(tabla, MontoColones.Index, "N2", 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21);
                this.formatoCeldaFormato(tabla, MontoDolares.Index, "N2", 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21);
                this.formatoCeldaFormato(tabla, clmMontoEuros.Index, "N2", 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21);
            }
            else
            {
                this.formatoCeldaSoloLectura(tabla, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17);
                this.formatoCeldaSoloLecturaColumna(tabla, MontoDolares.Index, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17);
                this.formatoCeldaSoloLecturaColumna(tabla, MontoColones.Index, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17);
                this.formatoCeldaSoloLecturaColumna(tabla, clmMontoEuros.Index, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17);
                this.formatoCeldaFormato(tabla, MontoColones.Index, "N2", 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17);
                this.formatoCeldaFormato(tabla, MontoDolares.Index, "N2", 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17);
                this.formatoCeldaFormato(tabla, clmMontoEuros.Index, "N2", 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17);
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
                tabla.Rows[fila].DefaultCellStyle.BackColor = Concepto.DefaultCellStyle.BackColor;
            }

        }

        /// <summary>
        /// Dar formato  de solo lectura a las filas que lo requieran.
        /// </summary>
        private void formatoCeldaSoloLecturaColumna(DataGridView tabla, int columna, params int[] filas)
        {

            foreach (int fila in filas)
            {
                tabla[columna, fila].ReadOnly = true;
                tabla[columna, fila].Style.BackColor = Color.PapayaWhip;
            }

        }

        /// <summary>
        /// Dar formato a las celdas que lo requieran.
        /// </summary>
        private void formatoCeldaFormato(DataGridView tabla, int columna, string formato, params int[] filas)
        {

            foreach (int fila in filas) tabla[columna, fila].Style.Format = formato;

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

        private void escribirencabezado(DocumentoExcel documento, int hojacierre)
        {
            documento.seleccionarHoja(hojacierre);            

            documento.seleccionarCelda("B7");
            documento.actualizarValorCelda("Manifiestos");

            documento.seleccionarCelda("B8");
            documento.actualizarValorCelda("Tulas");

            documento.seleccionarCelda("B9");
            documento.actualizarValorCelda("Depositos");

            documento.seleccionarCelda("B10");
            documento.actualizarValorCelda("Cheques");

            documento.seleccionarCelda("B11");
            documento.actualizarValorCelda("Sobres");

            documento.seleccionarCelda("B12");
            documento.actualizarValorCelda("Disconformidades");

            documento.seleccionarCelda("B13");
            documento.actualizarValorCelda("Saldo Inicial");

            documento.seleccionarCelda("B14");
            documento.actualizarValorCelda("Total Suma de Manifiestos");

            documento.seleccionarCelda("B15");
            documento.actualizarValorCelda("Total Clientes Directos");

            documento.seleccionarCelda("B16");
            documento.actualizarValorCelda("Niquel Cola Cajeros");

            documento.seleccionarCelda("B17");
            documento.actualizarValorCelda("Niquel Entrega Cajeros");

            documento.seleccionarCelda("B18");
            documento.actualizarValorCelda("Niquel Procesamiento Externo");

            documento.seleccionarCelda("B19");
            documento.actualizarValorCelda("Niquel en mesa");

            documento.seleccionarCelda("B20");
            documento.actualizarValorCelda("Total Entregas Niquel");

            documento.seleccionarCelda("B21");
            documento.actualizarValorCelda("Total Niquel");

            documento.seleccionarCelda("B22");
            documento.actualizarValorCelda("Total Entregas Billete");

            documento.seleccionarCelda("B23");
            documento.actualizarValorCelda("Cheques Locales");

            documento.seleccionarCelda("B24");
            documento.actualizarValorCelda("Cheques del Exterior");

            documento.seleccionarCelda("B25");
            documento.actualizarValorCelda("Cheques del BAC");

            documento.seleccionarCelda("B26");
            documento.actualizarValorCelda("Total Cheques");


            //Escribe los sobrantes y faltantes de clientes en niquel

            //int niquel = 0;

            documento.seleccionarCelda("B27");
            documento.actualizarValorCelda("Compra de Dolares");

            documento.seleccionarCelda("B28");
            documento.actualizarValorCelda("Venta de Dolares");

            documento.seleccionarCelda("B29");
            documento.actualizarValorCelda("Compra de Euros");

            documento.seleccionarCelda("B30");
            documento.actualizarValorCelda("Venta de Euros");

            documento.seleccionarCelda("B31");
            documento.actualizarValorCelda("Faltante Clientes");

            documento.seleccionarCelda("B32");
            documento.actualizarValorCelda("Sobrante Clientes");

            documento.seleccionarCelda("B33");
            documento.actualizarValorCelda("Faltante Menores 500");

            documento.seleccionarCelda("B34");
            documento.actualizarValorCelda("Sobrante Menores 500");

            documento.seleccionarCelda("B35");
            documento.actualizarValorCelda("Saldo Final");
        }

        private void exportar()
        {

            documento = new DocumentoExcel();

            try
            {
                DateTime fecha = dtpFechaImpresion.Value;

                Colaborador cajero = (Colaborador)cboImpresionCajero.SelectedItem;
                if (cajero != null)
                    _seguridad.obtenerPerfilesxColaborador(ref cajero);
                Colaborador digitador = (Colaborador)cboImpresionDigitador.SelectedItem;
                Colaborador coordinador = (Colaborador)cboCoordinadorImpresion.SelectedItem;
                //tipocajero = 0;
                BindingList<CierreCajeroPROA> cierres = new BindingList<CierreCajeroPROA>();
                BindingList<CierreCajeroPROA> cierresdigitadores = new BindingList<CierreCajeroPROA>();

                documento.seleccionarHoja(1);
                
                //Lista los cierres
                //cierres = _coordinacion.listarCierresCajerosCoordinadorPROA(fecha, coordinador);
                //cierresdigitadores = _coordinacion.listarCierresDigitadoresCoordinadorPROA(fecha, coordinador);

                int hojacierre = 1;

                if (cajero != null) {
                    foreach (Perfil perfil in cajero.Perfiles)
                    {
                        if (perfil.ID == 53)
                        {
                            tipocajero = 1;
                            break;
                        }
                    }
                }                

                //Crea el nuevo cierre
                CierreCajeroPROA cierrecajero = new CierreCajeroPROA(fecha: fecha, cajero: cajero, digitador: digitador, coordinador: coordinador, tipocierre: tipocajero);
                int posicion = 3;

                if (rbImpresionCajero.Checked)
                {
                    seleccionarcajero = true;

                    this.escribirencabezado(documento, hojacierre);

                    _coordinacion.obtenerDatosCierrePROA(ref cierrecajero);

                    _cierre = cierrecajero;

                    this.llenarhoja(documento, _cierre, hojacierre, 3, 0);

                }
                else
                {
                    if (rbImpresionDigitador.Checked)
                    {

                        cierresdigitadores = _coordinacion.listarCierresCajerosDigitadorPROA(fecha, digitador);

                        seleccionarcajero = false;

                        this.escribirencabezado(documento, hojacierre);                        

                        foreach (CierreCajeroPROA numerocierredigitador in cierresdigitadores)
                        {
                            CierreCajeroPROA copia = numerocierredigitador;

                            seleccionarcajero = true;
                            _coordinacion.obtenerDatosCierrePROA(ref copia);
                            this.llenarhoja(documento, copia, hojacierre, posicion, 0);
                            this.escribirCierre(documento, copia, posicion, hojacierre);
                            posicion += 3;

                        }
                        //posicion += 3;

                        seleccionarcajero = false;
                        _coordinacion.obtenerDatosCierreDigitadorPROA(ref cierrecajero);

                        _cierre = cierrecajero;
                        this.llenarhoja(documento, _cierre, hojacierre, posicion, 1);
                        //this.escribirCierre(documento, _cierre, posicion, hojacierre);

                    }
                    else
                    {
                        if (rbImpresionCoordinador.Checked)
                        {

                            cierres = _coordinacion.listarCierresCajerosCoordinadorPROA(fecha, coordinador);
                                                        
                            this.escribirencabezado(documento, hojacierre);                                                      

                            seleccionarcajero = false;                                                        

                            foreach (CierreCajeroPROA cierre in cierres)
                            {                                

                                seleccionarcajero = true;

                                CierreCajeroPROA nuevodigitador = cierre;

                                _coordinacion.obtenerDatoDigitadorPROA(ref nuevodigitador);
                                //_cierre.Digitador = nuevodigitador.Digitador;

                                digitador = nuevodigitador.Digitador;
                                cajero = nuevodigitador.Cajero;

                                CierreCajeroPROA nuevo = new CierreCajeroPROA(fecha: fecha, cajero: cajero, digitador: digitador, coordinador: coordinador, tipocierre: nuevodigitador.TipoCierre);

                                _coordinacion.obtenerDatosCierrePROA(ref nuevo);
                                _cierre = nuevo;

                                this.llenarhoja(documento, _cierre, hojacierre, posicion, 0);
                                this.escribirCierre(documento, _cierre, posicion, hojacierre);
                                posicion += 3;

                            }

                            seleccionarcajero = false;
                            _coordinacion.obtenerDatosCierreCoordinadorPROA(ref cierrecajero);

                            _cierre = cierrecajero;
                            this.llenarhoja(documento, _cierre, hojacierre, posicion, 1);
                        }
                    }

                    hojacierre = 1;

                }
            }

            catch (Exception ex)
            {
                documento.cerrar();
                throw ex;
            }

            if (documento != null)
            {
                documento.mostrar();
            }

            documento.cerrar();
        }



        private void llenarhoja(DocumentoExcel documento, CierreCajeroPROA _cierre, int hojacierre, int posicion, byte tipo)
        {
            try
            {
                decimal totalcheques_col = 0;
                decimal totalcheques_dol = 0;
                decimal totalcheques_eur = 0;

                //this.escribirCierre(documento, _cierre, posicion, hojacierre);

                // Dar formato a la hoja

                documento.seleccionarCelda("B4");
                documento.actualizarValorCelda("Digitador:");
                documento.seleccionarSegundaCelda("B4");
                documento.formatoCelda(negrita: true, color_fondo: Color.LightGray);
                documento.cambiarTamanoColumna(22);

                if (_cierre.Digitador != null)
                {
                    documento.seleccionarCelda(4, posicion);
                    if (tipo == 0)
                    {
                        documento.actualizarValorCelda(_cierre.Digitador.ToString());
                    }
                    else
                    {
                        documento.actualizarValorCelda("Consolidado");
                    }
                    documento.formatoCelda(negrita: true);
                    documento.seleccionarSegundaCelda(4, posicion + 2);
                    documento.ajustarCeldas(AlineacionHorizontal.Centro);
                    documento.formatoTabla(false);
                }                                             

                documento.seleccionarCelda(5, posicion);
                documento.formatoCelda(negrita: true);
                documento.seleccionarSegundaCelda(5, posicion + 2);
                documento.ajustarCeldas(AlineacionHorizontal.Centro);
                documento.formatoTabla(false);

                if (seleccionarcajero == true)
                {
                    documento.seleccionarCelda("B5");
                    documento.actualizarValorCelda("Cajero:");
                    documento.formatoCelda(negrita: true, color_fondo: Color.LightGray);
                    documento.cambiarTamanoColumna(23);
                    documento.formatoTabla(false);

                    documento.seleccionarCelda(5, posicion);

                    documento.actualizarValorCelda(_cierre.Cajero.ToString());
                    documento.formatoCelda(negrita: true);
                    documento.seleccionarSegundaCelda(5, posicion + 2);
                    documento.ajustarCeldas(AlineacionHorizontal.Centro);
                    documento.formatoTabla(false);

                    documento.seleccionarCelda("B37");
                    documento.actualizarValorCelda("Observaciones:");
                    documento.formatoCelda(negrita: true, color_fondo: Color.LightGray);
                    documento.seleccionarSegundaCelda("B37");
                    documento.ajustarCeldas(AlineacionHorizontal.Centro);
                    documento.formatoTabla(false);

                    documento.seleccionarCelda("C37");
                    documento.actualizarValorCelda(_cierre.Comentarios);
                    documento.formatoCelda(negrita: true);
                    documento.cambiarTamanoFila(30);
                    documento.seleccionarSegundaCelda("E37");
                    documento.ajustarCeldas(AlineacionHorizontal.Centro);
                    documento.formatoTabla(false);

                }
                else
                {
                    if (_cierre.Coordinador != null)
                    {
                        documento.seleccionarCelda(5, posicion);
                        if (tipo == 1)
                        {
                            documento.actualizarValorCelda("Consolidado");
                        }
                    }                    
                }

                documento.seleccionarHoja(hojacierre);

                documento.seleccionarCelda(6, posicion);
                documento.seleccionarSegundaCelda(35, posicion + 2);
                documento.formatoTabla(false);

                documento.seleccionarCelda(6, posicion);
                documento.actualizarValorCelda("Colones");
                documento.formatoCelda(negrita: true, color_fondo: Color.LightGray);
                documento.ajustarCeldas(AlineacionHorizontal.Centro);
                documento.cambiarTamanoColumna(22);

                documento.seleccionarCelda(6, posicion + 1);
                documento.actualizarValorCelda("Dolares");
                documento.formatoCelda(negrita: true, color_fondo: Color.LightGray);
                documento.ajustarCeldas(AlineacionHorizontal.Centro);
                documento.cambiarTamanoColumna(22);

                documento.seleccionarCelda(6, posicion + 2);
                documento.actualizarValorCelda("Euros");
                documento.formatoCelda(negrita: true, color_fondo: Color.LightGray);
                documento.ajustarCeldas(AlineacionHorizontal.Centro);
                documento.cambiarTamanoColumna(22);

                // Escribir los valores en el excel

                documento.seleccionarCelda(7, posicion);
                documento.actualizarValorCelda(_cierre.Manifiestos.ToString("N0"));

                documento.seleccionarCelda(8, posicion);
                documento.actualizarValorCelda(_cierre.Tulas.ToString("N0"));

                documento.seleccionarCelda(9, posicion);
                documento.actualizarValorCelda(_cierre.Depositos.ToString("N0"));

                documento.seleccionarCelda(10, posicion);
                documento.actualizarValorCelda(_cierre.Cheques.ToString("N0"));

                documento.seleccionarCelda(11, posicion);
                documento.actualizarValorCelda("0");

                documento.seleccionarCelda(12, posicion);
                documento.actualizarValorCelda("0");

                // Colones

                documento.seleccionarCelda(13, posicion);
                documento.actualizarValorCelda(_cierre.Saldo_inicial_colones.ToString("N2"));

                documento.seleccionarCelda(14, posicion);
                documento.actualizarValorCelda(_cierre.Total_Suma_Manifiestos_Colones.ToString("N2"));

                documento.seleccionarCelda(15, posicion);
                documento.actualizarValorCelda(_cierre.Total_clientes_Directos_colones.ToString("N2"));

                documento.seleccionarCelda(16, posicion);
                documento.actualizarValorCelda(_cierre.Niquel_cola_Cajeros_colones.ToString("N2"));

                documento.seleccionarCelda(17, posicion);
                documento.actualizarValorCelda(_cierre.Niquel_entrega_Cajeros_colones.ToString("N2"));

                documento.seleccionarCelda(18, posicion);
                documento.actualizarValorCelda(_cierre.Niquel_procesamiento_colones.ToString("N2"));

                documento.seleccionarCelda(19, posicion);
                documento.actualizarValorCelda(_cierre.Niquel_enmesa_colones.ToString("N2"));

                documento.seleccionarCelda(20, posicion);
                documento.actualizarValorCelda(_cierre.Total_Entregas_Niquel_colones.ToString("N2"));                

                documento.seleccionarCelda(21, posicion);
                documento.actualizarValorCelda(_cierre.Niquel_Total_colones.ToString("N2"));

                documento.seleccionarCelda(22, posicion);
                documento.actualizarValorCelda(_cierre.Total_Entregas_billetes_colones.ToString("N2"));

                documento.seleccionarCelda(23, posicion);
                documento.actualizarValorCelda(_cierre.Cheques_locales_colones.ToString("N2"));

                documento.seleccionarCelda(24, posicion);
                documento.actualizarValorCelda(_cierre.Cheques_exterior_colones.ToString("N2"));

                documento.seleccionarCelda(25, posicion);
                documento.actualizarValorCelda(_cierre.Cheques_bac_colones.ToString("N2"));

                totalcheques_col = _cierre.Cheques_bac_colones + _cierre.Cheques_exterior_colones + _cierre.Cheques_locales_colones;

                documento.seleccionarCelda(26, posicion);
                documento.actualizarValorCelda(totalcheques_col.ToString("N2"));

                documento.seleccionarCelda(27, posicion);
                documento.actualizarValorCelda(_cierre.Compra_dolares_col.ToString("N2"));

                documento.seleccionarCelda(28, posicion);
                documento.actualizarValorCelda(_cierre.Venta_dolares_col.ToString("N2"));

                documento.seleccionarCelda(29, posicion);
                documento.actualizarValorCelda(_cierre.Compra_euros_col.ToString("N2"));

                documento.seleccionarCelda(30, posicion);
                documento.actualizarValorCelda(_cierre.Venta_euros_col.ToString("N2"));

                documento.seleccionarCelda(31, posicion);
                documento.actualizarValorCelda(_cierre.Faltante_clientes_colones.ToString("N2"));

                documento.seleccionarCelda(32, posicion);
                documento.actualizarValorCelda(_cierre.Sobrante_clientes_colones.ToString("N2"));

                documento.seleccionarCelda(33, posicion);
                documento.actualizarValorCelda(_cierre.Faltante_quinientos_colones.ToString("N2"));

                documento.seleccionarCelda(34, posicion);
                documento.actualizarValorCelda(_cierre.Sobrante_quinientos_colones.ToString("N2"));

                documento.seleccionarCelda(35, posicion);
                documento.actualizarValorCelda(_cierre.Saldo_final_colones.ToString("N2"));

                // Dolares

                posicion++;

                documento.seleccionarCelda(13, posicion);
                documento.actualizarValorCelda(_cierre.Saldo_final_dolares.ToString("N2"));

                documento.seleccionarCelda(14, posicion);
                documento.actualizarValorCelda(_cierre.Total_Suma_Manifiestos_dolares.ToString("N2"));

                documento.seleccionarCelda(15, posicion);
                documento.actualizarValorCelda(_cierre.Total_clientes_Directos_dolares.ToString("N2"));

                documento.seleccionarCelda(16, posicion);
                documento.actualizarValorCelda(_cierre.Niquel_cola_Cajeros_dolares.ToString("N2"));

                documento.seleccionarCelda(17, posicion);
                documento.actualizarValorCelda(_cierre.Niquel_entrega_Cajeros_dolares.ToString("N2"));

                documento.seleccionarCelda(18, posicion);
                documento.actualizarValorCelda(_cierre.Niquel_procesamiento_dolares.ToString("N2"));

                documento.seleccionarCelda(19, posicion);
                documento.actualizarValorCelda(_cierre.Niquel_enmesa_dolares.ToString("N2"));

                documento.seleccionarCelda(20, posicion);
                documento.actualizarValorCelda(_cierre.Total_Entregas_Niquel_dolares.ToString("N2"));                

                documento.seleccionarCelda(21, posicion);
                documento.actualizarValorCelda(_cierre.Niquel_Total_dolares.ToString("N2"));

                documento.seleccionarCelda(22, posicion);
                documento.actualizarValorCelda(_cierre.Total_Entregas_billetes_dolares.ToString("N2"));

                documento.seleccionarCelda(23, posicion);
                documento.actualizarValorCelda(_cierre.Cheques_locales_dolares.ToString("N2"));

                documento.seleccionarCelda(24, posicion);
                documento.actualizarValorCelda(_cierre.Cheques_exterior_dolares.ToString("N2"));

                documento.seleccionarCelda(25, posicion);
                documento.actualizarValorCelda(_cierre.Cheques_bac_dolares.ToString("N2"));

                totalcheques_dol = _cierre.Cheques_bac_dolares + _cierre.Cheques_exterior_dolares + _cierre.Cheques_locales_dolares;

                documento.seleccionarCelda(26, posicion);
                documento.actualizarValorCelda(totalcheques_dol.ToString("N2"));

                documento.seleccionarCelda(27, posicion);
                documento.actualizarValorCelda(_cierre.Compra_dolares_dol.ToString("N2"));

                documento.seleccionarCelda(28, posicion);
                documento.actualizarValorCelda(_cierre.Venta_dolares_dol.ToString("N2"));

                documento.seleccionarCelda(29, posicion);
                documento.actualizarValorCelda(0.ToString("N2"));

                documento.seleccionarCelda(30, posicion);
                documento.actualizarValorCelda(0.ToString("N2"));

                documento.seleccionarCelda(31, posicion);
                documento.actualizarValorCelda(_cierre.Faltante_clientes_dolares.ToString("N2"));

                documento.seleccionarCelda(32, posicion);
                documento.actualizarValorCelda(_cierre.Sobrante_clientes_dolares.ToString("N2"));

                documento.seleccionarCelda(33, posicion);
                documento.actualizarValorCelda(_cierre.Faltante_quinientos_dolares.ToString("N2"));

                documento.seleccionarCelda(34, posicion);
                documento.actualizarValorCelda(_cierre.Sobrante_quinientos_dolares.ToString("N2"));

                documento.seleccionarCelda(35, posicion);
                documento.actualizarValorCelda(_cierre.Saldo_final_dolares.ToString("N2"));

                //Euros

                posicion++;

                documento.seleccionarCelda(13, posicion);
                documento.actualizarValorCelda(_cierre.Saldo_final_euros.ToString("N2"));

                documento.seleccionarCelda(14, posicion);
                documento.actualizarValorCelda(_cierre.Total_Suma_Manifiestos_euros.ToString("N2"));

                documento.seleccionarCelda(15, posicion);
                documento.actualizarValorCelda(_cierre.Total_clientes_Directos_euros.ToString("N2"));

                documento.seleccionarCelda(16, posicion);
                documento.actualizarValorCelda(_cierre.Niquel_cola_Cajeros_euros.ToString("N2"));

                documento.seleccionarCelda(17, posicion);
                documento.actualizarValorCelda(_cierre.Niquel_entrega_Cajeros_euros.ToString("N2"));

                documento.seleccionarCelda(18, posicion);
                documento.actualizarValorCelda(_cierre.Niquel_procesamiento_euros.ToString("N2"));

                documento.seleccionarCelda(19, posicion);
                documento.actualizarValorCelda(_cierre.Niquel_enmesa_euros.ToString("N2"));

                documento.seleccionarCelda(20, posicion);
                documento.actualizarValorCelda(_cierre.Total_Entregas_Niquel_euros.ToString("N2"));

                documento.seleccionarCelda(21, posicion);
                documento.actualizarValorCelda(_cierre.Niquel_Total_euros.ToString("N2"));

                documento.seleccionarCelda(22, posicion);
                documento.actualizarValorCelda(_cierre.Total_Entregas_billetes_euros.ToString("N2"));

                documento.seleccionarCelda(23, posicion);
                documento.actualizarValorCelda(_cierre.Cheques_locales_euros.ToString("N2"));

                documento.seleccionarCelda(24, posicion);
                documento.actualizarValorCelda(_cierre.Cheques_exterior_euros.ToString("N2"));

                documento.seleccionarCelda(25, posicion);
                documento.actualizarValorCelda(_cierre.Cheques_bac_euros.ToString("N2"));

                totalcheques_eur = _cierre.Cheques_bac_euros + _cierre.Cheques_exterior_euros + _cierre.Cheques_locales_euros;

                documento.seleccionarCelda(26, posicion);
                documento.actualizarValorCelda(totalcheques_eur.ToString("N2"));

                documento.seleccionarCelda(27, posicion);
                documento.actualizarValorCelda("0,00");

                documento.seleccionarCelda(28, posicion);
                documento.actualizarValorCelda("0,00");

                documento.seleccionarCelda(29, posicion);
                documento.actualizarValorCelda(_cierre.Compra_euros_eur.ToString("N2"));

                documento.seleccionarCelda(30, posicion);
                documento.actualizarValorCelda(_cierre.Venta_euros_eur.ToString("N2"));

                documento.seleccionarCelda(31, posicion);
                documento.actualizarValorCelda(_cierre.Faltante_clientes_euros.ToString("N2"));

                documento.seleccionarCelda(32, posicion);
                documento.actualizarValorCelda(_cierre.Sobrante_clientes_euros.ToString("N2"));

                documento.seleccionarCelda(33, posicion);
                documento.actualizarValorCelda(_cierre.Faltante_quinientos_euros.ToString("N2"));

                documento.seleccionarCelda(34, posicion);
                documento.actualizarValorCelda(_cierre.Sobrante_quinientos_euros.ToString("N2"));

                documento.seleccionarCelda(35, posicion);
                documento.actualizarValorCelda(_cierre.Saldo_final_euros.ToString("N2"));

                documento.seleccionarCelda(37, posicion);
                documento.actualizarValorCelda(_cierre.Comentarios);

                // Escribir el consolidado y dar formato a la tabla

                //posicion++;

                documento.seleccionarCelda("B2");
                documento.actualizarValorCelda("Coordinador: " + _cierre.Coordinador);
                documento.seleccionarSegundaCelda("E2");
                documento.ajustarCeldas(AlineacionHorizontal.Centro);

                documento.seleccionarCelda("B3");
                documento.actualizarValorCelda("Fecha: " + _cierre.Fecha.ToShortDateString());
                documento.seleccionarSegundaCelda("E3");
                documento.ajustarCeldas(AlineacionHorizontal.Centro);

                documento.seleccionarCelda("B2");
                documento.seleccionarSegundaCelda("E3");
                documento.formatoCelda(color_fondo: Color.LightGray);
                documento.formatoTabla(false);

                documento.seleccionarCelda("B1");
                documento.cambiarTamanoColumna(20);

                /*documento.seleccionarCelda("B7");
                documento.seleccionarSegundaCelda("E7");
                documento.formatoCelda(negrita: true, color_fondo: Color.LightGray);
                documento.formatoTabla(false);*/

                documento.seleccionarCelda("B7");
                documento.seleccionarSegundaCelda(12, posicion);
                documento.formatoTabla(false);

                documento.seleccionarCelda("B14");
                documento.seleccionarSegundaCelda(35, posicion);
                documento.formatoTabla(false);

                documento.seleccionarCelda("B13");
                documento.seleccionarSegundaCelda(13, posicion);
                documento.formatoTabla(false);

                documento.seleccionarCelda("B35");
                documento.seleccionarSegundaCelda(35, posicion);
                documento.formatoTabla(false);
            }
            catch (Excepcion ex)
            {
                MessageBox.Show(ex.Message);
            }            


        }

        /// Escribir un cierre en el reporte de cierres.
        /// </summary>
        private void escribirCierre(DocumentoExcel documento, CierreCajeroPROA _cierre, int posicion, int hojacierre)
        {

            //decimal compra_dolares_colones = _cierre.Compra_dolares_col;
            //decimal venta_dolares_dolares = Math.Round(_cierre.Venta_dolares_dol, 2);
            decimal compra_dolares_colones = _cierre.Compra_dolares_col * _tipo_cambio_impresion.Compra;
            decimal venta_dolares_dolares = Math.Round(_cierre.Venta_dolares_dol / _tipo_cambio_impresion.Venta, 2);

            // Calculo de los montos en colones

            //decimal diferencia_colones = _cierre.Ingreso_clientes_colones - _cierre.Reporte_cajero_colones;

             decimal saldo_cierre_colones = _cierre.Saldo_final_colones;

            decimal faltante_sobrante_colones = _cierre.Sobrante_clientes_colones + _cierre.Faltante_clientes_colones;

            // Calculo de los montos en dolares

            /*decimal diferencia_dolares = _cierre.Ingreso_clientes_dolares - _cierre.Reporte_cajero_dolares;*/

            decimal saldo_cierre_dolares = _cierre.Saldo_final_dolares;

            decimal faltante_sobrante_dolares = _cierre.Sobrante_clientes_dolares + _cierre.Faltante_clientes_dolares;

            documento.seleccionarHoja(hojacierre);

            //int niquel = 0;

            /*if (_cierre.Faltante_cliente_niquel_colones > 0 || _cierre.Sobrante_cliente_niquel_colones > 0)
            {
                niquel = 2;
            }


            documento.seleccionarCelda(15, posicion);
            documento.actualizarValorCelda(diferencia_colones.ToString("N2"));*/

            /*documento.seleccionarCelda(31, posicion);
            documento.actualizarValorCelda(compra_dolares_colones.ToString("N2"));

            documento.seleccionarCelda(32, posicion);
            documento.actualizarValorCelda(_cierre.Venta_dolares_dol.ToString("N2"));

            documento.seleccionarCelda(33, posicion);
            documento.actualizarValorCelda(saldo_cierre_colones.ToString("N2"));

            documento.seleccionarCelda(34, posicion);
            documento.actualizarValorCelda(faltante_sobrante_colones.ToString("N2"));*/

            // Dolares

            /*documento.seleccionarCelda(15, posicion + 1);
            documento.actualizarValorCelda(diferencia_dolares.ToString("N2"));

            documento.seleccionarCelda(31, posicion + 1);
            documento.actualizarValorCelda(_cierre.Compra_dolares_col.ToString("N2"));

            documento.seleccionarCelda(32 + niquel, posicion + 1);
            documento.actualizarValorCelda(venta_dolares_dolares.ToString("N2"));

            documento.seleccionarCelda(33 + niquel, posicion + 1);
            documento.actualizarValorCelda(saldo_cierre_dolares.ToString("N2"));

            /*documento.seleccionarCelda(34 + niquel, posicion + 1);
            documento.actualizarValorCelda(faltante_sobrante_dolares.ToString("N2"));*/
        }

        #endregion Métodos Privados

        private void chkNiquel_CheckedChanged(object sender, EventArgs e)
        {            
            dgvCierre.Rows.Clear();
            this.crearTabla(dgvCierre, tipocajero);
        }

        private void cboCajero_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCajero.SelectedIndex > -1)
            {
                epError.SetError(cboCajero, "");
                tipocajero = 0;
                datoscierre = new DataTable();
                btnSaldoInicial.Enabled = true;
                Colaborador cajeroinfo = (Colaborador)cboCajero.SelectedItem;
                _seguridad.obtenerPerfilesxColaborador(ref cajeroinfo);
                string fecha = dtpFecha.Value.Year.ToString() + '-' + dtpFecha.Value.Month.ToString() + '-' + dtpFecha.Value.Day.ToString();
                foreach (Perfil perfil in cajeroinfo.Perfiles)
                {
                    if (perfil.ID == 73)
                    {
                        tipocajero = 1;                        
                        break;
                    }
                }                
                if (tipocajero == 0)
                {
                    chkNiquel.Checked = false;
                    dgvCierre.Rows.Clear();
                    this.crearTabla(dgvCierre, tipocajero);
                    datoscierre = _mantenimiento.ObtenerdatoscierreCajero(cajeroinfo.ID, fecha, fecha);
                }
                else
                {
                    chkNiquel.Checked = true;
                    dgvCierre.Rows.Clear();
                    this.crearTabla(dgvCierre, tipocajero);
                    datoscierre = _mantenimiento.ObtenerdatoscierreCajeroNiquel(cajeroinfo.ID, fecha, fecha);
                }
                actualizartabla(tipocajero, datoscierre);
                if (datoscierre.Columns.Count == 44)                    
                    calcularsaldofinal(tipocajero);                             
                if ((int)datoscierre.Rows[0]["Coordinador"] != 0)
                {
                    chkcoordinador = 0;
                    Colaborador coordinador = new Colaborador(id: (int)datoscierre.Rows[0]["Coordinador"]);
                    cboCoordinador.SelectedItem = coordinador;
                    chkcoordinador = 1;
                }
                else
                {
                    cboCoordinador.SelectedItem = _colaborador;
                }
                if ((int)datoscierre.Rows[0]["Digitador"] != 0)
                {
                    Colaborador digitador = new Colaborador(id: (int)datoscierre.Rows[0]["Digitador"]);
                    cboDigitador.SelectedItem = digitador;
                }
                else
                {
                    cboDigitador.SelectedItem = null;
                }
            }
        }        

        private void calcularsaldofinal(byte tipocajero)
        {
            try
            {
                if (tipocajero == 0)
                {
                    decimal calculocolones = Convert.ToDecimal(dgvCierre.Rows[0].Cells[1].Value) + Convert.ToDecimal(dgvCierre.Rows[1].Cells[1].Value) - (Convert.ToDecimal(dgvCierre.Rows[2].Cells[1].Value) + 
                        Convert.ToDecimal(dgvCierre.Rows[3].Cells[1].Value) + Convert.ToDecimal(dgvCierre.Rows[4].Cells[1].Value) + Convert.ToDecimal(dgvCierre.Rows[7].Cells[1].Value) +
                        Convert.ToDecimal(dgvCierre.Rows[8].Cells[1].Value) + Convert.ToDecimal(dgvCierre.Rows[10].Cells[1].Value) + Convert.ToDecimal(dgvCierre.Rows[12].Cells[1].Value) + 
                        -Convert.ToDecimal(dgvCierre.Rows[13].Cells[1].Value) + -Convert.ToDecimal(dgvCierre.Rows[15].Cells[1].Value)) + Convert.ToDecimal(dgvCierre.Rows[14].Cells[1].Value) + 
                        Convert.ToDecimal(dgvCierre.Rows[16].Cells[1].Value) + Convert.ToDecimal(dgvCierre.Rows[9].Cells[1].Value) + Convert.ToDecimal(dgvCierre.Rows[11].Cells[1].Value);
                    decimal calculodolares = Convert.ToDecimal(dgvCierre.Rows[0].Cells[2].Value) + Convert.ToDecimal(dgvCierre.Rows[1].Cells[2].Value) - (Convert.ToDecimal(dgvCierre.Rows[2].Cells[2].Value) +
                        Convert.ToDecimal(dgvCierre.Rows[3].Cells[2].Value) + Convert.ToDecimal(dgvCierre.Rows[4].Cells[2].Value) + Convert.ToDecimal(dgvCierre.Rows[7].Cells[2].Value) +
                        Convert.ToDecimal(dgvCierre.Rows[8].Cells[2].Value) + Convert.ToDecimal(dgvCierre.Rows[10].Cells[2].Value) + Convert.ToDecimal(dgvCierre.Rows[12].Cells[2].Value) + 
                        -Convert.ToDecimal(dgvCierre.Rows[13].Cells[2].Value) + -Convert.ToDecimal(dgvCierre.Rows[15].Cells[2].Value)) + Convert.ToDecimal(dgvCierre.Rows[9].Cells[2].Value) + 
                        Convert.ToDecimal(dgvCierre.Rows[14].Cells[2].Value) + Convert.ToDecimal(dgvCierre.Rows[16].Cells[2].Value) + Convert.ToDecimal(dgvCierre.Rows[11].Cells[2].Value);
                    decimal calculoeuros = Convert.ToDecimal(dgvCierre.Rows[0].Cells[3].Value) + Convert.ToDecimal(dgvCierre.Rows[1].Cells[3].Value) - (Convert.ToDecimal(dgvCierre.Rows[2].Cells[3].Value) +
                        Convert.ToDecimal(dgvCierre.Rows[3].Cells[3].Value) + Convert.ToDecimal(dgvCierre.Rows[4].Cells[3].Value) + Convert.ToDecimal(dgvCierre.Rows[7].Cells[3].Value) + 
                        Convert.ToDecimal(dgvCierre.Rows[8].Cells[3].Value) + Convert.ToDecimal(dgvCierre.Rows[10].Cells[3].Value) + Convert.ToDecimal(dgvCierre.Rows[12].Cells[3].Value) +
                        -Convert.ToDecimal(dgvCierre.Rows[13].Cells[3].Value) + -Convert.ToDecimal(dgvCierre.Rows[15].Cells[3].Value)) + Convert.ToDecimal(dgvCierre.Rows[9].Cells[3].Value) +
                        Convert.ToDecimal(dgvCierre.Rows[14].Cells[3].Value) + Convert.ToDecimal(dgvCierre.Rows[16].Cells[3].Value) + Convert.ToDecimal(dgvCierre.Rows[11].Cells[3].Value);
                    dgvCierre.Rows[17].Cells[1].Value = calculocolones;
                    dgvCierre.Rows[17].Cells[2].Value = calculodolares;
                    dgvCierre.Rows[17].Cells[3].Value = calculoeuros;
                }
                else
                {
                    decimal calculocolones = Convert.ToDecimal(dgvCierre.Rows[0].Cells[1].Value) + Convert.ToDecimal(dgvCierre.Rows[1].Cells[1].Value) + Convert.ToDecimal(dgvCierre.Rows[2].Cells[1].Value) +
                        Convert.ToDecimal(dgvCierre.Rows[3].Cells[1].Value) + Convert.ToDecimal(dgvCierre.Rows[4].Cells[1].Value) - (Convert.ToDecimal(dgvCierre.Rows[7].Cells[1].Value) + 
                        Convert.ToDecimal(dgvCierre.Rows[8].Cells[1].Value) + Convert.ToDecimal(dgvCierre.Rows[12].Cells[1].Value) + Convert.ToDecimal(dgvCierre.Rows[14].Cells[1].Value) + 
                        -Convert.ToDecimal(dgvCierre.Rows[17].Cells[1].Value) + -Convert.ToDecimal(dgvCierre.Rows[19].Cells[1].Value) + Convert.ToDecimal(dgvCierre.Rows[16].Cells[1].Value)) + 
                        Convert.ToDecimal(dgvCierre.Rows[18].Cells[1].Value) + Convert.ToDecimal(dgvCierre.Rows[20].Cells[1].Value) + Convert.ToDecimal(dgvCierre.Rows[13].Cells[1].Value) + 
                        Convert.ToDecimal(dgvCierre.Rows[15].Cells[1].Value);
                    decimal calculodolares = Convert.ToDecimal(dgvCierre.Rows[0].Cells[2].Value) + Convert.ToDecimal(dgvCierre.Rows[1].Cells[2].Value) + Convert.ToDecimal(dgvCierre.Rows[2].Cells[2].Value) +
                        Convert.ToDecimal(dgvCierre.Rows[3].Cells[2].Value) + Convert.ToDecimal(dgvCierre.Rows[4].Cells[2].Value) - (Convert.ToDecimal(dgvCierre.Rows[7].Cells[2].Value) + 
                        Convert.ToDecimal(dgvCierre.Rows[8].Cells[2].Value) + Convert.ToDecimal(dgvCierre.Rows[12].Cells[2].Value) + Convert.ToDecimal(dgvCierre.Rows[14].Cells[2].Value) + 
                        -Convert.ToDecimal(dgvCierre.Rows[17].Cells[2].Value) + -Convert.ToDecimal(dgvCierre.Rows[19].Cells[2].Value) + Convert.ToDecimal(dgvCierre.Rows[16].Cells[2].Value)) + 
                        Convert.ToDecimal(dgvCierre.Rows[18].Cells[2].Value) + Convert.ToDecimal(dgvCierre.Rows[20].Cells[2].Value) + Convert.ToDecimal(dgvCierre.Rows[13].Cells[2].Value) + 
                        Convert.ToDecimal(dgvCierre.Rows[15].Cells[2].Value);
                    decimal calculoeuros = Convert.ToDecimal(dgvCierre.Rows[0].Cells[3].Value) + Convert.ToDecimal(dgvCierre.Rows[1].Cells[3].Value) + Convert.ToDecimal(dgvCierre.Rows[2].Cells[3].Value) +
                        Convert.ToDecimal(dgvCierre.Rows[3].Cells[3].Value) + Convert.ToDecimal(dgvCierre.Rows[4].Cells[3].Value) - (Convert.ToDecimal(dgvCierre.Rows[7].Cells[3].Value) + 
                        Convert.ToDecimal(dgvCierre.Rows[8].Cells[3].Value) + Convert.ToDecimal(dgvCierre.Rows[12].Cells[3].Value) + Convert.ToDecimal(dgvCierre.Rows[14].Cells[3].Value) 
                        + -Convert.ToDecimal(dgvCierre.Rows[17].Cells[3].Value) + -Convert.ToDecimal(dgvCierre.Rows[19].Cells[3].Value) + Convert.ToDecimal(dgvCierre.Rows[16].Cells[3].Value)) + 
                        Convert.ToDecimal(dgvCierre.Rows[18].Cells[3].Value) + Convert.ToDecimal(dgvCierre.Rows[20].Cells[3].Value) + Convert.ToDecimal(dgvCierre.Rows[13].Cells[3].Value) + 
                        Convert.ToDecimal(dgvCierre.Rows[15].Cells[3].Value);
                    dgvCierre.Rows[21].Cells[1].Value = calculocolones;
                    dgvCierre.Rows[21].Cells[2].Value = calculodolares;
                    dgvCierre.Rows[21].Cells[3].Value = calculoeuros;
                }
            }
            catch (Excepcion ex) {
                MessageBox.Show(ex.Message);
            }
        }

        public void permisocoordinador(int ID_Coordinador)
        {
            permisosup = true;
            _coordinador = ID_Coordinador;
            
        }

        private void btnAñadirSI_Click(object sender, EventArgs e)
        {
            switch (cboMoneda.SelectedIndex)
            {
                case 0:
                    dgvCierre.Rows[0].Cells[1].Value = nudMonto.Value + nudNiquel.Value;
                    dgvCierre.Rows[5].Cells[1].Value = Convert.ToDecimal(datoscierre.Rows[0][12]) + Convert.ToDecimal(nudNiquel.Value);
                    dgvCierre.Rows[8].Cells[1].Value = Convert.ToDecimal(datoscierre.Rows[0][14]) + Convert.ToDecimal(nudMonto.Value);                    
                    break;
                case 1:
                    dgvCierre.Rows[0].Cells[2].Value = nudMonto.Value;
                    dgvCierre.Rows[8].Cells[1].Value = Convert.ToDecimal(datoscierre.Rows[0][15]) + Convert.ToDecimal(nudMonto.Value);                    
                    break;
                case 2:
                    dgvCierre.Rows[0].Cells[3].Value = nudMonto.Value;
                    dgvCierre.Rows[8].Cells[3].Value = Convert.ToDecimal(datoscierre.Rows[0][16]) + Convert.ToDecimal(nudMonto.Value);                    
                    break;
            }
            calcularsaldofinal(tipocajero);
            cboMoneda.Enabled = false;
            nudMonto.Enabled = false;
            nudMonto.Value = 0;
            nudNiquel.Enabled = false;
            nudNiquel.Value = 0;
            btnAñadirSI.Enabled = false;            
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            imprimirCierreCajeroNiquel(tipocajero);
            if (tipocajero == 1)
            {
                datosniquel = new DataTable();
                Colaborador cajeroinfo = (Colaborador)cboCajero.SelectedItem;
                string fecha = dtpFecha.Value.Year.ToString() + '-' + dtpFecha.Value.Month.ToString() + '-' + dtpFecha.Value.Day.ToString();
                datosniquel = _mantenimiento.ObtenerdatosFormularioMoneda(cajeroinfo.ID, fecha, fecha);
                imprimirFormularioEntrega();
            }
        }

        private void imprimirFormularioEntrega()
        {
            try
            {
                DocumentoExcel documento2;
                documento2 = new DocumentoExcel(Application.StartupPath + "\\Plantillas\\plantilla entrega_moneda.xlsx", false);
                documento2.seleccionarHoja(1);
                documento2.seleccionarCelda("B11");
                documento2.actualizarValorCelda(datosniquel.Rows[0][5].ToString().Replace(",","."));
                documento2.seleccionarCelda("B12");
                documento2.actualizarValorCelda(datosniquel.Rows[0][4].ToString().Replace(",", "."));
                documento2.seleccionarCelda("B13");
                documento2.actualizarValorCelda(datosniquel.Rows[0][3].ToString().Replace(",", "."));
                documento2.seleccionarCelda("B14");
                documento2.actualizarValorCelda(datosniquel.Rows[0][2].ToString().Replace(",", "."));
                documento2.seleccionarCelda("B15");
                documento2.actualizarValorCelda(datosniquel.Rows[0][1].ToString().Replace(",", "."));
                documento2.seleccionarCelda("B16");
                documento2.actualizarValorCelda(datosniquel.Rows[0][0].ToString().Replace(",", "."));
                documento2.mostrar();
                documento2.cerrar();
            }
            catch (Excepcion ex)
            {
                Excepcion.mostrarMensaje(ex.Message);
            }
        }

        private void imprimirCierreCajeroNiquel(byte tipocajero)
        {

            try
            {
                DocumentoExcel documento;
                if (tipocajero == 0)
                {
                    documento = new DocumentoExcel(Application.StartupPath + "\\Plantillas\\plantilla cierre_diario_cajero.xlsx", false);
                }
                else
                {
                    documento = new DocumentoExcel(Application.StartupPath + "\\Plantillas\\plantilla cierre_diario_cajero_niquel.xlsx", false);
                }

                documento.seleccionarHoja(1);

                if (tipocajero == 0)
                {
                    documento.seleccionarCelda("A7");
                    documento.actualizarValorCelda("FECHA: " + DateTime.Today.ToShortDateString());
                    documento.seleccionarCelda("A8");
                    documento.actualizarValorCelda("MANIFIESTOS PROCESADOS: " + lblNumManifiestos.Text);

                    documento.seleccionarCelda("C12");
                    documento.actualizarValorCelda(dgvCierre.Rows[2].Cells[1].Value.ToString().Replace(",", "."));
                    documento.seleccionarCelda("D12");
                    documento.actualizarValorCelda(dgvCierre.Rows[2].Cells[2].Value.ToString().Replace(",", "."));

                    documento.seleccionarCelda("C13");
                    documento.actualizarValorCelda(dgvCierre.Rows[4].Cells[1].Value.ToString().Replace(",", "."));
                    documento.seleccionarCelda("D13");
                    documento.actualizarValorCelda(dgvCierre.Rows[4].Cells[2].Value.ToString().Replace(",", "."));

                    documento.seleccionarCelda("C14");
                    documento.actualizarValorCelda(dgvCierre.Rows[3].Cells[1].Value.ToString().Replace(",", "."));
                    documento.seleccionarCelda("D14");
                    documento.actualizarValorCelda(dgvCierre.Rows[3].Cells[2].Value.ToString().Replace(",", "."));

                    documento.seleccionarCelda("C18");
                    documento.actualizarValorCelda(dgvCierre.Rows[0].Cells[1].Value.ToString().Replace(",", "."));
                    documento.seleccionarCelda("D18");
                    documento.actualizarValorCelda(dgvCierre.Rows[0].Cells[2].Value.ToString().Replace(",", "."));
                    documento.seleccionarCelda("E18");
                    documento.actualizarValorCelda(dgvCierre.Rows[0].Cells[3].Value.ToString().Replace(",", "."));

                    documento.seleccionarCelda("C19");
                    documento.actualizarValorCelda(dgvCierre.Rows[1].Cells[1].Value.ToString().Replace(",", "."));
                    documento.seleccionarCelda("D19");
                    documento.actualizarValorCelda(dgvCierre.Rows[1].Cells[2].Value.ToString().Replace(",", "."));
                    documento.seleccionarCelda("E19");
                    documento.actualizarValorCelda(dgvCierre.Rows[1].Cells[3].Value.ToString().Replace(",", "."));

                    documento.seleccionarCelda("C20");
                    documento.actualizarValorCelda(dgvCierre.Rows[2].Cells[1].Value.ToString().Replace(",", "."));
                    documento.seleccionarCelda("D20");
                    documento.actualizarValorCelda(dgvCierre.Rows[2].Cells[2].Value.ToString().Replace(",", "."));
                    documento.seleccionarCelda("E20");
                    documento.actualizarValorCelda(dgvCierre.Rows[2].Cells[3].Value.ToString().Replace(",", "."));

                    documento.seleccionarCelda("C21");
                    documento.actualizarValorCelda(dgvCierre.Rows[3].Cells[1].Value.ToString().Replace(",", "."));
                    documento.seleccionarCelda("D21");
                    documento.actualizarValorCelda(dgvCierre.Rows[3].Cells[2].Value.ToString().Replace(",", "."));
                    documento.seleccionarCelda("E21");
                    documento.actualizarValorCelda(dgvCierre.Rows[3].Cells[3].Value.ToString().Replace(",", "."));

                    documento.seleccionarCelda("C22");
                    documento.actualizarValorCelda(dgvCierre.Rows[4].Cells[1].Value.ToString().Replace(",", "."));
                    documento.seleccionarCelda("D22");
                    documento.actualizarValorCelda(dgvCierre.Rows[4].Cells[2].Value.ToString().Replace(",", "."));
                    documento.seleccionarCelda("E22");
                    documento.actualizarValorCelda(dgvCierre.Rows[4].Cells[3].Value.ToString().Replace(",", "."));

                    documento.seleccionarCelda("C23");
                    documento.actualizarValorCelda(dgvCierre.Rows[5].Cells[1].Value.ToString().Replace(",", "."));
                    documento.seleccionarCelda("D23");
                    documento.actualizarValorCelda(dgvCierre.Rows[5].Cells[2].Value.ToString().Replace(",", "."));
                    documento.seleccionarCelda("E23");
                    documento.actualizarValorCelda(dgvCierre.Rows[5].Cells[3].Value.ToString().Replace(",", "."));

                    documento.seleccionarCelda("C24");
                    documento.actualizarValorCelda(dgvCierre.Rows[6].Cells[1].Value.ToString().Replace(",", "."));
                    documento.seleccionarCelda("D24");
                    documento.actualizarValorCelda(dgvCierre.Rows[6].Cells[2].Value.ToString().Replace(",", "."));
                    documento.seleccionarCelda("E24");
                    documento.actualizarValorCelda(dgvCierre.Rows[6].Cells[3].Value.ToString().Replace(",", "."));

                    documento.seleccionarCelda("C25");
                    documento.actualizarValorCelda(dgvCierre.Rows[7].Cells[1].Value.ToString().Replace(",", "."));
                    documento.seleccionarCelda("D25");
                    documento.actualizarValorCelda(dgvCierre.Rows[7].Cells[2].Value.ToString().Replace(",", "."));
                    documento.seleccionarCelda("E25");
                    documento.actualizarValorCelda(dgvCierre.Rows[7].Cells[3].Value.ToString().Replace(",", "."));

                    documento.seleccionarCelda("C26");
                    documento.actualizarValorCelda(dgvCierre.Rows[8].Cells[1].Value.ToString().Replace(",", "."));
                    documento.seleccionarCelda("D26");
                    documento.actualizarValorCelda(dgvCierre.Rows[8].Cells[2].Value.ToString().Replace(",", "."));
                    documento.seleccionarCelda("E26");
                    documento.actualizarValorCelda(dgvCierre.Rows[8].Cells[3].Value.ToString().Replace(",", "."));

                    documento.seleccionarCelda("C27");
                    documento.actualizarValorCelda(dgvCierre.Rows[9].Cells[1].Value.ToString().Replace(",", "."));
                    documento.seleccionarCelda("D27");
                    documento.actualizarValorCelda(dgvCierre.Rows[9].Cells[2].Value.ToString().Replace(",", "."));
                    documento.seleccionarCelda("E27");
                    documento.actualizarValorCelda(dgvCierre.Rows[9].Cells[3].Value.ToString().Replace(",", "."));

                    documento.seleccionarCelda("C28");
                    documento.actualizarValorCelda(dgvCierre.Rows[10].Cells[1].Value.ToString().Replace(",", "."));
                    documento.seleccionarCelda("D28");
                    documento.actualizarValorCelda(dgvCierre.Rows[10].Cells[2].Value.ToString().Replace(",", "."));
                    documento.seleccionarCelda("E28");
                    documento.actualizarValorCelda(dgvCierre.Rows[10].Cells[3].Value.ToString().Replace(",", "."));

                    documento.seleccionarCelda("C29");
                    documento.actualizarValorCelda(dgvCierre.Rows[11].Cells[1].Value.ToString().Replace(",", "."));
                    documento.seleccionarCelda("D29");
                    documento.actualizarValorCelda(dgvCierre.Rows[11].Cells[2].Value.ToString().Replace(",", "."));
                    documento.seleccionarCelda("E29");
                    documento.actualizarValorCelda(dgvCierre.Rows[11].Cells[3].Value.ToString().Replace(",", "."));

                    documento.seleccionarCelda("C30");
                    documento.actualizarValorCelda(dgvCierre.Rows[12].Cells[1].Value.ToString().Replace(",", "."));
                    documento.seleccionarCelda("D30");
                    documento.actualizarValorCelda(dgvCierre.Rows[12].Cells[2].Value.ToString().Replace(",", "."));
                    documento.seleccionarCelda("E30");
                    documento.actualizarValorCelda(dgvCierre.Rows[12].Cells[3].Value.ToString().Replace(",", "."));

                    documento.seleccionarCelda("C31");
                    documento.actualizarValorCelda(dgvCierre.Rows[13].Cells[1].Value.ToString().Replace(",", "."));
                    documento.seleccionarCelda("D31");
                    documento.actualizarValorCelda(dgvCierre.Rows[13].Cells[2].Value.ToString().Replace(",", "."));
                    documento.seleccionarCelda("E31");
                    documento.actualizarValorCelda(dgvCierre.Rows[13].Cells[3].Value.ToString().Replace(",", "."));

                    documento.seleccionarCelda("C32");
                    documento.actualizarValorCelda(dgvCierre.Rows[14].Cells[1].Value.ToString().Replace(",", "."));
                    documento.seleccionarCelda("D32");
                    documento.actualizarValorCelda(dgvCierre.Rows[14].Cells[2].Value.ToString().Replace(",", "."));
                    documento.seleccionarCelda("E32");
                    documento.actualizarValorCelda(dgvCierre.Rows[14].Cells[3].Value.ToString().Replace(",", "."));

                    documento.seleccionarCelda("C33");
                    documento.actualizarValorCelda(dgvCierre.Rows[15].Cells[1].Value.ToString().Replace(",", "."));
                    documento.seleccionarCelda("D33");
                    documento.actualizarValorCelda(dgvCierre.Rows[15].Cells[2].Value.ToString().Replace(",", "."));
                    documento.seleccionarCelda("E33");
                    documento.actualizarValorCelda(dgvCierre.Rows[15].Cells[3].Value.ToString().Replace(",", "."));

                    documento.seleccionarCelda("C34");
                    documento.actualizarValorCelda(dgvCierre.Rows[16].Cells[1].Value.ToString().Replace(",", "."));
                    documento.seleccionarCelda("D34");
                    documento.actualizarValorCelda(dgvCierre.Rows[16].Cells[2].Value.ToString().Replace(",", "."));
                    documento.seleccionarCelda("E34");
                    documento.actualizarValorCelda(dgvCierre.Rows[16].Cells[3].Value.ToString().Replace(",", "."));

                    documento.seleccionarCelda("C36");
                    documento.actualizarValorCelda(dgvCierre.Rows[17].Cells[1].Value.ToString().Replace(",", "."));
                    documento.seleccionarCelda("D36");
                    documento.actualizarValorCelda(dgvCierre.Rows[17].Cells[2].Value.ToString().Replace(",", "."));
                    documento.seleccionarCelda("E36");
                    documento.actualizarValorCelda(dgvCierre.Rows[17].Cells[3].Value.ToString().Replace(",", "."));                    
                }
                else
                {
                    documento.seleccionarCelda("A6");
                    documento.actualizarValorCelda("FECHA: " + DateTime.Today.ToShortDateString());
                    documento.seleccionarCelda("A7");
                    documento.actualizarValorCelda("MANIFIESTOS PROCESADOS: " + lblNumManifiestos.Text);

                    documento.seleccionarCelda("C11");
                    documento.actualizarValorCelda(dgvCierre.Rows[9].Cells[1].Value.ToString().Replace(",", "."));
                    documento.seleccionarCelda("D11");
                    documento.actualizarValorCelda(dgvCierre.Rows[9].Cells[2].Value.ToString().Replace(",", "."));

                    documento.seleccionarCelda("C12");
                    documento.actualizarValorCelda(dgvCierre.Rows[10].Cells[1].Value.ToString().Replace(",", "."));
                    documento.seleccionarCelda("D12");
                    documento.actualizarValorCelda(dgvCierre.Rows[10].Cells[2].Value.ToString().Replace(",", "."));

                    documento.seleccionarCelda("C13");
                    documento.actualizarValorCelda(dgvCierre.Rows[10].Cells[1].Value.ToString().Replace(",", "."));
                    documento.seleccionarCelda("D13");
                    documento.actualizarValorCelda(dgvCierre.Rows[10].Cells[2].Value.ToString().Replace(",", "."));

                    documento.seleccionarCelda("C19");
                    documento.actualizarValorCelda(dgvCierre.Rows[0].Cells[1].Value.ToString().Replace(",", "."));
                    documento.seleccionarCelda("D19");
                    documento.actualizarValorCelda(dgvCierre.Rows[0].Cells[2].Value.ToString().Replace(",", "."));
                    documento.seleccionarCelda("F19");
                    documento.actualizarValorCelda(dgvCierre.Rows[0].Cells[3].Value.ToString().Replace(",", "."));

                    documento.seleccionarCelda("C20");
                    documento.actualizarValorCelda(dgvCierre.Rows[1].Cells[1].Value.ToString().Replace(",", "."));
                    documento.seleccionarCelda("D20");
                    documento.actualizarValorCelda(dgvCierre.Rows[1].Cells[2].Value.ToString().Replace(",", "."));
                    documento.seleccionarCelda("F20");
                    documento.actualizarValorCelda(dgvCierre.Rows[1].Cells[3].Value.ToString().Replace(",", "."));

                    documento.seleccionarCelda("C21");
                    documento.actualizarValorCelda(dgvCierre.Rows[2].Cells[1].Value.ToString().Replace(",", "."));
                    documento.seleccionarCelda("D21");
                    documento.actualizarValorCelda(dgvCierre.Rows[2].Cells[2].Value.ToString().Replace(",", "."));
                    documento.seleccionarCelda("F21");
                    documento.actualizarValorCelda(dgvCierre.Rows[2].Cells[3].Value.ToString().Replace(",", "."));

                    documento.seleccionarCelda("C22");
                    documento.actualizarValorCelda(dgvCierre.Rows[3].Cells[1].Value.ToString().Replace(",", "."));
                    documento.seleccionarCelda("D22");
                    documento.actualizarValorCelda(dgvCierre.Rows[3].Cells[2].Value.ToString().Replace(",", "."));
                    documento.seleccionarCelda("F22");
                    documento.actualizarValorCelda(dgvCierre.Rows[3].Cells[3].Value.ToString().Replace(",", "."));

                    documento.seleccionarCelda("C23");
                    documento.actualizarValorCelda(dgvCierre.Rows[4].Cells[1].Value.ToString().Replace(",", "."));
                    documento.seleccionarCelda("D23");
                    documento.actualizarValorCelda(dgvCierre.Rows[4].Cells[2].Value.ToString().Replace(",", "."));
                    documento.seleccionarCelda("F23");
                    documento.actualizarValorCelda(dgvCierre.Rows[4].Cells[3].Value.ToString().Replace(",", "."));

                    documento.seleccionarCelda("C24");
                    documento.actualizarValorCelda(dgvCierre.Rows[5].Cells[1].Value.ToString().Replace(",", "."));
                    documento.seleccionarCelda("D24");
                    documento.actualizarValorCelda(dgvCierre.Rows[5].Cells[2].Value.ToString().Replace(",", "."));
                    documento.seleccionarCelda("F24");
                    documento.actualizarValorCelda(dgvCierre.Rows[5].Cells[3].Value.ToString().Replace(",", "."));

                    documento.seleccionarCelda("C25");
                    documento.actualizarValorCelda(dgvCierre.Rows[6].Cells[1].Value.ToString().Replace(",", "."));
                    documento.seleccionarCelda("D25");
                    documento.actualizarValorCelda(dgvCierre.Rows[6].Cells[2].Value.ToString().Replace(",", "."));
                    documento.seleccionarCelda("F25");
                    documento.actualizarValorCelda(dgvCierre.Rows[6].Cells[3].Value.ToString().Replace(",", "."));

                    documento.seleccionarCelda("C26");
                    documento.actualizarValorCelda(dgvCierre.Rows[7].Cells[1].Value.ToString().Replace(",", "."));
                    documento.seleccionarCelda("D26");
                    documento.actualizarValorCelda(dgvCierre.Rows[7].Cells[2].Value.ToString().Replace(",", "."));
                    documento.seleccionarCelda("F26");
                    documento.actualizarValorCelda(dgvCierre.Rows[7].Cells[3].Value.ToString().Replace(",", "."));

                    documento.seleccionarCelda("C27");
                    documento.actualizarValorCelda(dgvCierre.Rows[8].Cells[1].Value.ToString().Replace(",", "."));
                    documento.seleccionarCelda("D27");
                    documento.actualizarValorCelda(dgvCierre.Rows[8].Cells[2].Value.ToString().Replace(",", "."));
                    documento.seleccionarCelda("F27");
                    documento.actualizarValorCelda(dgvCierre.Rows[8].Cells[3].Value.ToString().Replace(",", "."));

                    documento.seleccionarCelda("C28");
                    documento.actualizarValorCelda(dgvCierre.Rows[9].Cells[1].Value.ToString().Replace(",", "."));
                    documento.seleccionarCelda("D28");
                    documento.actualizarValorCelda(dgvCierre.Rows[9].Cells[2].Value.ToString().Replace(",", "."));
                    documento.seleccionarCelda("F28");
                    documento.actualizarValorCelda(dgvCierre.Rows[9].Cells[3].Value.ToString().Replace(",", "."));

                    documento.seleccionarCelda("C29");
                    documento.actualizarValorCelda(dgvCierre.Rows[10].Cells[1].Value.ToString().Replace(",", "."));
                    documento.seleccionarCelda("D29");
                    documento.actualizarValorCelda(dgvCierre.Rows[10].Cells[2].Value.ToString().Replace(",", "."));
                    documento.seleccionarCelda("F29");
                    documento.actualizarValorCelda(dgvCierre.Rows[10].Cells[3].Value.ToString().Replace(",", "."));

                    documento.seleccionarCelda("C30");
                    documento.actualizarValorCelda(dgvCierre.Rows[11].Cells[1].Value.ToString().Replace(",", "."));
                    documento.seleccionarCelda("D30");
                    documento.actualizarValorCelda(dgvCierre.Rows[11].Cells[2].Value.ToString().Replace(",", "."));
                    documento.seleccionarCelda("F30");
                    documento.actualizarValorCelda(dgvCierre.Rows[11].Cells[3].Value.ToString().Replace(",", "."));

                    documento.seleccionarCelda("C31");
                    documento.actualizarValorCelda(dgvCierre.Rows[12].Cells[1].Value.ToString().Replace(",", "."));
                    documento.seleccionarCelda("D31");
                    documento.actualizarValorCelda(dgvCierre.Rows[12].Cells[2].Value.ToString().Replace(",", "."));
                    documento.seleccionarCelda("F31");
                    documento.actualizarValorCelda(dgvCierre.Rows[12].Cells[3].Value.ToString().Replace(",", "."));

                    documento.seleccionarCelda("C32");
                    documento.actualizarValorCelda(dgvCierre.Rows[13].Cells[1].Value.ToString().Replace(",", "."));
                    documento.seleccionarCelda("D32");
                    documento.actualizarValorCelda(dgvCierre.Rows[13].Cells[2].Value.ToString().Replace(",", "."));
                    documento.seleccionarCelda("F32");
                    documento.actualizarValorCelda(dgvCierre.Rows[13].Cells[3].Value.ToString().Replace(",", "."));

                    documento.seleccionarCelda("C33");
                    documento.actualizarValorCelda(dgvCierre.Rows[14].Cells[1].Value.ToString().Replace(",", "."));
                    documento.seleccionarCelda("D33");
                    documento.actualizarValorCelda(dgvCierre.Rows[14].Cells[2].Value.ToString().Replace(",", "."));
                    documento.seleccionarCelda("F33");
                    documento.actualizarValorCelda(dgvCierre.Rows[14].Cells[3].Value.ToString().Replace(",", "."));

                    documento.seleccionarCelda("C34");
                    documento.actualizarValorCelda(dgvCierre.Rows[15].Cells[1].Value.ToString().Replace(",", "."));
                    documento.seleccionarCelda("D34");
                    documento.actualizarValorCelda(dgvCierre.Rows[15].Cells[2].Value.ToString().Replace(",", "."));
                    documento.seleccionarCelda("F34");
                    documento.actualizarValorCelda(dgvCierre.Rows[15].Cells[3].Value.ToString().Replace(",", "."));

                    documento.seleccionarCelda("C35");
                    documento.actualizarValorCelda(dgvCierre.Rows[16].Cells[1].Value.ToString().Replace(",", "."));
                    documento.seleccionarCelda("D35");
                    documento.actualizarValorCelda(dgvCierre.Rows[16].Cells[2].Value.ToString().Replace(",", "."));
                    documento.seleccionarCelda("F35");
                    documento.actualizarValorCelda(dgvCierre.Rows[16].Cells[3].Value.ToString().Replace(",", "."));

                    documento.seleccionarCelda("C36");
                    documento.actualizarValorCelda(dgvCierre.Rows[17].Cells[1].Value.ToString().Replace(",", "."));
                    documento.seleccionarCelda("D36");
                    documento.actualizarValorCelda(dgvCierre.Rows[17].Cells[2].Value.ToString().Replace(",", "."));
                    documento.seleccionarCelda("F36");
                    documento.actualizarValorCelda(dgvCierre.Rows[17].Cells[3].Value.ToString().Replace(",", "."));

                    documento.seleccionarCelda("C37");
                    documento.actualizarValorCelda(dgvCierre.Rows[18].Cells[1].Value.ToString().Replace(",", "."));
                    documento.seleccionarCelda("D37");
                    documento.actualizarValorCelda(dgvCierre.Rows[18].Cells[2].Value.ToString().Replace(",", "."));
                    documento.seleccionarCelda("F37");
                    documento.actualizarValorCelda(dgvCierre.Rows[18].Cells[3].Value.ToString().Replace(",", "."));

                    documento.seleccionarCelda("C38");
                    documento.actualizarValorCelda(dgvCierre.Rows[19].Cells[1].Value.ToString().Replace(",", "."));
                    documento.seleccionarCelda("D38");
                    documento.actualizarValorCelda(dgvCierre.Rows[19].Cells[2].Value.ToString().Replace(",", "."));
                    documento.seleccionarCelda("F38");
                    documento.actualizarValorCelda(dgvCierre.Rows[19].Cells[3].Value.ToString().Replace(",", "."));

                    documento.seleccionarCelda("C39");
                    documento.actualizarValorCelda(dgvCierre.Rows[20].Cells[1].Value.ToString().Replace(",", "."));
                    documento.seleccionarCelda("D39");
                    documento.actualizarValorCelda(dgvCierre.Rows[20].Cells[2].Value.ToString().Replace(",", "."));
                    documento.seleccionarCelda("F39");
                    documento.actualizarValorCelda(dgvCierre.Rows[20].Cells[3].Value.ToString().Replace(",", "."));

                    documento.seleccionarCelda("C41");
                    documento.actualizarValorCelda(dgvCierre.Rows[21].Cells[1].Value.ToString().Replace(",", "."));
                    documento.seleccionarCelda("D41");
                    documento.actualizarValorCelda(dgvCierre.Rows[21].Cells[2].Value.ToString().Replace(",", "."));
                    documento.seleccionarCelda("F41");
                    documento.actualizarValorCelda(dgvCierre.Rows[21].Cells[3].Value.ToString().Replace(",", "."));
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

        private void cboMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {                
                if (cboMoneda.SelectedIndex > -1)
                {
                    nudMonto.Enabled = true;
                    if (cboMoneda.SelectedItem.ToString().Equals("Colones"))
                    {
                        nudNiquel.Enabled = true;
                        nudNiquel.Value = 0;
                    }
                    else
                    {
                        nudNiquel.Enabled = false;
                        nudNiquel.Value = 0;
                    }
                }
                else
                {
                    nudNiquel.Enabled = false;
                    nudNiquel.Value = 0;
                }
            }
            catch (Excepcion ex)
            {

            }
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            this.actualizarListaCierres();
            if (cboCajero.SelectedIndex > -1)
            {
                tipocajero = 0;
                datoscierre = new DataTable();
                btnSaldoInicial.Enabled = true;
                Colaborador cajeroinfo = (Colaborador)cboCajero.SelectedItem;
                _seguridad.obtenerPerfilesxColaborador(ref cajeroinfo);
                string fecha = dtpFecha.Value.Year.ToString() + '-' + dtpFecha.Value.Month.ToString() + '-' + dtpFecha.Value.Day.ToString();
                foreach (Perfil perfil in cajeroinfo.Perfiles)
                {
                    if (perfil.ID == 73)
                    {
                        tipocajero = 1;
                        break;
                    }
                }
                if (tipocajero == 0)
                {
                    chkNiquel.Checked = false;
                    dgvCierre.Rows.Clear();
                    this.crearTabla(dgvCierre, tipocajero);
                    datoscierre = _mantenimiento.ObtenerdatoscierreCajero(cajeroinfo.ID, fecha, fecha);
                }
                else
                {
                    chkNiquel.Checked = true;
                    dgvCierre.Rows.Clear();
                    this.crearTabla(dgvCierre, tipocajero);
                    datoscierre = _mantenimiento.ObtenerdatoscierreCajeroNiquel(cajeroinfo.ID, fecha, fecha);
                }
                actualizartabla(tipocajero, datoscierre);
                if (datoscierre.Columns.Count == 44)
                    calcularsaldofinal(tipocajero);
                if ((int)datoscierre.Rows[0]["Coordinador"] != 0)
                {
                    chkcoordinador = 0;
                    Colaborador coordinador = new Colaborador(id: (int)datoscierre.Rows[0]["Coordinador"]);
                    cboCoordinador.SelectedItem = coordinador;
                    chkcoordinador = 1;
                }
                else
                {
                    chkcoordinador = 0;
                    cboCoordinador.SelectedItem = _colaborador;
                    chkcoordinador = 1;
                }
                if ((int)datoscierre.Rows[0]["Digitador"] != 0)
                {
                    Colaborador digitador = new Colaborador(id: (int)datoscierre.Rows[0]["Digitador"]);
                    cboDigitador.SelectedItem = digitador;
                }
                else
                {
                    cboDigitador.SelectedItem = null;
                }
            }
        }

        private void cboCoordinador_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCoordinador.SelectedIndex > -1)
            {
                epError.SetError(cboCoordinador, "");
                if (cboCajero.SelectedIndex > -1 && chkcoordinador == 0)
                {
                    tipocajero = 0;
                    datoscierre = new DataTable();
                    btnSaldoInicial.Enabled = true;
                    Colaborador cajeroinfo = (Colaborador)cboCajero.SelectedItem;
                    _seguridad.obtenerPerfilesxColaborador(ref cajeroinfo);
                    string fecha = dtpFecha.Value.Year.ToString() + '-' + dtpFecha.Value.Month.ToString() + '-' + dtpFecha.Value.Day.ToString();
                    foreach (Perfil perfil in cajeroinfo.Perfiles)
                    {
                        if (perfil.ID == 73)
                        {
                            tipocajero = 1;
                            break;
                        }
                    }
                    if (tipocajero == 0)
                    {
                        chkNiquel.Checked = false;
                        dgvCierre.Rows.Clear();
                        this.crearTabla(dgvCierre, tipocajero);
                        datoscierre = _mantenimiento.ObtenerdatoscierreCajero(cajeroinfo.ID, fecha, fecha);
                    }
                    else
                    {
                        chkNiquel.Checked = true;
                        dgvCierre.Rows.Clear();
                        this.crearTabla(dgvCierre, tipocajero);
                        datoscierre = _mantenimiento.ObtenerdatoscierreCajeroNiquel(cajeroinfo.ID, fecha, fecha);
                    }
                    actualizartabla(tipocajero, datoscierre);
                    if (datoscierre.Columns.Count == 44)
                        calcularsaldofinal(tipocajero);
                    if ((int)datoscierre.Rows[0]["Coordinador"] != 0)
                    {
                        Colaborador coordinador = new Colaborador(id: (int)datoscierre.Rows[0]["Coordinador"]);
                        cboCoordinador.SelectedItem = coordinador;
                    }
                    else
                    {
                        cboCoordinador.SelectedItem = _colaborador;
                    }
                    if ((int)datoscierre.Rows[0]["Digitador"] != 0)
                    {
                        Colaborador digitador = new Colaborador(id: (int)datoscierre.Rows[0]["Digitador"]);
                        cboDigitador.SelectedItem = digitador;
                    }
                    else
                    {
                        cboDigitador.SelectedItem = null;
                    }
                }
            }                
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            this.actualizarListaCierres(); //Cambio GZH 11092017
        }

        private void actualizarListaCierres()
        {
            try
            {
                DateTime fecha = dtpFecha.Value;
                BindingList<CierreCajeroPROA> cierres = _coordinacion.listarCierresPROA(fecha);

                clbCajeros.Items.Clear();

                foreach (CierreCajeroPROA cierre in cierres)
                    clbCajeros.Items.Add(cierre);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void btnActualizarManifiesto_Click(object sender, EventArgs e)
        {
            try
            {
                this.actualizarListaManifiestos();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        private void actualizarListaManifiestos()
        {

            try
            {
                DateTime fecha = dtpFechaManifiestos.Value;

                dgvManifiestos.DataSource = _coordinacion.listarManifiestosCoordinadorPROA(_colaborador, fecha);
                dgvManifiestos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgvManifiestos.AutoResizeColumns();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        private void rbMontosCajero_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMontosCajero.Checked)
            {
                cboCajeroMontos.Enabled = true;
                cboDigitadorMontos.Enabled = false;
                cboDigitador.SelectedIndex = -1;
            }            
        }

        private void rbMontosDigitador_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMontosDigitador.Checked)
            {
                cboCajeroMontos.Enabled = false;
                cboDigitadorMontos.Enabled = true;
                cboCajeroMontos.SelectedIndex = -1;
            }            
        }

        private void cboCajeroMontos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnMontosCierreTotalSupervision_Click(object sender, EventArgs e)
        {

        }

        private void chkFiltrar_CheckedChanged(object sender, EventArgs e)
        {
            //pnlFiltro.Enabled = chkFiltrar.Checked;
        }

        private void btnActualizarMontosClientes_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fecha = dtpFechaMontos.Value;

                if (!chkFiltrar.Checked)
                {
                    dgvMontosClientes.DataSource = _coordinacion.listarMontosClientesCoordinadorCierrePROA(_coordinador, fecha);
                }
                else if (rbMontosCajero.Checked && cboCajeroMontos.SelectedItem != null)
                {
                    Colaborador cajero = (Colaborador)cboCajeroMontos.SelectedItem;
                    dgvMontosClientes.DataSource = _coordinacion.listarMontosClientesCajeroCoordinadorCierrePROA(cajero, _coordinador, fecha);
                }
                else if (rbMontosDigitador.Checked && cboDigitadorMontos.SelectedItem != null)
                {
                    Colaborador digitador = (Colaborador)cboDigitadorMontos.SelectedItem;
                   dgvMontosClientes.DataSource = _coordinacion.listarMontosClientesDigitadorCoordinadorCierrePROA(digitador, _coordinador, fecha);
                }
                else
                {
                    dgvMontosClientes.DataSource = null;
                }

                dgvMontosClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgvMontosClientes.AutoResizeColumns();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        private void ckbFiltroImpresion_CheckedChanged(object sender, EventArgs e)
        {
            cboImpresionDigitador.Enabled = true;
            cboCoordinadorImpresion.Enabled = true;
            rbImpresionCajero.Enabled = true;
            rbImpresionDigitador.Enabled = true;
            rbImpresionCoordinador.Enabled = true;
            btnExportarExcel.Enabled = true;
        }

        private void rbImpresionCoordinador_CheckedChanged(object sender, EventArgs e)
        {
            if (rbImpresionCoordinador.Checked)
            {
                cboImpresionCajero.SelectedIndex = -1;
                cboImpresionDigitador.SelectedIndex = -1;
                cboCoordinadorImpresion.ListaMostrada = _seguridad.listarColaboradoresPorPuestoArea(Areas.CentroEfectivo, Puestos.Coordinador);
                cboCoordinadorImpresion.Enabled = true;
                cboImpresionDigitador.Enabled = false;
                cboImpresionCajero.Enabled = false;
            }            
        }

        private void rbImpresionDigitador_CheckedChanged(object sender, EventArgs e)
        {
            if (rbImpresionDigitador.Checked)
            {
                cboCoordinadorImpresion.SelectedIndex = -1;
                cboImpresionCajero.SelectedIndex = -1;
                cboImpresionDigitador.ListaMostrada = _seguridad.listarColaboradoresPorPuestoArea(Areas.CentroEfectivo, Puestos.Digitador);
                cboCoordinadorImpresion.Enabled = false;
                cboImpresionDigitador.Enabled = true;
                cboImpresionCajero.Enabled = false;
            }            
        }

        private void rbImpresionCajero_CheckedChanged(object sender, EventArgs e)
        {            
            if (rbImpresionCajero.Checked)
            {
                cboCoordinadorImpresion.SelectedIndex = -1;
                cboImpresionDigitador.SelectedIndex = -1;
                cboImpresionCajero.ListaMostrada = _seguridad.listarColaboradoresPorPuestoArea(Areas.CentroEfectivo, Puestos.CajeroA, Puestos.CajeroB, Puestos.CajeroC);
                cboCoordinadorImpresion.Enabled = false;
                cboImpresionDigitador.Enabled = false;
                cboImpresionCajero.Enabled = true;
            }            
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (((rbImpresionCoordinador.Checked) && (cboCoordinadorImpresion.SelectedIndex > -1)) || ((rbImpresionCajero.Checked) && (cboImpresionCajero.SelectedIndex > -1))
                        || ((rbImpresionDigitador.Checked) && (cboImpresionDigitador.SelectedIndex > -1)))
                {
                    this.exportar();
                }
                else
                {
                    MessageBox.Show("Falta seleccionar el coordinador, cajero o digitador de acuerdo a la opción marcada.");
                }                
            }
            catch (Excepcion ex)
            {
                this.documento.cerrar();
                ex.mostrarMensaje();
            }
            catch (Exception)
            {
                this.documento.cerrar();
                Excepcion.mostrarMensaje("ErrorExcel");
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            actualizarConsolidado();
        }

        private void chkFiltrar_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chkFiltrar.Checked)            
                pnlFiltro.Enabled = true;            
            else
                pnlFiltro.Enabled = false;
        }

        private void cboDigitador_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDigitador.SelectedIndex > -1)
                epError.SetError(cboDigitador, "");
        }

        private void dtpFechaImpresion_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                obtenerTipoCambioImpresion();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
