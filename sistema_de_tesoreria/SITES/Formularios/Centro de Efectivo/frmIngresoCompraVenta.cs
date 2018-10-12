using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LibreriaMensajes;
using BussinessLayer;
using CommonObjects;
using CommonObjects.Clases;

namespace GUILayer.Formularios.Centro_de_Efectivo
{
    public partial class frmIngresoCompraVenta : Form
    {
             
        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private TipoCambio _tipocambio = null;
        private CompraVenta _compraventa;
        private Monedas _monedadeposito;
        private Deposito _deposito;

        #endregion Atributos

        #region Constructor

        public frmIngresoCompraVenta(ref Monedas monedadeposito, Deposito deposito)
        {
            InitializeComponent();
            _tipocambio = _mantenimiento.obtenerTipoCambio(DateTime.Today);
            _deposito = deposito;
            _monedadeposito = monedadeposito;
            if (_tipocambio == null)
            {
                _tipocambio = _mantenimiento.obtenerTipoCambio(DateTime.Today.AddDays(-1));
            }
            txtTipoCambioCompra.Text = _tipocambio.Compra.ToString();
            txtTipoCambioVenta.Text = _tipocambio.Venta.ToString();
            txtTipoCambioCompraEur.Text = _tipocambio.CompraEuros.ToString();
            txtTipoCambioVentaEur.Text = _tipocambio.VentaEuros.ToString();
            if (_deposito.CompraVenta != null)
            {
                txtMontoTransaccion.Text = _deposito.CompraVenta.MontoTransaccion.ToString();
                if (_deposito.CompraVenta.TipoTransaccion == TipoTransaccion.Compra)
                {
                    rdbCompra.Checked = true;
                    //rdbVenta.Checked = false;
                }
                else
                {
                    if (_deposito.CompraVenta.TipoTransaccion == TipoTransaccion.Venta)
                    {
                        rdbVenta.Checked = true;
                    }
                    else
                    {
                        if (_deposito.CompraVenta.TipoTransaccion == TipoTransaccion.CompraEuros)
                        {
                            rdbcompraeur.Checked = true;
                        }
                        else
                            rdbventaeur.Checked = true;
                    }
                    //rdbCompra.Checked = false;                    
                }
                nudMontoBillete.Value = _deposito.CompraVenta.MontoBillete;
                nudMontoNiquel.Value = _deposito.CompraVenta.MontoNiquel;                
                txtMontoCambio.Text = _deposito.CompraVenta.MontoCambio.ToString();
            }
            else
            {
                txtMontoTransaccion.Text = "0";
            }            
        }

        #endregion Constructor         

        #region Eventos

        private void rdbVenta_CheckedChanged(object sender, EventArgs e)
        {
            epError.SetError(rdbVenta, "");
            if (rdbVenta.Checked)
            {                
                nudMontoNiquel.Enabled = true;
                txtMontoCambio.Text = cambioTipoVenta();
                nudMontoBillete.Increment = 1000;
                nudMontoBillete.Value = 0;
                nudMontoNiquel.Value = 0;
                epError.SetError(nudMontoBillete, "");
                epError.SetError(nudMontoNiquel, "");
            }            
        }

        private void nudMonto_ValueChanged(object sender, EventArgs e)
        {
            if ((rdbVenta.Checked) || (rdbventaeur.Checked))
            {
                if ((nudMontoBillete.Value % 1000) != 0)
                {
                    //if (epError.GetError(t).Contains("No se puede ingresar ese monto") == false)
                    //nuderror2 += 1;
                    epError.SetError(nudMontoBillete, "No se puede ingresar ese monto, tiene que ser en montos de mil");                    
                }
                else
                {
                    epError.SetError(nudMontoBillete, "");
                }
            }            
            txtMontoTransaccion.Text = (nudMontoBillete.Value + nudMontoNiquel.Value).ToString();
            /*if (rdbVenta.Checked)
            {
                txtMontoCambio.Text = cambioTipoVenta();
            }
            if (rdbCompra.Checked)
            {
                txtMontoCambio.Text = cambioTipoCompra();
            }*/
        }

