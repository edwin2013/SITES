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

namespace GUILayer.Formularios.Centro_de_Efectivo
{
    public partial class frmConsultaAltoVolumen : Form
    {

        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private BindingList<Camara> listacamara = new BindingList<Camara>();
        private Manifiesto _manifiesto = null;
        private Tula _tula = null;
        private Colaborador _usuario = null;
        private AtencionBL _atencion = AtencionBL.Instancia;
        private ProcesamientoAltoVolumen procesoAV = null;
        private ProcesamientoAltoVolumenDetalle procesodetalle = new ProcesamientoAltoVolumenDetalle("");
        private ProcesamientoBajoVolumen procesoBV = null;
        int filaregistroseleccionado = -1;
        int _coordinador = 0;
        int conteoerrores = 0;
        public Boolean insertarPAV = false;

        #endregion Atributos

        #region Constructor

        public frmConsultaAltoVolumen(Colaborador colaborador)
        {
            InitializeComponent();
            dgvDetalleAltoVolumen.Enabled = false;
            dgvDetalleAltoVolumen.AutoGenerateColumns = false;
            dgvDetalleAltoVolumen.DataSource = new BindingList<ProcesamientoAltoVolumenDetalle>();
            _manifiesto = new Manifiesto();
            _usuario = colaborador;
            cboCliente.ListaMostrada = _mantenimiento.listarClientes(string.Empty);
            listacamara = _mantenimiento.listarCamarasPorArea(Areas.CentroEfectivo);
            cboCamara.ListaMostrada = listacamara;
            cboCamara.SelectedIndex = -1;            
            gbDatosManifiesto.Enabled = false;
            gbDatosTula.Enabled = false;
            cboCliente.SelectedIndex = -1;
            btnCancelar.Enabled = false;
            btnTerminar.Enabled = false;
            btnEliminar.Enabled = false;
            formatoVentana();
        }

        private void formatoVentana()
        {
            cboMoneda.SelectedIndex = (byte)Monedas.Colones;
            //cboTipoMesaNiquel.SelectedIndex = (byte)Monedas.Colones;
        }

        #endregion Constructor        

        private void frmConsultaAltoVolumen_Load(object sender, EventArgs e)
        {

        }

