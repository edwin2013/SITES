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

namespace GUILayer.Formularios.Centro_de_Efectivo
{
    public partial class frmMontosProcesosExternos : Form
    {        
                
        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        Colaborador colabora = null;
        Cliente cliente = null;
        EmpresaTransporte empTransporte = null;

        #endregion Atributos

        #region Constructor

        public frmMontosProcesosExternos(Colaborador c)
        {
            InitializeComponent(); 
            //cboCliente.ListaMostrada = _mantenimiento.listarClientes(string.Empty);
            cboCliente.ListaMostrada = _mantenimiento.listarClientes2();
            cboTransportadora.ListaMostrada = _mantenimiento.listarEmpresasTransporte();
            colabora = c;
        }
        

        #endregion Constructor       

        #region Eventos

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }


        private void btnProcesar_Click(object sender, EventArgs e)
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

        #endregion Eventos                        

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (montoBilleteCRCCorrecto() && montoBilleteUSDCorrecto()&& !montoNiquelIncorrecto() && otrosCmpnetLlenos())
            {

                if (ingresarDatos())
                {
                    MessageBox.Show("Datos ingresados correctamente", "En hora buena", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpiarComponentes();
                }
                else
                {
                    MessageBox.Show("Error de base de datos, la información no se procesó", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Hay datos incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

         }
        

        private void limpiarComponentes()
        {
            txtTarifaColones.Clear();
            txtTarifaDolares.Clear();
            txtUnitarioMoneda.Clear();
            txtMontoPagCLS.Clear();
            txtMontoPagUSD.Clear();
            nudMontoBilleteUSD.Value = 0;
            nudMontoBilleteCRC.Value = 0;
            nudQuinientos.Value = 0;
            nudCien.Value = 0;
            nudCincuenta.Value = 0;
            nudVeintiCinco.Value = 0;
            nudDiez.Value = 0;
            nudCinco.Value=0;
            cboCliente.SelectedIndex = -1;
            //cboPuntoVenta.SelectedIndex = -1;
            cboTransportadora.SelectedIndex = -1;
            error.Clear();
        }

        private bool otrosCmpnetLlenos()
        {
            return (cboCliente.SelectedIndex != -1) && (cboTransportadora.SelectedIndex != -1) && (txtMontoPagCLS.Text !="") && (txtMontoPagUSD.Text !="");
        }

        private bool montoNiquelIncorrecto()
        {
            return (hayErrorNiquel(5, nudCinco) || hayErrorNiquel(10, nudDiez) || hayErrorNiquel(25, nudVeintiCinco) || hayErrorNiquel(50, nudCincuenta) || hayErrorNiquel(100, nudCien) || hayErrorNiquel(500, nudQuinientos)) ;
        }

        private Boolean hayErrorNiquel(int denominacion, NumericUpDown componente )
        {
            if ((Int32.Parse(componente.Value.ToString()) % denominacion) != 0)
            {
                error.SetError(componente, "Valor Incorrecto, verifique por favor");
                return true;
            }
            else
            {
                error.SetError(componente, "");
                return false;
            }
        }

        private Boolean ingresarDatos()
        {
            decimal montoNiquel = calculaMontoNiquel();
            txtMontoPagCLS.Text = calculaMontoPagarColones().ToString();
            txtMontoPagUSD.Text = calculaMontoPagarDolares().ToString();
            return _mantenimiento.insertMontosProcExternos(colabora.ID,cliente.Id, empTransporte.ID, nudMontoBilleteCRC.Value,nudMontoBilleteUSD.Value, montoNiquel,nudQuinientos.Value,nudCien.Value,nudCincuenta.Value,nudVeintiCinco.Value,nudDiez.Value,nudCinco.Value, txtMontoPagUSD.Text, txtMontoPagCLS.Text );
        }

        private decimal calculaMontoNiquel()
        {
            return (nudQuinientos.Value+nudCien.Value+nudCincuenta.Value+nudVeintiCinco.Value + nudDiez.Value+nudCinco.Value);
        }

        #region selectedindexchanged event
        private void cboPuntoVenta_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void cboCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCliente.SelectedIndex != -1)
            {
                cliente = (Cliente)cboCliente.SelectedItem;
                //_mantenimiento.obtenerPuntosVentaCliente(ref cliente);
                //cboPuntoVenta.ListaMostrada = cliente.Puntos_venta;
            }

        }


        private void cboTransportadora_SelectedIndexChanged(object sender, EventArgs e)
        {
             error.SetError(cboTransportadora, "");
            if (cboTransportadora.SelectedIndex != -1)
            {
                empTransporte = (EmpresaTransporte)cboTransportadora.SelectedItem;
                txtTarifaColones.Text = empTransporte.PrecioUnitarioMilColones.ToString();
                txtTarifaDolares.Text = empTransporte.PrecioUnitarioMilDolares.ToString();
                txtUnitarioMoneda.Text = empTransporte.PrecioUnitarioPieza.ToString();
                txtMontoPagCLS.Text = calculaMontoPagarColones().ToString();
                txtMontoPagUSD.Text = calculaMontoPagarDolares().ToString();
            }
           
        }
        
        #endregion
        #region Métodos Privados
        private decimal calculaMontoPagarColones()
        {
            decimal montoTotal =0, montoBillete, montoMoneda;
            try
            {
                montoBillete = (decimal.Parse(nudMontoBilleteCRC.Text) / 1000000) * Decimal.Parse(txtTarifaColones.Text);
                montoMoneda = (decimal.Parse(nudQuinientos.Text) / 500) + (decimal.Parse(nudCien.Text) / 100) + (decimal.Parse(nudCincuenta.Text) / 50) + (decimal.Parse(nudVeintiCinco.Text) / 25) + (decimal.Parse(nudDiez.Text) / 10) + (decimal.Parse(nudCinco.Text) / 5);
                montoMoneda = montoMoneda * Decimal.Parse(txtUnitarioMoneda.Text);
                montoTotal = montoMoneda + montoBillete;
                return montoTotal;
            }
            catch
            {
                return 0;
            }
        }

        private decimal calculaMontoPagarDolares()
        {
            return (decimal.Parse(nudMontoBilleteUSD.Text) / 1000) * Decimal.Parse(txtTarifaDolares.Text);
        }

        private void numericUpdownValidate()
        {
            if (nudQuinientos.Text == "")
            {
                nudQuinientos.Text = "0";
            }
            if (nudCien.Text == "")
            {
                nudCien.Text = "0";
            }
            if (nudCincuenta.Text == "")
            {
                nudCincuenta.Text = "0";
            }
            if (nudVeintiCinco.Text == "")
            {
                nudVeintiCinco.Text = "0";
            }
            if (nudDiez.Text == "")
            {
                nudDiez.Text = "0";
            }
            if (nudCinco.Text == "")
            {
                nudCinco.Text = "0";
            }
            if (nudMontoBilleteCRC.Text == "")
            {
                nudMontoBilleteCRC.Text = "0";
            }
            if (nudMontoBilleteUSD.Text == "")
            {
                nudMontoBilleteUSD.Text = "0";
            }
        }

        private Boolean valorInValido(int valor, int denominacion)
        {
            return (valor % denominacion != 0) ? true : false;
        }

        private Boolean empTranspSelected()
        {
            return cboTransportadora.SelectedIndex != -1;
        }

        private Boolean montoBilleteCRCCorrecto()
        {
            int montoBillete = Int32.Parse(nudMontoBilleteCRC.Value.ToString());
            Boolean correcto =(montoBillete % 50000 == 0 || montoBillete % 20000 == 0 || montoBillete % 10000 == 0 || montoBillete % 5000 == 0 || montoBillete % 2000 == 0 || montoBillete % 1000 == 0);
            return correcto;
        }

        private Boolean montoBilleteUSDCorrecto()
        {
            int montoBillete = Int32.Parse(nudMontoBilleteUSD.Value.ToString());
            return (montoBillete % 100 == 0 || montoBillete % 50 == 0 || montoBillete % 20 == 0 || montoBillete % 10 == 0 || montoBillete % 5 == 0 || montoBillete % 1 == 0);   
    
        }

        #endregion Métodos Privados
        #region Leave Event


        private void nudMontoBilleteCRC_Leave(object sender, EventArgs e)
        {
            if (!montoBilleteCRCCorrecto())
                error.SetError(nudMontoBilleteCRC, "Monto incorrecto, verifique si es tan amable");
            else
                error.SetError(nudMontoBilleteCRC, "");
        }
        private void nudMontoBilleteUSD_Leave(object sender, EventArgs e)
        {
            if (!montoBilleteUSDCorrecto())
                error.SetError(nudMontoBilleteUSD, "Monto incorrecto, verifique si es tan amable");
            else
                error.SetError(nudMontoBilleteUSD, "");
        }

        private void nudQuinientos_Leave(object sender, EventArgs e)
        {
            if (valorInValido(Int32.Parse(nudQuinientos.Value.ToString()), 500))
            {
                error.SetError(nudQuinientos, "Monto Incorrecto, verifique si es tan amable");
            }
            else
            {
                error.SetError(nudQuinientos, "");
            }
        }

        private void nudCien_Leave(object sender, EventArgs e)
        {
            if (valorInValido(Int32.Parse(nudCien.Value.ToString()), 100))
            {
                error.SetError(nudCien, "Monto Incorrecto, verifique si es tan amable");
            }
            else
            {
                error.SetError(nudCien, "");
            }
        }

        private void nudCincuenta_Leave(object sender, EventArgs e)
        {
            if (valorInValido(Int32.Parse(nudCincuenta.Value.ToString()), 50))
            {
                error.SetError(nudCincuenta, "Monto Incorrecto, verifique si es tan amable");
            }
            else
            {
                error.SetError(nudCincuenta, "");
            }
        }

        private void nudVeintiCinco_Leave(object sender, EventArgs e)
        {
            if (valorInValido(Int32.Parse(nudVeintiCinco.Value.ToString()), 25))
            {
                error.SetError(nudVeintiCinco, "Monto Incorrecto, verifique si es tan amable");
            }
            else
            {
                error.SetError(nudVeintiCinco, "");
            }
        }

        private void nudDiez_Leave(object sender, EventArgs e)
        {
            if (valorInValido(Int32.Parse(nudDiez.Value.ToString()), 10))
            {
                error.SetError(nudDiez, "Monto Incorrecto, verifique si es tan amable");
            }
            else
            {
                error.SetError(nudDiez, "");
            }
        }

        private void nudCinco_Leave(object sender, EventArgs e)
        {
            if (valorInValido(Int32.Parse(nudCinco.Value.ToString()), 5))
            {
                error.SetError(nudCinco, "Monto Incorrecto, verifique si es tan amable");
            }
            else
            {
                error.SetError(nudCinco, "");
            }
        } 
        #endregion
        #region keyUp event
        private void nudQuinientos_KeyUp(object sender, KeyEventArgs e)
        {
            numericUpdownValidate();
            if(empTranspSelected ())
                 txtMontoPagCLS.Text = calculaMontoPagarColones().ToString();
            else
                error.SetError(cboTransportadora, "Primero debe seleccionar la empresa transportadora");
        }

        private void nudCien_KeyUp(object sender, KeyEventArgs e)
        {

            numericUpdownValidate();
            if (empTranspSelected())
            txtMontoPagCLS.Text = calculaMontoPagarColones().ToString();
            else
                error.SetError(cboTransportadora, "Primero debe seleccionar la empresa transportadora");
        }

        private void nudCincuenta_KeyUp(object sender, KeyEventArgs e)
        {
            numericUpdownValidate();
            if (empTranspSelected())
              txtMontoPagCLS.Text = calculaMontoPagarColones().ToString();
            else
                error.SetError(cboTransportadora, "Primero debe seleccionar la empresa transportadora");
        }

        private void nudVeintiCinco_KeyUp(object sender, KeyEventArgs e)
        {
            numericUpdownValidate();
            if (empTranspSelected())
              txtMontoPagCLS.Text = calculaMontoPagarColones().ToString();
            else
                error.SetError(cboTransportadora, "Primero debe seleccionar la empresa transportadora");
        }

        private void nudDiez_KeyUp(object sender, KeyEventArgs e)
        {
            numericUpdownValidate();
            if(empTranspSelected ())
                txtMontoPagCLS.Text = calculaMontoPagarColones().ToString();
            else
                error.SetError(cboTransportadora, "Primero debe seleccionar la empresa transportadora");
        }

        private void nudCinco_KeyUp(object sender, KeyEventArgs e)
        {
            numericUpdownValidate();
            if (empTranspSelected())
                txtMontoPagCLS.Text = calculaMontoPagarColones().ToString();
            else
                error.SetError(cboTransportadora, "Primero debe seleccionar la empresa transportadora");
        }

        private void nudMontoBilleteCRC_KeyUp(object sender, KeyEventArgs e)
        {
            numericUpdownValidate();
            if (empTranspSelected())
                  txtMontoPagCLS.Text = calculaMontoPagarColones().ToString();
            else
                  error.SetError(cboTransportadora, "Primero debe seleccionar la empresa transportadora");
        }

        private void nudMontoBilleteUSD_KeyUp(object sender, KeyEventArgs e)
        {
            numericUpdownValidate();
            if (empTranspSelected())
                txtMontoPagUSD.Text = calculaMontoPagarDolares().ToString();
            else
                error.SetError(cboTransportadora, "Primero debe seleccionar la empresa transportadora");
        } 
        #endregion
        #region click events
        private void nudMontoBilleteCRC_Click(object sender, EventArgs e)
        {
            nudMontoBilleteCRC.Select(0, nudMontoBilleteCRC.Text.Length);
        }

        private void nudMontoBilleteUSD_Click(object sender, EventArgs e)
        {
            nudMontoBilleteUSD.Select(0, nudMontoBilleteUSD.Text.Length);
        }

        private void nudQuinientos_Click(object sender, EventArgs e)
        {
            nudQuinientos.Select(0, nudQuinientos.Text.Length);
        }

        private void nudCien_Click(object sender, EventArgs e)
        {
            nudCien.Select(0, nudCien.Text.Length);
        }

        private void nudCincuenta_Click(object sender, EventArgs e)
        {
            nudCincuenta.Select(0, nudCincuenta.Text.Length);
        }

        private void nudVeintiCinco_Click(object sender, EventArgs e)
        {
            nudVeintiCinco.Select(0, nudVeintiCinco.Text.Length);
        }

        private void nudDiez_Click(object sender, EventArgs e)
        {
            nudDiez.Select(0, nudDiez.Text.Length);
        }

        private void nudCinco_Click(object sender, EventArgs e)
        {
            nudCinco.Select(0, nudCinco.Text.Length);
        } 
        #endregion


        private void btnBorrar_Click(object sender, EventArgs e)
        {
            limpiarComponentes();
        }

        private void frmMontosProcesosExternos_Load(object sender, EventArgs e)
        {

        }
    }
}