        private void rdbCompra_CheckedChanged(object sender, EventArgs e)
        {
            epError.SetError(rdbCompra, "");
            if (rdbCompra.Checked)
            {
                nudMontoBillete.Increment = 1;
                nudMontoNiquel.Value = 0;
                nudMontoBillete.Value = 0;
                nudMontoNiquel.Enabled = false;
                txtMontoCambio.Text = cambioTipoCompra();                
                epError.SetError(nudMontoBillete, "");
                epError.SetError(nudMontoNiquel, "");
            }            
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if ((txtMontoCambio.Text != "") && (txtMontoCambio.Text != "0") && (epError.GetError(nudMontoBillete) == "") && (epError.GetError(nudMontoNiquel) == ""))
                {
                    if (((rdbCompra.Checked) && (_monedadeposito == Monedas.Colones)) || ((rdbVenta.Checked) && (_monedadeposito == Monedas.Dolares)) || ((rdbventaeur.Checked) && (_monedadeposito == Monedas.Euros)) || ((rdbcompraeur.Checked) && (_monedadeposito == Monedas.Colones)))
                    {
                        if (rdbCompra.Checked)
                        {
                            _compraventa = new CompraVenta(transaccion: TipoTransaccion.Compra, tipocambio: _tipocambio, monto_transaccion: Decimal.Parse(txtMontoTransaccion.Text), monto_cambio: Decimal.Parse(txtMontoCambio.Text),
                                monto_billete:nudMontoBillete.Value, monto_niquel: nudMontoNiquel.Value);
                        }
                        if (rdbVenta.Checked)
                        {
                            _compraventa = new CompraVenta(transaccion: TipoTransaccion.Venta, tipocambio: _tipocambio, monto_transaccion: Decimal.Parse(txtMontoTransaccion.Text), monto_cambio: Decimal.Parse(txtMontoCambio.Text),
                                monto_billete: nudMontoBillete.Value, monto_niquel: nudMontoNiquel.Value);
                        }
                        if (rdbcompraeur.Checked)
                        {
                            _compraventa = new CompraVenta(transaccion: TipoTransaccion.CompraEuros, tipocambio: _tipocambio, monto_transaccion: Decimal.Parse(txtMontoTransaccion.Text), monto_cambio: Decimal.Parse(txtMontoCambio.Text),
                                monto_billete: nudMontoBillete.Value, monto_niquel: nudMontoNiquel.Value);
                        }
                        if (rdbventaeur.Checked)
                        {
                            _compraventa = new CompraVenta(transaccion: TipoTransaccion.VentaEuros, tipocambio: _tipocambio, monto_transaccion: Decimal.Parse(txtMontoTransaccion.Text), monto_cambio: Decimal.Parse(txtMontoCambio.Text),
                                monto_billete: nudMontoBillete.Value, monto_niquel: nudMontoNiquel.Value);
                        }
                        frmBajoVolumenIngresoDepositos padre = (frmBajoVolumenIngresoDepositos)this.Owner; //Ingreso de depositos
                        padre.actualizarcompraventa(_compraventa);
                        this.Close();
                    }
                    else
                    {
                        if (rdbCompra.Checked)
                        {
                            epError.SetError(rdbCompra, "El monto declarado en el depósito difiere del tipo de transacción de tipo de cambio");
                        }
                        else
                        {
                            epError.SetError(rdbVenta, "El monto declarado en el depósito difiere del tipo de transacción de tipo de cambio");
                        }
                    }
                }
                else
                {
                    epError.SetError(txtMontoCambio, "El monto de la transacción del tipo de cambio se encuentra vacío o/y hay valores incorrectos en los montos de transacción (billete, niquel)");
                }
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        private void frmIngresoCompraVenta_Load(object sender, EventArgs e)
        {

        }

        private void btnVolver_Click(object sender, EventArgs e)
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

        #endregion Eventos
                

        #region Métodos Privados

        private String cambioTipoCompra()
        {
            return (Convert.ToDecimal(txtMontoTransaccion.Text) * decimal.Parse(txtTipoCambioCompra.Text)).ToString("N2"); 
        }

        private String cambioTipoVenta()
        {
            return (Convert.ToDecimal(txtMontoTransaccion.Text) / decimal.Parse(txtTipoCambioVenta.Text)).ToString("N2");
        }

        private String cambioTipoCompraEur()
        {
            return (Convert.ToDecimal(txtMontoTransaccion.Text) * decimal.Parse(txtTipoCambioCompraEur.Text)).ToString("N2");
        }

        private String cambioTipoVentaEur()
        {
            return (Convert.ToDecimal(txtMontoTransaccion.Text) / decimal.Parse(txtTipoCambioVentaEur.Text)).ToString("N2");
        }

        #endregion Métodos Privados                       

        private void txtMontoCambio_TextChanged(object sender, EventArgs e)
        {
            epError.SetError(txtMontoCambio, "");
        }

        private void nudMontoNiquel_ValueChanged(object sender, EventArgs e)
        {
            txtMontoTransaccion.Text = (nudMontoBillete.Value + nudMontoNiquel.Value).ToString();
        }

        private void txtMontoTransaccion_TextChanged(object sender, EventArgs e)
        {
            if (rdbVenta.Checked)
            {
                txtMontoCambio.Text = cambioTipoVenta();
            }
            if (rdbCompra.Checked)
            {
                txtMontoCambio.Text = cambioTipoCompra();
            }
            if (rdbcompraeur.Checked)
                txtMontoCambio.Text = cambioTipoCompraEur();
            if (rdbventaeur.Checked)
                txtMontoCambio.Text = cambioTipoVentaEur();
        }

        private void rdbventaeur_CheckedChanged(object sender, EventArgs e)
        {
            epError.SetError(rdbventaeur, "");
            if (rdbventaeur.Checked)
            {
                nudMontoNiquel.Enabled = true;
                txtMontoCambio.Text = cambioTipoVentaEur();
                nudMontoBillete.Increment = 1000;
                nudMontoBillete.Value = 0;
                nudMontoNiquel.Value = 0;
                epError.SetError(nudMontoBillete, "");
                epError.SetError(nudMontoNiquel, "");
            }
        }

        private void rdbcompraeur_CheckedChanged(object sender, EventArgs e)
        {
            epError.SetError(rdbcompraeur, "");
            if (rdbcompraeur.Checked)
            {
                nudMontoBillete.Increment = 1;
                nudMontoNiquel.Value = 0;
                nudMontoBillete.Value = 0;
                epError.SetError(nudMontoBillete, "");
                epError.SetError(nudMontoNiquel, "");
                nudMontoNiquel.Enabled = false;
                txtMontoCambio.Text = cambioTipoCompraEur();
            }
        }

        private void nudMontoBillete_Click(object sender, EventArgs e)
        {
            nudMontoBillete.Select(0, nudMontoBillete.Text.Length);
        }

        private void nudMontoBillete_Enter(object sender, EventArgs e)
        {
            nudMontoBillete.Select(0, nudMontoBillete.Text.Length);
        }

        private void nudMontoBillete_Leave(object sender, EventArgs e)
        {
            if ((rdbVenta.Checked) || (rdbventaeur.Checked))
            {
                if ((nudMontoBillete.Value % 1000) != 0)
                {
                    //if (epError.GetError(t).Contains("No se puede ingresar ese monto") == false)
                    //nuderror2 += 1;
                    epError.SetError(nudMontoBillete, "No se puede ingresar ese monto, tiene que ser en montos de mil");
                }
                else
                {
                    epError.SetError(nudMontoBillete, "");
                }
            }
        }

        private void nudMontoNiquel_Click(object sender, EventArgs e)
        {
            nudMontoNiquel.Select(0, nudMontoNiquel.Text.Length);
        }

        private void nudMontoNiquel_Enter(object sender, EventArgs e)
        {
            nudMontoNiquel.Select(0, nudMontoNiquel.Text.Length);
        }
    }
}