        private bool verificartula()
        {
            bool existe = true;
            TipoCambio _tipocambio = null;
            decimal _montoconvertido = 0;
            decimal _montofinal = 0;
            decimal _montototal = 0;
            try
            {
                if (txtHeaderCard.Text.Equals(string.Empty))
                {
                    epError.SetError(txtHeaderCard, "El campo headercard se encuentra vacío. Favor indicar uno.");
                    existe = false;
                }
                if (cboMonedaTula.SelectedIndex == -1)
                {
                    epError.SetError(cboMonedaTula, "Favor seleccionar una moneda del combo moneda");
                    existe = false;
                }
                if (nudMontoTula.Value == 0)
                {
                    epError.SetError(nudMontoTula, "Favor seleccionar indicar un monto para la tula");
                    existe = false;
                }
                if (txtTula.Text.Equals(string.Empty))
                {
                    epError.SetError(txtTula, "Favor indicar un código de tula");
                    existe = false;
                }

                if (dgvDetalleAltoVolumen.Rows.Count == 0)
                {
                    if (cboMoneda.SelectedItem.ToString().Equals(cboMonedaTula.SelectedItem.ToString()))
                    {
                        /*if (nudMontoTula.Value > nudMonto.Value)
                        {
                            epError.SetError(nudMontoTula, "El monto de la tula asociado es mayor al monto declarado del manifiesto.");
                            existe = false;
                        }*/
                    }
                    else
                    {
                        _tipocambio = _mantenimiento.obtenerTipoCambio(DateTime.Today);
                        if (_tipocambio == null)
                            _tipocambio = _mantenimiento.obtenerTipoCambio(DateTime.Today.AddDays(-1));
                        if (cboMoneda.SelectedItem.ToString().Equals("Colones"))
                        {
                            _montoconvertido = (_tipocambio.Compra * nudMontoTula.Value);
                            //_montofinal = _montoconvertido - nudMonto.Value;
                            /*if (_montoconvertido > (nudMonto.Value + 2000))
                            {
                                epError.SetError(nudMontoTula, "El monto de la tula asociado convertido a colones no puede ser mayor al monto declarado del manifiesto.");
                                existe = false;
                            }*/
                        }
                        else
                        {
                            _montoconvertido = (nudMontoTula.Value / _tipocambio.Venta);
                            //_montofinal = _montoconvertido - nudMonto.Value;
                            /*if (_montoconvertido > (nudMonto.Value + 3))
                            {
                                epError.SetError(nudMontoTula, "El monto de la tula asociado convertido a colones tiene una diferencia mayor no permitida al monto declarado del manifiesto.");
                                existe = false;
                            }*/
                        }

                    }
                }
                else
                {
                    for (int i = 0; i < dgvDetalleAltoVolumen.Rows.Count; i++)
                    {
                        //ProcesamientoAltoVolumenDetalle procesodetalle = new ProcesamientoAltoVolumenDetalle("");                    
                        procesodetalle = (ProcesamientoAltoVolumenDetalle)dgvDetalleAltoVolumen.Rows[i].DataBoundItem;
                        if (txtTula.Text.Equals(procesodetalle.Tula.Codigo))
                        {
                            if (btnAsignarTula.Text.Equals("Asignar"))
                            {
                                if (chkTulaMixta.Checked == false)
                                {
                                    existe = false;
                                    epError.SetError(btnAsignarTula, "Ya existe una tula ingresada en el grid con el mismo código");
                                    break;
                                }
                                else
                                {
                                    if (txtHeaderCard.Text.Equals(procesodetalle.Headercard))
                                    {
                                        existe = false;
                                        epError.SetError(btnAsignarTula, "Ya existe una tula ingresada en el grid con el mismo código y el mismo headercard");
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                if (i != filaregistroseleccionado)
                                {
                                    existe = false;
                                    epError.SetError(btnAsignarTula, "Ya existe una tula ingresada en el grid con el mismo código");
                                    break;
                                }
                                if ((txtHeaderCard.Text.Equals(procesodetalle.Headercard)) && (i != filaregistroseleccionado))
                                {
                                    existe = false;
                                    epError.SetError(btnAsignarTula, "Ya existe una tula ingresada en el grid con el mismo código y el mismo headercard");
                                    break;
                                }
                            }
                        }
                        if (filaregistroseleccionado != i)
                        {
                            if ((Monedas)cboMoneda.SelectedIndex == procesodetalle.Moneda)
                            {
                                _montototal += procesodetalle.Monto;
                            }
                            else
                            {
                                _tipocambio = _mantenimiento.obtenerTipoCambio(DateTime.Today);
                                if (_tipocambio == null)
                                    _tipocambio = _mantenimiento.obtenerTipoCambio(DateTime.Today.AddDays(-1));
                                if (procesodetalle.Moneda == Monedas.Dolares)
                                {
                                    _montoconvertido = (_tipocambio.Compra * procesodetalle.Monto);
                                    _montototal += _montoconvertido;

                                }
                                else
                                {
                                    _montoconvertido = (procesodetalle.Monto / _tipocambio.Venta);
                                    _montototal += _montoconvertido;
                                }

                            }
                        }
                    }
                    if (cboMoneda.SelectedItem.ToString().Equals(cboMonedaTula.SelectedItem.ToString()))
                    {
                        _montototal += nudMontoTula.Value;
                    }
                    else
                    {
                        _tipocambio = _mantenimiento.obtenerTipoCambio(DateTime.Today);
                        if (_tipocambio == null)
                            _tipocambio = _mantenimiento.obtenerTipoCambio(DateTime.Today.AddDays(-1));
                        if (cboMoneda.SelectedItem.ToString().Equals("Colones"))
                        {
                            _montoconvertido = (_tipocambio.Compra * nudMontoTula.Value);
                            _montototal += _montoconvertido;
                        }
                        else
                        {
                            _montoconvertido = (nudMontoTula.Value / _tipocambio.Venta);
                            _montototal += _montoconvertido;
                        }

                    }
                    _montofinal = _montototal - nudMonto.Value;
                    if (cboMoneda.SelectedItem.ToString().Equals("Colones"))
                    {
                        /*if (_montototal > (nudMonto.Value + 2000))
                        {
                            epError.SetError(nudMontoTula, "El monto total de las tulas en proceso supera el monto declarado del manifiesto.");
                            existe = false;
                        }*/
                    }
                    else
                    {
                        /*if (_montototal > (nudMonto.Value + 3))
                        {
                            epError.SetError(nudMontoTula, "El monto total de las tulas en proceso supera el monto declarado del manifiesto.");
                            existe = false;
                        }*/
                    }


                }
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

            return existe;
        }

        private void btnAsignarTula_Click(object sender, EventArgs e)
        {
            BindingList<ProcesamientoAltoVolumenDetalle> listaDetalle;
            try
            {
                if (verificartula())
                {
                    epError.SetError(txtNumero, "");
                    listaDetalle = (BindingList<ProcesamientoAltoVolumenDetalle>)dgvDetalleAltoVolumen.DataSource;
                    if (btnAsignarTula.Text.Equals("Actualizar"))
                    {
                        procesodetalle = listaDetalle[dgvDetalleAltoVolumen.SelectedRows[0].Index];
                        procesodetalle.Tula = _tula;
                        procesodetalle.Cajero = _usuario;
                        procesodetalle.Headercard = txtHeaderCard.Text;
                        if (chkTulaMixta.Checked)                        
                            procesodetalle.Tipo = 1;                        
                        else
                            procesodetalle.Tipo = 0;
                        procesodetalle.Moneda = (Monedas)cboMonedaTula.SelectedIndex;
                        procesodetalle.Monto = nudMontoTula.Value;
                        listaDetalle[dgvDetalleAltoVolumen.SelectedRows[0].Index] = procesodetalle;
                    }
                    else
                    {
                        procesodetalle = new ProcesamientoAltoVolumenDetalle();
                        procesodetalle.Tula = _tula;
                        procesodetalle.Cajero = _usuario;
                        procesodetalle.Headercard = txtHeaderCard.Text;
                        if (chkTulaMixta.Checked)
                            procesodetalle.Tipo = 1;
                        else
                            procesodetalle.Tipo = 0;
                        //procesodetalle.Tipo = 0;
                        procesodetalle.Moneda = (Monedas)cboMonedaTula.SelectedIndex;
                        procesodetalle.Monto = nudMontoTula.Value;
                        epError.SetError(txtTula, "");
                        listaDetalle.Add(procesodetalle);
                    }
                    dgvDetalleAltoVolumen.Refresh();
                    dgvDetalleAltoVolumen.ClearSelection();
                    txtTula.Text = "";
                    txtHeaderCard.Text = "";
                    nudMontoTula.Value = 0;
                    chkTulaMixta.Checked = false;
                }
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        private bool verificarmanifiesto()
        {
            bool existe = true;
            try
            {
                if ((cboCamara.SelectedIndex == -1) || (cboCamara.SelectedItem.Equals("Todos")))
                {
                    epError.SetError(cboCamara, "No se ha seleccionado alguna cámara.");
                    existe = false;
                }
                if (txtColaborador.Text.Equals(string.Empty))
                {
                    epError.SetError(txtColaborador, "El usuario no corresponde al sistema.");
                    existe = false;
                }
                if (txtNumero.Text.Equals(string.Empty))
                {
                    epError.SetError(txtNumero, "No se ha digitado el código del manifiesto.");
                    existe = false;
                }
                if (nudMonto.Value == 0)
                {
                    epError.SetError(nudMonto, "No se ha digitado el monto asociado al manifiesto.");
                    existe = false;
                }
                if (cboCamara.SelectedIndex == -1)
                {
                    epError.SetError(cboCamara, "La tula indicada no existe en el sistema o no está asociada con el manifiesto correcto.");
                    existe = false;
                }
                if ((cboCliente.SelectedIndex == -1) || (cboCliente.SelectedItem.Equals("Todos")))
                {
                    epError.SetError(cboCliente, "No se ha seleccionado un cliente.");
                    existe = false;
                }
                if ((cboPuntoVenta.SelectedIndex == -1) || (cboPuntoVenta.SelectedItem.Equals("Todos")))
                {
                    epError.SetError(cboPuntoVenta, "No se ha seleccionado un punto de venta.");
                    existe = false;
                }
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
            return existe;
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            if (txtNumero.Text != "")
            {
                _manifiesto.Codigo = txtNumero.Text;
                procesoAV = _mantenimiento.obtenerProcesamientoAltoVolumenManifiesto(_manifiesto.Codigo);                
                if (procesoAV == null)
                {
                    epError.SetError(txtNumero, "El manifiesto indicado no posee registros de Procesamiento de Alto Volumen válidos para la consulta (Manifiesto no existe o el registro de alto volumen ya fue validado).");
                    gbDatosManifiesto.Enabled = false;
                    gbDatosTula.Enabled = false;
                    cboCliente.SelectedIndex = -1;
                    btnCancelar.Enabled = false;
                    btnTerminar.Enabled = false;
                    dgvDetalleAltoVolumen.Enabled = false;
                    btnEliminar.Enabled = false;
                }
                else
                {
                    _manifiesto.ID = procesoAV.Manifiesto.ID;
                    cboCamara.SelectedItem = procesoAV.Camara;                    
                    cboMoneda.SelectedIndex = (byte)procesoAV.Moneda;                    
                    cboCliente.SelectedItem = procesoAV.Cliente;
                    Cliente cliente = (Cliente)cboCliente.SelectedItem;
                    cboPuntoVenta.ListaMostrada = cliente.Puntos_venta;
                    cboPuntoVenta.SelectedItem = procesoAV.PuntoVenta;                    
                    nudMonto.Value = procesoAV.Monto;
                    txtColaborador.Text = procesoAV.Cajero.ToString();
                    epError.SetError(txtNumero, "");
                    //dgvDetalleAltoVolumen.DataSource = procesoAV.Detalle;
                    gbDatosManifiesto.Enabled = true;
                    gbDatosTula.Enabled = true;                    
                    btnCancelar.Enabled = true;
                    btnTerminar.Enabled = true;
                    btnEliminar.Enabled = true;
                    dgvDetalleAltoVolumen.Enabled = true;
                    BindingList<ProcesamientoAltoVolumenDetalle> listaDetalle;
                    //DDRC
                    dgvDetalleAltoVolumen.Rows.Clear();
                    listaDetalle = (BindingList<ProcesamientoAltoVolumenDetalle>)dgvDetalleAltoVolumen.DataSource;
                    foreach (ProcesamientoAltoVolumenDetalle _detproc in procesoAV.Detalle)
                    {
                        procesodetalle = new ProcesamientoAltoVolumenDetalle();
                        procesodetalle.ID = _detproc.ID;                        
                        procesodetalle.Tula = _detproc.Tula;
                        procesodetalle.Cajero = _detproc.Cajero;
                        procesodetalle.Headercard = _detproc.Headercard;
                        procesodetalle.Tipo = _detproc.Tipo;
                        procesodetalle.Moneda = _detproc.Moneda;
                        procesodetalle.Monto = _detproc.Monto;
                        epError.SetError(txtTula, "");
                        listaDetalle.Add(procesodetalle);
                    }
                    dgvDetalleAltoVolumen.Refresh();
                    dgvDetalleAltoVolumen.ClearSelection();
                    txtTula.Text = "";
                    txtHeaderCard.Text = "";
                    nudMontoTula.Value = 0;
                    //dgvDetalleAltoVolumen.ClearSelection();

                }
            }
        }

        private void txtNumero_TextChanged(object sender, EventArgs e)
        {
            epError.SetError(txtNumero, "");
            conteoerrores = 0;     
        }

        private void dgvDetalleAltoVolumen_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == -1) && (e.RowIndex == -1))
            {
                dgvDetalleAltoVolumen.ClearSelection();
            }
        }

        private void dgvDetalleAltoVolumen_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            var ht = dgvDetalleAltoVolumen.HitTest(e.X, e.Y);

            if (ht.Type == DataGridViewHitTestType.None)
            {
                dgvDetalleAltoVolumen.ClearSelection();
            }
        }

        private void dgvDetalleAltoVolumen_MouseDown(object sender, MouseEventArgs e)
        {
            var ht = dgvDetalleAltoVolumen.HitTest(e.X, e.Y);

            if (ht.Type == DataGridViewHitTestType.None)
            {
                dgvDetalleAltoVolumen.ClearSelection();
            }
        }

        private void dgvDetalleAltoVolumen_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == -1) && (e.RowIndex == -1))
            {
                dgvDetalleAltoVolumen.ClearSelection();
            }
        }

