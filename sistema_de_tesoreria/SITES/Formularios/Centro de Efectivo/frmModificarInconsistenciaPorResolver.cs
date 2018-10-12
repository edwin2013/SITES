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
    public partial class frmModificarInconsistenciaPorResolver : Form
    {

          #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private BindingList<Camara> listacamara = new BindingList<Camara>();
        private BindingList<Colaborador> listacajero = new BindingList<Colaborador>();
        private SeguridadBL _seguridad = SeguridadBL.Instancia;
        private InconsistenciaDepositoBajoVolumen infoinconsistencia;
        private ProcesamientoBajoVolumenManifiesto _manifiesto = null;

        #endregion Atributos

        #region Constructor

        public frmModificarInconsistenciaPorResolver(int ID)
        {
            InitializeComponent();
            listacamara = _mantenimiento.listarCamarasPorArea(Areas.CentroEfectivo);
            
            cboCamara.ListaMostrada = listacamara;
            cboCliente.ListaMostrada = _mantenimiento.listarClientes(string.Empty);
            infoinconsistencia = _mantenimiento.ObtenerDetallePROAInconsistenciaporResolver(ID);
            cboCliente.SelectedItem = infoinconsistencia.Cliente;
            cboPuntoVenta.SelectedItem = infoinconsistencia.PuntoVenta;
            txtManifiesto.Text = infoinconsistencia.Manifiesto.Codigo;
            txtTula.Text = infoinconsistencia.Tula.Codigo;
            txtcedula.Text = infoinconsistencia.procesamiento.Cedula;            
            txtcajero.Text = infoinconsistencia.Cajero.Nombre + " " + infoinconsistencia.Cajero.Primer_apellido + " " + infoinconsistencia.Cajero.Segundo_apellido;
            txtCodigoTransaccion.Text = infoinconsistencia.procesamiento.CodigoTransaccion;
            txtcodigoVD.Text = infoinconsistencia.procesamiento.CodigoVD;
            txtCtaReferencia.Text = infoinconsistencia.procesamiento.Cuenta;
            txtManifiesto.Text = infoinconsistencia.Manifiesto.Codigo;
            txtTula.Text = infoinconsistencia.Tula.Codigo;
            txtNumDeposito.Text = infoinconsistencia.procesamiento.NumeroDeposito;
            cboMonedaDeclarada.SelectedIndex = (Byte)(Monedas)infoinconsistencia.procesamiento.Moneda;
            nudMontoDeclarado.Value = infoinconsistencia.procesamiento.MontoContado;
            cboCamara.SelectedItem = infoinconsistencia.Camara;
            _manifiesto = new ProcesamientoBajoVolumenManifiesto();
            _manifiesto.IDManifiesto = infoinconsistencia.Manifiesto.ID;
            _manifiesto.PuntoVenta = infoinconsistencia.PuntoVenta;
            if (infoinconsistencia.Es_cedula == 1)
            {
                txtcedula.ReadOnly = false;
                txtcedula.BackColor = Color.White;
            }
            if (infoinconsistencia.Es_codigotransaccion == 1)
            {
                txtCodigoTransaccion.ReadOnly = false;
                txtCodigoTransaccion.BackColor = Color.White;
            }

            if (infoinconsistencia.Es_codigoVD == 1)
            {
                txtcodigoVD.ReadOnly = false;
                txtcodigoVD.BackColor = Color.White;
            }

            if (infoinconsistencia.Es_numdeposito == 1)
            {
                txtNumDeposito.ReadOnly = false;
                txtNumDeposito.BackColor = Color.White;
            }

            if (infoinconsistencia.Es_cuenta == 1)
            {
                txtCtaReferencia.ReadOnly = false;
                txtCtaReferencia.BackColor = Color.White;
            }

            /*if (infoinconsistencia.Es_moneda == 1)
            {
                cboMonedaDeclarada.Enabled = true;
            }*/
        }

        #endregion Constructor               

        #region Eventos

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            try
            {
                if (validacampos())
                {
                    infoinconsistencia.procesamiento.Cedula = txtcedula.Text;
                    infoinconsistencia.procesamiento.CodigoTransaccion = txtCodigoTransaccion.Text;
                    infoinconsistencia.procesamiento.Cuenta = txtCtaReferencia.Text;
                    infoinconsistencia.procesamiento.CodigoVD = txtcodigoVD.Text;
                    infoinconsistencia.procesamiento.NumeroDeposito = txtNumDeposito.Text;
                    this.Hide();
                    frmInconsistenciasPorResolver padre = (frmInconsistenciasPorResolver)this.Owner;
                    padre.procesarinconsistencia(infoinconsistencia);
                    this.Close();
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
                this.Close();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }        

        private void cboCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCliente.SelectedIndex != -1)
            {
                epError.SetError(cboCliente, "");
                Cliente cliente = (Cliente)cboCliente.SelectedItem;
                //if (cboCliente.SelectedIndex != -1)
                //{
                //    epError.SetError(cboCliente, "");
                //}
                
                cboPuntoVenta.ListaMostrada = cliente.Puntos_venta;
            }
        }

        private void cboCamara_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCamara.SelectedIndex != -1)
            {
                epError.SetError(cboCamara, "");
            }
        }

        private void txtManifiesto_TextChanged(object sender, EventArgs e)
        {
            if (txtManifiesto.Text != "")
            {
                epError.SetError(txtManifiesto, "");
            }
        }

        private void txtTula_TextChanged(object sender, EventArgs e)
        {
            if (txtTula.Text != "")
            {
                epError.SetError(txtTula, "");
            }
        }

        private void txtNumDeposito_TextChanged(object sender, EventArgs e)
        {
            if (txtNumDeposito.Text != "")
            {
                epError.SetError(txtNumDeposito, "");
            }
        }

        private void txtCtaReferencia_TextChanged(object sender, EventArgs e)
        {
            if (txtCtaReferencia.Text != "")
            {
                epError.SetError(txtCtaReferencia, "");
            }
        }

        private void nudMontoDeclarado_ValueChanged(object sender, EventArgs e)
        {
            if (nudMontoDeclarado.Value != 0)
            {
                epError.SetError(nudMontoDeclarado, "");
            }
        }

        #endregion Eventos                                        

        #region Métodos Privados

        private Boolean validacampos()
        {
            try
            {
                /*if (cboCajero.SelectedIndex == -1)
                {
                    epError.SetError(cboCajero, "Falta seleccionar el cajero para realizar la modificación");
                    return false;
                    //MessageBox.Show("Falta seleccionar el cajero para realizar la búsqueda", "Selección de cajero");
                }*/
                if (cboCliente.SelectedIndex == -1)
                {
                    epError.SetError(cboCliente, "Favor seleccionar un cliente");
                    return false;
                }
                if (txtManifiesto.Text == "")
                {
                    epError.SetError(txtManifiesto, "Favor indicar el código de manifiesto");
                    return false;
                }
                if (txtTula.Text == "")
                {
                    epError.SetError(txtTula, "Favor indicar el número de Tula");
                    return false;
                }
                if (txtNumDeposito.Text == "")
                {
                    epError.SetError(txtNumDeposito, "Favor indicar el número de depósito");
                    return false;
                }
                if (txtCtaReferencia.Text == "")
                {
                    epError.SetError(txtCtaReferencia, "Favor indicar una cuenta de referencia");
                    return false;
                }
                if (cboCamara.SelectedIndex < 1)
                {
                    epError.SetError(cboCamara, "Favor seleccionar una cámara");
                    return false;
                } 
                if (nudMontoDeclarado.Value == 0)
                {
                    epError.SetError(nudMontoDeclarado, "No se puede ingresar ese monto");
                    return false;
                }
                if (txtcedula.Text == "")
                {
                    epError.SetError(txtcedula, "No ha indicado el valor de la cédula");
                    return false;
                }
                if (txtCodigoTransaccion.Text == "")
                {
                    epError.SetError(txtCodigoTransaccion, "No se puede ingresar ese monto");
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        #endregion Métodos Privados

        private void dboPuntoVenta_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtCtaReferencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtCtaReferencia_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!txtCtaReferencia.Text.Equals(""))
                {
                    if (_mantenimiento.VerificaCuentaReferenciaDeposito(txtCtaReferencia.Text, (Monedas)cboMonedaDeclarada.SelectedIndex, _manifiesto) == 0)
                    {
                        epError.SetError(txtCtaReferencia, "La cuenta referencia no pertenece al Cliente y Punto de Venta asociado");
                        txtCtaReferencia.Focus();
                    }
                    else
                    {
                        epError.SetError(txtCtaReferencia, "");
                    }
                }
                else
                {
                    epError.SetError(txtCtaReferencia, "Falta ingresar la cuenta de referencia");
                }
            }
            catch (Excepcion ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cboMonedaDeclarada_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                switch(cboMonedaDeclarada.SelectedIndex)
                {
                    case 0:
                        txtCodigoTransaccion.Text = "5311";
                        break;
                    case 1:
                        txtCodigoTransaccion.Text = "5312";
                        break;
                    case 2:
                        txtCodigoTransaccion.Text = "5317";
                        break;
                }
            }
            catch (Excepcion ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