        private void dgvDetalleAltoVolumen_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDetalleAltoVolumen.SelectedRows.Count > 0)
            {
                procesodetalle = (ProcesamientoAltoVolumenDetalle)dgvDetalleAltoVolumen.SelectedRows[0].DataBoundItem;                
                txtHeaderCard.Text = procesodetalle.Headercard;
                cboMonedaTula.SelectedIndex = (byte)procesodetalle.Moneda;
                txtTula.Text = procesodetalle.Tula.Codigo;
                nudMontoTula.Value = procesodetalle.Monto;
                filaregistroseleccionado = dgvDetalleAltoVolumen.SelectedRows[0].Index;
                if (procesodetalle.Tipo != 0)
                    chkTulaMixta.Checked = true;
                else
                    chkTulaMixta.Checked = false;
                btnAsignarTula.Text = "Actualizar";
                _tula = new Tula("");
                _tula = procesodetalle.Tula;
                if (!_mantenimiento.VerificaTulaAV(procesodetalle))
                {
                    btnAsignarTula.Enabled = false;
                    txtTula.ReadOnly = true;
                    txtHeaderCard.ReadOnly = true;
                    cboMonedaTula.Enabled = false;
                    nudMontoTula.ReadOnly = true;
                    chkTulaMixta.Enabled = false;
                }
                else
                {
                    btnAsignarTula.Enabled = true;
                    txtTula.ReadOnly = false;
                    txtHeaderCard.ReadOnly = false;
                    cboMonedaTula.Enabled = true;
                    nudMontoTula.ReadOnly = false;
                    chkTulaMixta.Enabled = false;
                }
            }
            else
            {
                btnAsignarTula.Text = "Asignar";
                procesodetalle = null;
                filaregistroseleccionado = -1;
                txtTula.Text = "";
                txtHeaderCard.Text = "";
                chkTulaMixta.Checked = false;
                nudMontoTula.Value = 0;
                epError.SetError(txtTula, "");
                epError.SetError(txtHeaderCard, "");
                epError.SetError(nudMontoTula, "");
                btnAsignarTula.Enabled = true;
                txtTula.ReadOnly = false;
                txtHeaderCard.ReadOnly = false;
                cboMonedaTula.Enabled = true;
                nudMontoTula.ReadOnly = false;
                chkTulaMixta.Enabled = false;

            }
            epError.SetError(btnAsignarTula, "");
        }

        private void nudMontoTula_Click(object sender, EventArgs e)
        {
            nudMontoTula.Select(0, nudMonto.Text.Length);
        }

        private void nudMontoTula_Enter(object sender, EventArgs e)
        {
            nudMontoTula.Select(0, nudMonto.Text.Length);
        }

        private void nudMonto_Enter(object sender, EventArgs e)
        {
            nudMonto.Select(0, nudMonto.Text.Length);
        }

        private void nudMonto_Click(object sender, EventArgs e)
        {
            nudMonto.Select(0, nudMonto.Text.Length);
        }

        private void btnTerminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_mantenimiento.VerificaTulasManifiestoAV(ref _manifiesto, dgvDetalleAltoVolumen.Rows.Count))
                {
                    epError.SetError(txtNumero, "El total de tulas no corresponden al manifiesto.");
                    return;
                }
                else
                {
                    decimal _montototal = 0;
                    decimal _montoconvertido = 0;
                    decimal _montofinal = 0;
                    if (conteoerrores == 2)
                    {
                        frmValidacionCoordinadorCE formulario = new frmValidacionCoordinadorCE(12, _usuario);
                        formulario.ShowDialog(this);
                        if (insertarPAV)
                        {
                            TipoCambio _tipocambio = null;
                            for (int i = 0; i < dgvDetalleAltoVolumen.Rows.Count; i++)
                            {
                                procesodetalle = (ProcesamientoAltoVolumenDetalle)dgvDetalleAltoVolumen.Rows[i].DataBoundItem;
                                if (((Monedas)cboMoneda.SelectedIndex == procesodetalle.Moneda))
                                {
                                    _montototal += procesodetalle.Monto;
                                }
                                else
                                {
                                    _tipocambio = _mantenimiento.obtenerTipoCambio(DateTime.Today);
                                    if (_tipocambio == null)
                                        _tipocambio = _mantenimiento.obtenerTipoCambio(DateTime.Today.AddDays(-1));
                                    if (procesodetalle.Moneda == Monedas.Dolares)
                                    {
                                        _montoconvertido = (_tipocambio.Compra * procesodetalle.Monto);
                                        _montototal += _montoconvertido;

                                    }
                                    else
                                    {
                                        _montoconvertido = (procesodetalle.Monto / _tipocambio.Venta);
                                        _montototal += _montoconvertido;
                                    }

                                }
                            }
                            _montofinal = _montototal - nudMonto.Value;                            
                            procesoAV.Camara = (Camara)cboCamara.SelectedItem;
                            procesoAV.Cliente = (Cliente)cboCliente.SelectedItem;
                            procesoAV.Moneda = (Monedas)cboMoneda.SelectedIndex;
                            procesoAV.Monto = nudMonto.Value;
                            procesoAV.PuntoVenta = (PuntoVenta)cboPuntoVenta.SelectedItem;
                            _mantenimiento.actualizarProcesamientoAltoVolumen(procesoAV, _usuario);
                            BindingList<ProcesamientoAltoVolumenDetalle> listaDetalle;
                            listaDetalle = (BindingList<ProcesamientoAltoVolumenDetalle>)dgvDetalleAltoVolumen.DataSource;
                            foreach (ProcesamientoAltoVolumenDetalle _detproc in listaDetalle)
                            {
                                _mantenimiento.actualizarProcesamientoAltoVolumenDetalle(_detproc, _usuario);
                            }
                            MessageBox.Show("Se ha actualizado de forma correcta el registro asociado al procesamiento de alto volumen.");
                            btnCancelar_Click(sender, e);
                        }
                    }
                    else
                    {
                        TipoCambio _tipocambio = null;
                        for (int i = 0; i < dgvDetalleAltoVolumen.Rows.Count; i++)
                        {
                            procesodetalle = (ProcesamientoAltoVolumenDetalle)dgvDetalleAltoVolumen.Rows[i].DataBoundItem;
                            if (((Monedas)cboMoneda.SelectedIndex == procesodetalle.Moneda))
                            {
                                _montototal += procesodetalle.Monto;
                            }
                            else
                            {
                                _tipocambio = _mantenimiento.obtenerTipoCambio(DateTime.Today);
                                if (_tipocambio == null)
                                    _tipocambio = _mantenimiento.obtenerTipoCambio(DateTime.Today.AddDays(-1));
                                if (procesodetalle.Moneda == Monedas.Dolares)
                                {
                                    _montoconvertido = (_tipocambio.Compra * procesodetalle.Monto);
                                    _montototal += _montoconvertido;

                                }
                                else
                                {
                                    _montoconvertido = (procesodetalle.Monto / _tipocambio.Venta);
                                    _montototal += _montoconvertido;
                                }

                            }
                        }
                        _montofinal = _montototal - nudMonto.Value;
                        if (cboMoneda.SelectedItem.ToString().Equals("Colones"))
                        {
                            if (Math.Abs(_montofinal) > 2000)
                            {
                                epError.SetError(nudMontoTula, "El monto total de las tulas en proceso posee una diferencia no permitada contra el monto declarado del manifiesto.");
                                conteoerrores += 1;
                                return;
                            }
                        }
                        else
                        {
                            if (Math.Abs(_montofinal) > 3)
                            {
                                epError.SetError(nudMontoTula, "El monto total de las tulas en proceso posee una diferencia no permitada contra el monto declarado del manifiesto.");
                                conteoerrores += 1;
                                return;
                            }
                        }
                        procesoAV.Camara = (Camara)cboCamara.SelectedItem;
                        procesoAV.Cliente = (Cliente)cboCliente.SelectedItem;
                        procesoAV.Moneda = (Monedas)cboMoneda.SelectedIndex;
                        procesoAV.Monto = nudMonto.Value;
                        procesoAV.PuntoVenta = (PuntoVenta)cboPuntoVenta.SelectedItem;
                        _mantenimiento.actualizarProcesamientoAltoVolumen(procesoAV, _usuario);
                        BindingList<ProcesamientoAltoVolumenDetalle> listaDetalle;
                        listaDetalle = (BindingList<ProcesamientoAltoVolumenDetalle>)dgvDetalleAltoVolumen.DataSource;
                        foreach (ProcesamientoAltoVolumenDetalle _detproc in listaDetalle)
                        {
                            _mantenimiento.actualizarProcesamientoAltoVolumenDetalle(_detproc, _usuario);
                        }
                        MessageBox.Show("Se ha actualizado de forma correcta el registro asociado al procesamiento de alto volumen.");
                        btnCancelar_Click(sender, e);
                    }                    
                }                                

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                //dgvDetalleAltoVolumen.DataSource = null;
                dgvDetalleAltoVolumen.DataSource = new BindingList<ProcesamientoAltoVolumenDetalle>();
                gbDatosTula.Enabled = false;
                dgvDetalleAltoVolumen.Enabled = false;
                btnTerminar.Enabled = false;
                btnCancelar.Enabled = false;
                btnEliminar.Enabled = false;
                txtTula.Text = "";
                txtHeaderCard.Text = "";
                nudMontoTula.Value = 0;
                cboMonedaTula.SelectedIndex = -1;
                cboCamara.SelectedIndex = -1;
                gbDatosManifiesto.Enabled = false;
                gbDatosTula.Enabled = false;
                cboPuntoVenta.SelectedIndex = -1;
                cboCliente.SelectedIndex = -1;
                cboMoneda.SelectedIndex = -1;
                txtColaborador.Text = "";
                nudMonto.Value = 0;
                txtNumero.Text = "";
                chkTulaMixta.Checked = false;
                txtNumero.Focus();
                conteoerrores = 0;
                //cboCamara.Focus();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Está seguro que desea eliminar toda la información del registro de procesamiento de alto volumen?", "Confirmación de eliminación de registro de Procesamiento Alto Volumen",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
                {
                    _mantenimiento.eliminarProcesamientoAltoVolumen(procesoAV, _usuario);
                    MessageBox.Show("Se ha eliminado el registro de procesamiento de alto volumen de forma satisfactoria.");
                    btnCancelar_Click(sender, e);
                }                    
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        private void txtTula_Leave(object sender, EventArgs e)
        {
            if (txtTula.Text != "")
            {
                _tula = new Tula("");
                _tula.Codigo = txtTula.Text;
                if (_atencion.verificarTulaManifiesto2(ref _tula, _manifiesto) == false)
                {
                    epError.SetError(txtTula, "La tula indicada no existe en el sistema o no está asociada al manifiesto declarado.");
                }
                else
                {
                    epError.SetError(txtTula, "");
                }
            }
        }

        private void cboCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCliente.SelectedIndex != -1)
            {
                Cliente cliente = (Cliente)cboCliente.SelectedItem;
                cboPuntoVenta.ListaMostrada = cliente.Puntos_venta;
                cboPuntoVenta.SelectedIndex = -1;
            }            
            epError.SetError(cboCliente, "");
            conteoerrores = 0;
        }

        private void txtTula_TextChanged(object sender, EventArgs e)
        {
            epError.SetError(txtTula, "");
            epError.SetError(btnAsignarTula, "");
            conteoerrores = 0;
        }

        private void txtHeaderCard_TextChanged(object sender, EventArgs e)
        {
            epError.SetError(txtHeaderCard, "");
            epError.SetError(btnAsignarTula, "");
            conteoerrores = 0;
        }

        private void nudMontoTula_ValueChanged(object sender, EventArgs e)
        {
            epError.SetError(nudMontoTula, "");
            epError.SetError(btnAsignarTula, "");
            conteoerrores = 0;
        }

        private void nudMonto_ValueChanged(object sender, EventArgs e)
        {
            epError.SetError(nudMonto, "");
            conteoerrores = 0;
        }

        private void cboMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            epError.SetError(cboMoneda, "");
            conteoerrores = 0;
        }

        private void cboMonedaTula_SelectedIndexChanged(object sender, EventArgs e)
        {
            epError.SetError(cboMonedaTula, "");
            epError.SetError(btnAsignarTula, "");
            conteoerrores = 0;
        }
        public void permisocoordinador(int ID_Coordinador)
        {
            insertarPAV = true;
            _coordinador = ID_Coordinador;
        }
    }
}
