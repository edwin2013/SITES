using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonObjects.Clases;
using System.Collections;
using BussinessLayer;
using CommonObjects;
using LibreriaMensajes;
using System.Globalization;

namespace GUILayer.Formularios.Blindados
{
    public partial class frmPedidoBanco : Form
    {
        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;
        private AtencionBL _atencion = AtencionBL.Instancia;
        private Decimal _total_colones = new Decimal();
        private Decimal _total_dolares = new Decimal();
        private Decimal _total_euros = new Decimal();
        private Decimal _montomonedas = new Decimal();
        private Decimal _montobillete = new Decimal();
        private ArrayList _numeros_colones = new ArrayList();
        private ArrayList _numeros_dolares = new ArrayList();
        private ArrayList _numeros_euros = new ArrayList();
        private BindingList<bool> _validados = new BindingList<bool>();
        private BindingList<PedidoBancos> _pedidos = new BindingList<PedidoBancos>();
        private BindingList<Denominacion> _denominaciones = new BindingList<Denominacion>();
        bool aux50000colones = true, aux20000colones = true, aux10000colones = true, aux5000colones = true, aux2000colones = true, aux1000colones = true, aux500colones = true,
            aux100colones = true, aux50colones = true, aux25colones = true, aux10colones = true, aux5colones = true,
            aux100dolares = true, aux50dolares = true, aux20dolares = true, aux10dolares = true, aux5dolares = true, aux2dolares = true, aux1dolares = true, aux500euros = true
            , aux200euros = true, aux100euros = true, aux50euros = true, aux20euros = true, aux10euros = true, aux5euros = true, auxniquel = false;
        private Colaborador _colaborador = null;


        private ArrayList _calidades_colones = new ArrayList();
        private ArrayList _calidades_dolares = new ArrayList();
        private ArrayList _calidades_euros = new ArrayList();
        private Formula _formula = null;
        private string _archivo = string.Empty;

        private List<int> _filas_incorrectas = new List<int>();

        #endregion Atributos

        #region Constructor

        public frmPedidoBanco(Colaborador colaborador)
        {
            InitializeComponent();
            cboCanal.ListaMostrada = _mantenimiento.listarCanales();
            cboTransportadora.ListaMostrada = _mantenimiento.listarEmpresasTransporteBanco();
            _total_colones = 0;
            _total_dolares = 0;
            _total_euros = 0;
            _colaborador = colaborador;
            _pedidos.Clear();

            _formula = _mantenimiento.obtenerFormula();

            cbo10000colones.ListaMostrada = _mantenimiento.listarCalidadBilletes(string.Empty);
            cbo1000colones.ListaMostrada = _mantenimiento.listarCalidadBilletes(string.Empty);
            cbo100colones.ListaMostrada = _mantenimiento.listarCalidadBilletes(string.Empty);
            cbo10colones.ListaMostrada = _mantenimiento.listarCalidadBilletes(string.Empty);
            cbo20000colones.ListaMostrada = _mantenimiento.listarCalidadBilletes(string.Empty);
            cbo2000colones.ListaMostrada = _mantenimiento.listarCalidadBilletes(string.Empty);
            cbo25colones.ListaMostrada = _mantenimiento.listarCalidadBilletes(string.Empty);
            cbo50000colones.ListaMostrada = _mantenimiento.listarCalidadBilletes(string.Empty);
            cbo5000colones.ListaMostrada = _mantenimiento.listarCalidadBilletes(string.Empty);
            cbo500colones.ListaMostrada = _mantenimiento.listarCalidadBilletes(string.Empty);
            cbo50colones.ListaMostrada = _mantenimiento.listarCalidadBilletes(string.Empty);
            cbo5colones.ListaMostrada = _mantenimiento.listarCalidadBilletes(string.Empty);

            cbo1dolares.ListaMostrada = _mantenimiento.listarCalidadBilletes(string.Empty);
            cbo2dolares.ListaMostrada = _mantenimiento.listarCalidadBilletes(string.Empty);
            cbo100dolares.ListaMostrada = _mantenimiento.listarCalidadBilletes(string.Empty);
            cbo10dolares.ListaMostrada = _mantenimiento.listarCalidadBilletes(string.Empty);
            cbo20dolares.ListaMostrada = _mantenimiento.listarCalidadBilletes(string.Empty);
            cbo50dolares.ListaMostrada = _mantenimiento.listarCalidadBilletes(string.Empty);
            cbo5dolares.ListaMostrada = _mantenimiento.listarCalidadBilletes(string.Empty);

            cbo100euros.ListaMostrada = _mantenimiento.listarCalidadBilletes(string.Empty);
            cbo10euros.ListaMostrada = _mantenimiento.listarCalidadBilletes(string.Empty);
            cbo20euros.ListaMostrada = _mantenimiento.listarCalidadBilletes(string.Empty);
            cbo200euros.ListaMostrada = _mantenimiento.listarCalidadBilletes(string.Empty);
            cbo500euros.ListaMostrada = _mantenimiento.listarCalidadBilletes(string.Empty);
            cbo50euros.ListaMostrada = _mantenimiento.listarCalidadBilletes(string.Empty);
            cbo5euros.ListaMostrada = _mantenimiento.listarCalidadBilletes(string.Empty);

        }

        #endregion Constructor

        #region Eventos

        private void rdbImportacion_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbImportacion.Checked == true || rdbExportacion.Checked == true)
            {
                lblMontoGananciaDolares.Text = "Monto a pagar dólares";
                lblMontoGananciaEuros.Text = "Monto a pagar euros";
            }
            else
            {
                lblMontoGananciaDolares.Text = "Monto de Ganancia Dólares";
                lblMontoGananciaEuros.Text = "Monto de Ganancia Euros";
            }
        }

        private void rdbExportacion_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbImportacion.Checked == true || rdbExportacion.Checked == true)
            {
                lblMontoGananciaDolares.Text = "Monto a pagar dólares";
                lblMontoGananciaEuros.Text = "Monto a pagar euros";
            }
            else
            {
                lblMontoGananciaDolares.Text = "Monto de Ganancia Dólares";
                lblMontoGananciaEuros.Text = "Monto de Ganancia Euros";
            }
        }

        /// <summary>
        /// Clic en el botón de aceptar.
        /// </summary>
        private void btnAceptar_Click(object sender, EventArgs e)
        {

            try
            {
                if (ValidarCampos() && ValidaErroneos() )
                {
                    if (ValidaCalidades())
                    {
                        _pedidos.Clear();

                        Dictionary<double, decimal> denominaciones_colones = this.obtenerDenominacionesColones();
                        Dictionary<double, decimal> denominaciones_dolares = this.obtenerDenominacionesDolares();
                        Dictionary<double, decimal> denominaciones_euros = this.obtenerDenominacionesEuros();

                        Dictionary<double, CalidadBilletes> calidad_colones = this.obtenerCalidadesColones();
                        Dictionary<double, CalidadBilletes> calidad_dolares = this.obtenerCalidadesDolares();
                        Dictionary<double, CalidadBilletes> calidad_euros = this.obtenerCalidadesEuros();

                        generarCargasMoneda(Monedas.Colones, DateTime.Today, denominaciones_colones, _numeros_colones, calidad_colones);
                        generarCargasMoneda(Monedas.Dolares, DateTime.Today, denominaciones_dolares, _numeros_dolares, calidad_dolares);
                        generarCargasMoneda(Monedas.Euros, DateTime.Today, denominaciones_euros, _numeros_euros, calidad_euros);

                        _coordinacion.importarPedidosBanco(_pedidos);

                        Mensaje.mostrarMensaje("MensajeCargasSucursalesConfirmacionGeneracion");

                        this.Close();
                    }
                    else
                    {
                        Mensaje.mostrarMensaje("MensajeErrorCalidades");
                    }

                }

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de salir.
        /// </summary>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void rdbEntrega_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbEntrega.Checked)
            {

            }
            else { }

        }

        /// <summary>
        /// Clic en el boton de pedido de boveda
        /// </summary>
        private void rdbPedido_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Obtiene cantidad de paquetones y tulas
        /// </summary>
        private void txtMontoGeneral_TextChanged(object sender, EventArgs e)
        {

            Decimal numero = Convert.ToDecimal(txtMontoGeneral.Text);

            txtCantidadPaquetones.Text = (numero / _formula.Paquete).ToString("N0");
            txtCantidadBolsas.Text = (numero / _formula.Bolsa).ToString("N0");


        }

        ///////////////////////////////////////// SECTOR COLONES //////////////////////////////////////
        /// <summary>
        /// Salir del campo de colones
        /// </summary>
        private void txt50000Colones_Leave(object sender, EventArgs e)
        {
            Exception ex = new Exception();
            if (txt50000Colones.Text == string.Empty || txt50000Colones.Text == "0")
                txt50000Colones.Text = "0";
            else
            {

                Decimal auxiliar = Convert.ToDecimal(txt50000Colones.Text);

                if (ValidarMontos(auxiliar, 50000, txt50000Colones, ref aux50000colones))
                {
                    this.CalcularMontoBilletesColones();
                }
            }

        }


        /// <summary>
        /// Salir del campo de colones
        /// </summary>
        private void txt20000Colones_Leave(object sender, EventArgs e)
        {
            if (txt20000Colones.Text == string.Empty || txt20000Colones.Text == "0")
                txt20000Colones.Text = "0";
            else
            {

                Decimal auxiliar = Convert.ToDecimal(txt20000Colones.Text);

                if (ValidarMontos(auxiliar, 20000, txt20000Colones, ref aux20000colones))
                {
                    this.CalcularMontoBilletesColones();
                }
            }
        }


        /// <summary>
        /// Salir del campo de colones
        /// </summary>
        private void txt10000Colones_Leave(object sender, EventArgs e)
        {
            if (txt10000Colones.Text == string.Empty || txt10000Colones.Text == "0")
                txt10000Colones.Text = "0";
            else
            {

                Decimal auxiliar = Convert.ToDecimal(txt10000Colones.Text);

                if (ValidarMontos(auxiliar, 10000, txt10000Colones, ref aux10000colones))
                {
                    this.CalcularMontoBilletesColones();
                }
            }
        }


        /// <summary>
        /// Salir del campo de colones
        /// </summary>
        private void txt5000Colones_Leave(object sender, EventArgs e)
        {
            if (txt5000Colones.Text == string.Empty || txt5000Colones.Text == "0")
                txt5000Colones.Text = "0";
            else
            {

                Decimal auxiliar = Convert.ToDecimal(txt5000Colones.Text);

                if (ValidarMontos(auxiliar, 5000, txt5000Colones, ref aux5000colones))
                {
                    this.CalcularMontoBilletesColones();
                }
            }
        }

        /// <summary>
        /// Salir del campo de colones
        /// </summary>
        private void txt2000Colones_Leave(object sender, EventArgs e)
        {
            if (txt2000Colones.Text == string.Empty || txt2000Colones.Text == "0")
                txt2000Colones.Text = "0";
            else
            {

                Decimal auxiliar = Convert.ToDecimal(txt2000Colones.Text);

                if (ValidarMontos(auxiliar, 2000, txt2000Colones, ref aux2000colones))
                {
                    this.CalcularMontoBilletesColones();
                }
            }
        }

        /// <summary>
        /// Salir del campo de colones
        /// </summary>
        private void txt1000Colones_Leave(object sender, EventArgs e)
        {
            if (txt1000Colones.Text == string.Empty || txt1000Colones.Text == "0")
                txt1000Colones.Text = "0";
            else
            {

                Decimal auxiliar = Convert.ToDecimal(txt1000Colones.Text);

                if (ValidarMontos(auxiliar, 1000, txt1000Colones, ref aux1000colones))
                {
                    this.CalcularMontoBilletesColones();
                }
            }
        }

        /// <summary>
        /// Salir del campo de colones
        /// </summary>
        private void txt500Colones_Leave(object sender, EventArgs e)
        {
            if (txt500Colones.Text == string.Empty || txt500Colones.Text == "0")
                txt500Colones.Text = "0";
            else
            {

                Decimal auxiliar = Convert.ToDecimal(txt500Colones.Text);

                auxniquel = true;

                if (ValidarMontos(auxiliar, 500, txt500Colones, ref aux500colones))
                {
                    this.CalcularMontoMonedas();
                }
            }
        }

        /// <summary>
        /// Salir del campo de colones
        /// </summary>
        private void txt100Colones_Leave(object sender, EventArgs e)
        {
            if (txt100Colones.Text == string.Empty || txt100Colones.Text == "0")
                txt100Colones.Text = "0";
            else
            {

                Decimal auxiliar = Convert.ToDecimal(txt100Colones.Text);

                auxniquel = true;

                if (ValidarMontos(auxiliar, 100, txt100Colones, ref aux100colones))
                {
                    this.CalcularMontoMonedas();
                }
            }
        }


        /// <summary>
        /// Salir del campo de colones
        /// </summary>
        private void txt50Colones_Leave(object sender, EventArgs e)
        {
            if (txt50Colones.Text == string.Empty || txt50Colones.Text == "0")
                txt50Colones.Text = "0";
            else
            {

                Decimal auxiliar = Convert.ToDecimal(txt50Colones.Text);

                auxniquel = true;

                if (ValidarMontos(auxiliar, 50, txt50Colones, ref aux50colones))
                {
                    this.CalcularMontoMonedas();
                }
            }
        }

        /// <summary>
        /// Salir del campo de colones
        /// </summary>
        private void txt25Colones_Leave(object sender, EventArgs e)
        {
            if (txt25Colones.Text == string.Empty || txt25Colones.Text == "0")
                txt25Colones.Text = "0";
            else
            {

                Decimal auxiliar = Convert.ToDecimal(txt25Colones.Text);

                auxniquel = true;

                if (ValidarMontos(auxiliar, 25, txt25Colones, ref aux25colones))
                {
                    this.CalcularMontoMonedas();
                }
            }
        }

        /// <summary>
        /// Salir del campo de colones
        /// </summary>
        private void txt10Colones_Leave(object sender, EventArgs e)
        {
            if (txt10Colones.Text == string.Empty || txt10Colones.Text == "0")
                txt10Colones.Text = "0";
            else
            {

                Decimal auxiliar = Convert.ToDecimal(txt10Colones.Text);

                auxniquel = true;

                if (ValidarMontos(auxiliar, 10, txt10Colones, ref aux10colones))
                {
                    this.CalcularMontoMonedas();
                }
            }
        }

        /// <summary>
        /// Salir del campo de colones
        /// </summary>
        private void txt5Colones_Leave(object sender, EventArgs e)
        {
            if (txt5Colones.Text == string.Empty || txt5Colones.Text == "0")
                txt5Colones.Text = "0";
            else
            {

                Decimal auxiliar = Convert.ToDecimal(txt5Colones.Text);

                auxniquel = true;

                if (ValidarMontos(auxiliar, 5, txt5Colones, ref aux5colones))
                {
                    this.CalcularMontoMonedas();
                }
            }
        }


        ////////////////////////////////////// SECTOR DOLARES ////////////////////////////////////////////////////
        /// <summary>
        /// Salir del campo de dolares
        /// </summary>
        private void txt100Dolares_Leave(object sender, EventArgs e)
        {
            if (txt100Dolares.Text == string.Empty || txt100Dolares.Text == "0")
                txt100Dolares.Text = "0";
            else
            {

                Decimal auxiliar = Convert.ToDecimal(txt100Dolares.Text);

                if (ValidarMontos(auxiliar, 100, txt100Dolares, ref aux100dolares))
                {
                    this.CalcularMontoBilletesDolares();
                }
            }
        }


        /// <summary>
        /// Salir del campo de dolares
        /// </summary>
        private void txt50Dolares_Leave(object sender, EventArgs e)
        {
            if (txt50Dolares.Text == string.Empty || txt50Dolares.Text == "0")
                txt50Dolares.Text = "0";
            else
            {

                Decimal auxiliar = Convert.ToDecimal(txt50Dolares.Text);

                if (ValidarMontos(auxiliar, 50, txt50Dolares, ref aux50dolares))
                {
                    this.CalcularMontoBilletesDolares();
                }
            }
        }


        /// <summary>
        /// Salir del campo de dolares
        /// </summary>
        private void txt20Dolares_Leave(object sender, EventArgs e)
        {
            if (txt20Dolares.Text == string.Empty || txt20Dolares.Text == "0")
                txt20Dolares.Text = "0";
            else
            {

                Decimal auxiliar = Convert.ToDecimal(txt20Dolares.Text);

                if (ValidarMontos(auxiliar, 20, txt20Dolares, ref aux20dolares))
                {
                    this.CalcularMontoBilletesDolares();
                }
            }
        }


        /// <summary>
        /// Salir del campo de dolares
        /// </summary>
        private void txt10Dolares_Leave(object sender, EventArgs e)
        {
            if (txt10Dolares.Text == string.Empty || txt10Dolares.Text == "0")
                txt10Dolares.Text = "0";
            else
            {

                Decimal auxiliar = Convert.ToDecimal(txt10Dolares.Text);

                if (ValidarMontos(auxiliar, 10, txt10Dolares, ref aux10dolares))
                {
                    this.CalcularMontoBilletesDolares();
                }
            }
        }


        /// <summary>
        /// Salir del campo de dolares
        /// </summary>
        private void txt5Dolares_Leave(object sender, EventArgs e)
        {
            if (txt5Dolares.Text == string.Empty || txt5Dolares.Text == "0")
                txt5Dolares.Text = "0";
            else
            {

                Decimal auxiliar = Convert.ToDecimal(txt5Dolares.Text);

                if (ValidarMontos(auxiliar, 5, txt5Dolares, ref aux5dolares))
                {
                    this.CalcularMontoBilletesDolares();
                }
            }
        }

        /// <summary>  
        /// Salir del campo de dolares
        /// </summary>
        private void txt2Dolares_Leave(object sender, EventArgs e)
        {
            if (txt2Dolares.Text == string.Empty || txt2Dolares.Text == "0")
                txt2Dolares.Text = "0";
            else
            {

                Decimal auxiliar = Convert.ToDecimal(txt2Dolares.Text);

                if (ValidarMontos(auxiliar, 2, txt2Dolares, ref aux2dolares))
                {
                    this.CalcularMontoBilletesDolares();
                }
            }
        }




        /// <summary>
        /// Salir del campo de dolares
        /// </summary>
        private void txt1Dolares_Leave(object sender, EventArgs e)
        {
            if (txt1Dolar.Text == string.Empty || txt1Dolar.Text == "0")
                txt1Dolar.Text = "0";
            else
            {

                Decimal auxiliar = Convert.ToDecimal(txt1Dolar.Text);

                if (ValidarMontos(auxiliar, 1, txt1Dolar, ref aux1dolares))
                {
                    this.CalcularMontoBilletesDolares();
                }
            }
        }


        //////////////////////////////////////// SECTOR EUROS //////////////////////////////////////
        /// <summary>
        /// Salir del campo de euros
        /// </summary>
        private void txt500Euros_Leave(object sender, EventArgs e)
        {
            if (txt500Euros.Text == string.Empty || txt500Euros.Text == "0")
                txt500Euros.Text = "0";
            else
            {

                Decimal auxiliar = Convert.ToDecimal(txt500Euros.Text);

                if (ValidarMontos(auxiliar, 500, txt500Euros, ref aux500euros))
                {
                    this.CalcularMontoBilletesEuros();
                }
            }
        }


        /// <summary>
        /// Salir del campo de euros
        /// </summary>
        private void txt200Euros_Leave(object sender, EventArgs e)
        {
            if (txt200Euros.Text == string.Empty || txt200Euros.Text == "0")
                txt200Euros.Text = "0";
            else
            {

                Decimal auxiliar = Convert.ToDecimal(txt200Euros.Text);

                if (ValidarMontos(auxiliar, 200, txt200Euros, ref aux200euros))
                {
                    this.CalcularMontoBilletesEuros();
                }
            }
        }


        /// <summary>
        /// Salir del campo de euros
        /// </summary>
        private void txt100Euros_Leave(object sender, EventArgs e)
        {
            if (txt100Euros.Text == string.Empty || txt100Euros.Text == "0")
                txt100Euros.Text = "0";
            else
            {

                Decimal auxiliar = Convert.ToDecimal(txt100Euros.Text);

                if (ValidarMontos(auxiliar, 100, txt100Euros, ref aux100euros))
                {
                    this.CalcularMontoBilletesEuros();
                }
            }
        }


        /// <summary>
        /// Salir del campo de euros
        /// </summary>
        private void txt50Euros_Leave(object sender, EventArgs e)
        {
            if (txt50Euros.Text == string.Empty || txt50Euros.Text == "0")
                txt50Euros.Text = "0";
            else
            {

                Decimal auxiliar = Convert.ToDecimal(txt50Euros.Text);

                if (ValidarMontos(auxiliar, 50, txt50Euros, ref aux50euros))
                {
                    this.CalcularMontoBilletesEuros();
                }
            }
        }


        /// <summary>
        /// Salir del campo de euros
        /// </summary>
        private void txt20Euros_Leave(object sender, EventArgs e)
        {
            if (txt20Euros.Text == string.Empty || txt20Euros.Text == "0")
                txt20Euros.Text = "0";
            else
            {

                Decimal auxiliar = Convert.ToDecimal(txt20Euros.Text);

                if (ValidarMontos(auxiliar, 20, txt20Euros, ref aux20euros))
                {
                    this.CalcularMontoBilletesEuros();
                }
            }
        }

        /// <summary>
        /// Salir del campo de euros
        /// </summary>
        private void txt10Euros_Leave(object sender, EventArgs e)
        {
            if (txt10Euros.Text == string.Empty || txt10Euros.Text == "0")
                txt10Euros.Text = "0";
            else
            {

                Decimal auxiliar = Convert.ToDecimal(txt10Euros.Text);

                if (ValidarMontos(auxiliar, 10, txt10Euros, ref aux10euros))
                {
                    this.CalcularMontoBilletesEuros();
                }
            }
        }

        /// <summary>
        /// Salir del campo de euros
        /// </summary>
        private void txt5Euros_Leave(object sender, EventArgs e)
        {
            if (txt5Euros.Text == string.Empty || txt5Euros.Text == "0")
                txt5Euros.Text = "0";
            else
            {

                Decimal auxiliar = Convert.ToDecimal(txt5Euros.Text);

                if (ValidarMontos(auxiliar, 5, txt5Euros, ref aux5euros))
                {
                    this.CalcularMontoBilletesEuros();
                }
            }
        }

        /// <summary>
        /// Habilitar o deshabilitar Espacios según la moneda
        /// </summary>
        private void chkColones_CheckedChanged(object sender, EventArgs e)
        {
            if (chkColones.Checked == true)
            {
                this.HabilitarCamposColones();
            }
            else
            {
                this.DesHabiitarCamposColones();
            }
        }


        /// <summary>
        /// Habilitar o deshabilitar Espacios según la moneda
        /// </summary>
        private void chkDolares_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDolares.Checked == true)
            {
                this.HabilitarCamposDolares();
            }
            else
            {
                this.DesHabiitarCamposDolares();
            }
        }

        /// <summary>
        /// Habilitar o deshabilitar Espacios según la moneda
        /// </summary>
        private void chkEuros_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEuros.Checked == true)
            {
                this.HabilitarCamposEuros();
            }
            else
            {
                this.DesHabiitarCamposEuros();
            }
        }


        /// <summary>
        /// Valida que solo se digiten numeros
        /// </summary>
        private void txtMontoDisminucion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
                if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso 
                {
                    e.Handled = false;
                }
                else
                {
                    //el resto de teclas pulsadas se desactivan 
                    e.Handled = true;
                } 
        }

        #endregion Eventos

        #region Métodos Privados



        /// <summary>
        /// Verifica si un monto se puede aceptar debido a la denominacion correspondiente
        /// </summary>
        /// <param name="monto">Monto digitado</param>
        /// <param name="denominacion">Denominacion correspondiente del pedido</param>
        /// <param name="t">Objeto Textbox donde se encuentra el monto</param>
        /// <returns></returns>
        private bool ValidarMontos(Decimal monto, Decimal denominacion, TextBox t)
        {
            bool bStatus = true;

            if (monto % denominacion != 0)
            {
                epError.SetError(t, "No se puede ingresar ese monto");
                bStatus = false;
            }
            else
                epError.SetError(t, "");

            _validados.Add(bStatus);

            return bStatus;
        }


        /// <summary>
        /// Valida que los campos requeridos no esten vacios
        /// </summary>
        /// <returns>Un bool, indicando si la validacion</returns>
        private bool ValidarCampos()
        {
            bool bStatus = true;
            if (cboCanal.Text == "")
            {
                epError.SetError(cboCanal, "Debe ingresar un Canal");
                bStatus = false;
            }
            else
                epError.SetError(cboCanal, "");
            if (cboTransportadora.Text == string.Empty)
            {
                epError.SetError(cboTransportadora, "Debe ingresar la empresa de transporte");
                bStatus = false;
            }
            else
                epError.SetError(cboTransportadora, "");
            if (chkColones.Checked == false && chkDolares.Checked == false && chkEuros.Checked == false)
            {
                epError.SetError(gpbMonedas, "El pedido debe estar en alguna moneda");
                bStatus = false;
            }
            else
                epError.SetError(gpbMonedas, "");
            return bStatus;
        }

        private bool ValidaCalidades()
        {
            bool bStatus = true;

            #region Colones

            if (txt50000Colones.Text != "0" && cbo50000colones.Text == "")
            {
                bStatus = false;
            }
            if (txt20000Colones.Text != "0" && cbo20000colones.Text == "")
            {
                bStatus = false;
            }
            if (txt10000Colones.Text != "0" && cbo10000colones.Text == "")
            {
                bStatus = false;
            }
            if (txt5000Colones.Text != "0" && cbo5000colones.Text == "")
            {
                bStatus = false;
            }
            if (txt2000Colones.Text != "0" && cbo2000colones.Text == "")
            {
                bStatus = false;
            }
            if (txt1000Colones.Text != "0" && cbo1000colones.Text == "")
            {
                bStatus = false;
            }

            if (txt500Colones.Text != "0" && cbo500colones.Text == "")
            {
                bStatus = false;
            }
            if (txt100Colones.Text != "0" && cbo100colones.Text == "")
            {
                bStatus = false;
            }
            if (txt50Colones.Text != "0" && cbo50colones.Text == "")
            {
                bStatus = false;
            }
            if (txt25Colones.Text != "0" && cbo25colones.Text == "")
            {
                bStatus = false;
            }
            if (txt10Colones.Text != "0" && cbo10colones.Text == "")
            {
                bStatus = false;
            }
            if (txt5Colones.Text != "0" && cbo5colones.Text == "")
            {
                bStatus = false;
            }


            #endregion Colones

            #region Dolares

            if (txt100Dolares.Text != "0" && cbo100dolares.Text == "")
            {
                bStatus = false;
            }
            if (txt50Dolares.Text != "0" && cbo50dolares.Text == "")
            {
                bStatus = false;
            }

            if (txt20Dolares.Text != "0" && cbo20dolares.Text == "")
            {
                bStatus = false;
            }
            if (txt10Dolares.Text != "0" && cbo10dolares.Text == "")
            {
                bStatus = false;
            }
            if (txt5Dolares.Text != "0" && cbo5dolares.Text == "")
            {
                bStatus = false;
            }

            if (txt2Dolares.Text != "0" && cbo2dolares.Text == "")
            {
                bStatus = false;
            }
            if (txt1Dolar.Text != "0" && cbo1dolares.Text == "")
            {
                bStatus = false;
            }

            #endregion Dolares

            #region Euros

            if (txt500Euros.Text != "0" && cbo500euros.Text == "")
            {
                bStatus = false;
            }
            if (txt200Euros.Text != "0" && cbo200euros.Text == "")
            {
                bStatus = false;
            }

            if (txt100Euros.Text != "0" && cbo100euros.Text == "")
            {
                bStatus = false;
            }
            if (txt50Euros.Text != "0" && cbo50euros.Text == "")
            {
                bStatus = false;
            }
            if (txt20Euros.Text != "0" && cbo20euros.Text == "")
            {
                bStatus = false;
            }

            if (txt10Euros.Text != "0" && cbo10euros.Text == "")
            {
                bStatus = false;
            }
            if (txt5Euros.Text != "0" && cbo5euros.Text == "")
            {
                bStatus = false;
            }

            #endregion Euros

            return bStatus;
        }

        /// <summary>
        /// Verifica si un monto se puede aceptar debido a la denominacion correspondiente
        /// </summary>
        /// <param name="monto">Monto digitado</param>
        /// <param name="denominacion">Denominacion correspondiente del pedido</param>
        /// <param name="t">Objeto Textbox donde se encuentra el monto</param>
        /// <returns></returns>
        private bool ValidarMontos(Decimal monto, Decimal denominacion, TextBox t, ref bool aux)
        {
            bool bStatus = true;
            if (auxniquel == false)
            {
                if ((monto / 100) % denominacion != 0)
                {
                    epError.SetError(t, "No se puede ingresar ese monto");
                    bStatus = false;
                }
                else
                    epError.SetError(t, "");
            }
            else
            {
                if ((monto / 1000) % denominacion != 0)
                {
                    epError.SetError(t, "No se puede ingresar ese monto");
                    bStatus = false;
                }
                else
                    epError.SetError(t, "");

                auxniquel = false;

            }

            aux = bStatus;

            return bStatus;

        }

        /// <summary>
        /// Valida si alguno de los campos de los montos tiene algun error
        /// </summary>
        /// <returns>Retorna si existe algun error o no en un bool</returns>
        private bool ValidaErroneos()
        {
            bool variable = true;

            if (aux50000colones == false || aux20000colones == false || aux10000colones == false || aux5000colones == false || aux2000colones == false || aux1000colones == false || aux500colones == false
            || aux100colones == false || aux50colones == false || aux25colones == false || aux10colones == false || aux5colones == false ||
            aux100dolares == false || aux50dolares == false || aux20dolares == false || aux10dolares == false || aux5dolares == false || aux1dolares == false || aux2dolares == false || aux500euros == false ||
            aux200euros == false || aux100euros == false || aux50euros == false || aux20euros == false || aux10euros == false || aux5euros == false)
            {
                variable = false;
            }

            return variable;
        }

        /// <summary>
        /// Habilita los campos de la denominacion de colones
        /// </summary>
        private void HabilitarCamposColones()
        {
            this.gbDatosBilleteColones.Enabled = true;
            this.gbMonedaColones.Enabled = true;
        }


        /// <summary>
        /// Habilita los campos de la denominacion de dolares
        /// </summary>
        private void HabilitarCamposDolares()
        {
            this.gbBilleteDolares.Enabled = true;
        }

        /// <summary>
        /// Habilita los campos de la denominacion de euros
        /// </summary>
        private void HabilitarCamposEuros()
        {
            this.gbBilleteEuros.Enabled = true;
        }



        /// <summary>
        /// Inhabilita los campos de colones
        /// </summary>
        private void DesHabiitarCamposColones()
        {
            this.gbDatosBilleteColones.Enabled = false;
            this.gbMonedaColones.Enabled = false;
            this.LimpiarCamposColones();
        }


        /// <summary>
        /// Inhabilita los campos en dolares
        /// </summary>
        private void DesHabiitarCamposDolares()
        {
            this.gbBilleteDolares.Enabled = false;
            this.LimpiarCamposDolares();
        }


        /// <summary>
        /// Inhabilita los campos de Euros
        /// </summary>
        private void DesHabiitarCamposEuros()
        {
            this.gbBilleteEuros.Enabled = false;
            this.LimpiarCamposEuros();
        }


        /// <summary>
        /// Limpia los datos de Colones
        /// </summary>
        private void LimpiarCamposColones()
        {
            try
            {
                this.txt50000Colones.Text = "0";
                this.txt20000Colones.Text = "0";
                this.txt10000Colones.Text = "0";
                this.txt5000Colones.Text = "0";
                this.txt2000Colones.Text = "0";
                this.txt1000Colones.Text = "0";
                this.txt500Colones.Text = "0";
                this.txt100Colones.Text = "0";
                this.txt50Colones.Text = "0";
                this.txt25Colones.Text = "0";
                this.txt10Colones.Text = "0";
                this.txtTotalMoneda.Text = "0";
                this.txtTotalMontoBilletesColones.Text = "0";
                this.txtMontoGeneral.Text = "0";
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }



        /// <summary>
        /// Limpia los datos de Dolares
        /// </summary>
        private void LimpiarCamposDolares()
        {
            try
            {
                this.txt100Dolares.Text = "0";
                this.txt50Dolares.Text = "0";
                this.txt20Dolares.Text = "0";
                this.txt10Dolares.Text = "0";
                this.txt5Dolares.Text = "0";
                this.txt2Dolares.Text = "0";   
                this.txt1Dolar.Text = "0";
                this.txtMontoBilletesDolares.Text = "0";
               
               
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }


        /// <summary>
        /// Limpia los datos de Euros
        /// </summary>
        private void LimpiarCamposEuros()
        {
            try
            {
                this.txt500Euros.Text = "0";
                this.txt200Euros.Text = "0";
                this.txt100Euros.Text = "0";
                this.txt50Euros.Text = "0";
                this.txt20Euros.Text = "0";
                this.txt10Euros.Text = "0";
                this.txt5Euros.Text = "0";
                this.txtMontoBilleteEuros.Text = "0";
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        /// <summary>
        /// Calcula el monto total en billetes de euros
        /// </summary>
        private void CalcularMontoBilletesEuros()
        {
            _total_euros = 0;

            _total_euros = Convert.ToDecimal(txt500Euros.Text) + Convert.ToDecimal(txt200Euros.Text) + Convert.ToDecimal(txt100Euros.Text) +
                Convert.ToDecimal(txt50Euros.Text) + Convert.ToDecimal(txt20Euros.Text) + Convert.ToDecimal(txt10Euros.Text) + Convert.ToDecimal(txt5Euros.Text);

            txtMontoBilleteEuros.Text = _total_euros.ToString("C", CultureInfo.CreateSpecificCulture("fr-FR"));

            
        }


        /// <summary>
        /// Calcula el monto total en billetes de dolares
        /// </summary>
        private void CalcularMontoBilletesDolares()
        {
            _total_dolares = 0;

            _total_dolares = Convert.ToDecimal(txt100Dolares.Text) + Convert.ToDecimal(txt50Dolares.Text) + Convert.ToDecimal(txt20Dolares.Text) +
                Convert.ToDecimal(txt10Dolares.Text) + Convert.ToDecimal(txt5Dolares.Text) 
                + Convert.ToDecimal(txt2Dolares.Text) + Convert.ToDecimal(txt1Dolar.Text);
          
            txtMontoBilletesDolares.Text = _total_dolares.ToString("C", CultureInfo.CreateSpecificCulture("en-US"));

    
        }


        /// <summary>
        /// Calcula el monto total en billetes de colones
        /// </summary>
        private void CalcularMontoBilletesColones()
        {
            try
            {
                _total_colones = 0;

                _total_colones = Convert.ToDecimal(txt50000Colones.Text) + Convert.ToDecimal(txt20000Colones.Text) + Convert.ToDecimal(txt10000Colones.Text) +
                    Convert.ToDecimal(txt5000Colones.Text) + Convert.ToDecimal(txt2000Colones.Text) + Convert.ToDecimal(txt1000Colones.Text);
                _montobillete = _total_colones;

                txtTotalMontoBilletesColones.Text = _total_colones.ToString("C", CultureInfo.CreateSpecificCulture("es-CR"));

                CalcularMontoTotal();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }


        /// <summary>
        /// Calcula el monto de las monedas en colones
        /// </summary>
        private void CalcularMontoMonedas()
        {
            try
            {
                _total_colones = 0;

                _total_colones = Convert.ToDecimal(txt500Colones.Text) + Convert.ToDecimal(txt100Colones.Text) + Convert.ToDecimal(txt50Colones.Text) +
                    Convert.ToDecimal(txt10Colones.Text) + Convert.ToDecimal(txt25Colones.Text) + Convert.ToDecimal(txt5Colones.Text);
                _montomonedas = _total_colones;

                txtTotalMoneda.Text = _total_colones.ToString("C", CultureInfo.CreateSpecificCulture("es-CR"));

                CalcularMontoTotal();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }


        /// <summary>
        /// Calcula el monto total de las monedas y billetes de colones
        /// </summary>
        private void CalcularMontoTotal()
        {
            try
            {
                _total_colones = 0;

                _total_colones = _montomonedas + _montobillete;
               // txtMontoGeneral.Text = _total_colones.ToString("C3", CultureInfo.CreateSpecificCulture("es-CR"));

                txtMontoGeneral.Text = _total_colones.ToString("N0");
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }


        /// <summary>
        /// Obtiene las denominaciones que se llenaron en los campos de textos
        /// </summary>
        /// <returns>Un objeto ArrayList con las denominaciones</returns>
        private Dictionary<double,decimal> obtenerDenominacionesColones()
        {
            _numeros_colones.Clear();
            decimal valor = 0;
            Dictionary<double,decimal> denominaciones_colones = new Dictionary<double, decimal>();
      

            if (Convert.ToDecimal(txt50000Colones.Text) > 0)
            {
                denominaciones_colones.Add(50000, Convert.ToDecimal(txt50000Colones.Text));
                valor = 50000;
                _numeros_colones.Add(valor);
            }
            if (Convert.ToDecimal(txt20000Colones.Text) > 0)
            {
                denominaciones_colones.Add(20000, Convert.ToDecimal(txt20000Colones.Text));
                valor = 20000;
                _numeros_colones.Add(valor);
            }
            if (Convert.ToDecimal(txt10000Colones.Text) > 0)
            {
                denominaciones_colones.Add(10000, Convert.ToDecimal(txt10000Colones.Text));
                valor = 10000;
                _numeros_colones.Add(valor);
            }
            if (Convert.ToDecimal(txt5000Colones.Text) > 0)
            {
                denominaciones_colones.Add(5000, Convert.ToDecimal(txt5000Colones.Text));
                valor = 5000;
                _numeros_colones.Add(valor);
            }
            if (Convert.ToDecimal(txt2000Colones.Text) > 0)
            {
                denominaciones_colones.Add(2000, Convert.ToDecimal(txt2000Colones.Text));
                valor = 2000;
                _numeros_colones.Add(valor);
            }
            if (Convert.ToDecimal(txt1000Colones.Text) > 0)
            {
                denominaciones_colones.Add(1000, Convert.ToDecimal(txt1000Colones.Text));
                valor = 1000;
                _numeros_colones.Add(valor);
            }
            if (Convert.ToDecimal(txt500Colones.Text) > 0)
            {
                denominaciones_colones.Add(500, Convert.ToDecimal(txt500Colones.Text));
                valor = 500;
                _numeros_colones.Add(valor);
            }
            if (Convert.ToDecimal(txt100Colones.Text) > 0)
            {
                denominaciones_colones.Add(100, Convert.ToDecimal(txt100Colones.Text));
                valor = 100;
                _numeros_colones.Add(valor);
            }
            if (Convert.ToDecimal(txt50Colones.Text) > 0)
            {
                denominaciones_colones.Add(50, Convert.ToDecimal(txt50Colones.Text));
                valor = 50;
                _numeros_colones.Add(valor);
            }
            if (Convert.ToDecimal(txt25Colones.Text) > 0)
            {

                denominaciones_colones.Add(25, Convert.ToDecimal(txt25Colones.Text));
                valor = 25;
                _numeros_colones.Add(valor);
            }
            if (Convert.ToDecimal(txt10Colones.Text) > 0)
            {
                denominaciones_colones.Add(10, Convert.ToDecimal(txt10Colones.Text));
                valor = 10;
                _numeros_colones.Add(valor);
            }
            if (Convert.ToDecimal(txt5Colones.Text) > 0)
            {
                denominaciones_colones.Add(5, Convert.ToDecimal(txt5Colones.Text));
                valor = 5;
                _numeros_colones.Add(valor);
            }

            return denominaciones_colones;
        }


        /// <summary>
        /// Obtiene las denominaciones que se llenaron en los campos de textos de dolares
        /// </summary>
        /// <returns>Un objeto ArrayList con las denominaciones</returns>
        private Dictionary<double, decimal> obtenerDenominacionesDolares()
        {
            _numeros_dolares.Clear();
            decimal valor = 0;
            Dictionary<double, decimal> denominaciones_dolares = new Dictionary<double, decimal>();

            if (Convert.ToDecimal(txt100Dolares.Text) > 0)
            {
                denominaciones_dolares.Add(100, Convert.ToDecimal(txt100Dolares.Text));
                valor = 100;
                _numeros_dolares.Add(valor);
            }
            if (Convert.ToDecimal(txt50Dolares.Text) > 0)
            {
                denominaciones_dolares.Add(50, Convert.ToDecimal(txt50Dolares.Text));
                valor = 50;
                _numeros_dolares.Add(valor);
            }
            if (Convert.ToDecimal(txt20Dolares.Text) > 0)
            {
                denominaciones_dolares.Add(20, Convert.ToDecimal(txt20Dolares.Text));
                valor = 20;
                _numeros_dolares.Add(valor);
            }
            if (Convert.ToDecimal(txt10Dolares.Text) > 0)
            {
                denominaciones_dolares.Add(10, Convert.ToDecimal(txt10Dolares.Text));
                valor = 10;
                _numeros_dolares.Add(valor);
            }
            if (Convert.ToDecimal(txt5Dolares.Text) > 0)
            {
                denominaciones_dolares.Add(5, Convert.ToDecimal(txt5Dolares.Text));
                valor = 5;
                _numeros_dolares.Add(valor);

            }

            if (Convert.ToDecimal(txt2Dolares.Text) > 0)
            {
                denominaciones_dolares.Add(2, Convert.ToDecimal(txt2Dolares.Text));
                valor = 2;
                _numeros_dolares.Add(valor);

            }

            if (Convert.ToDecimal(txt1Dolar.Text) > 0)
            {
                denominaciones_dolares.Add(1, Convert.ToDecimal(txt1Dolar.Text));
                valor = 1;
                _numeros_dolares.Add(valor);

            }
           
            return denominaciones_dolares;
        }


        /// <summary>
        /// Obtiene las denominaciones que se llenaron en los campos de textos de euros
        /// </summary>
        /// <returns>Un objeto ArrayList con las denominaciones</returns>
        private Dictionary<double, decimal> obtenerDenominacionesEuros()
        {
            _numeros_euros.Clear();
            decimal valor = 0;
            Dictionary<double, decimal> denominaciones_euros = new Dictionary<double, decimal>();

            if (Convert.ToDecimal(txt500Euros.Text) > 0)
            {
                denominaciones_euros.Add(500, Convert.ToDecimal(txt500Euros.Text));
                valor = 500;
                _numeros_euros.Add(valor);
            }
            if (Convert.ToDecimal(txt200Euros.Text) > 0)
            {
                denominaciones_euros.Add(200, Convert.ToDecimal(txt200Euros.Text));
                valor = 200;
                _numeros_euros.Add(valor);
            }
            if (Convert.ToDecimal(txt100Euros.Text) > 0)
            {
                denominaciones_euros.Add(100, Convert.ToDecimal(txt100Euros.Text));
                valor = 100;
                _numeros_euros.Add(valor);
            }
            if (Convert.ToDecimal(txt50Euros.Text) > 0)
            {
                denominaciones_euros.Add(50, Convert.ToDecimal(txt50Euros.Text));
                valor = 50;
                _numeros_euros.Add(valor);
            }
            if (Convert.ToDecimal(txt20Euros.Text) > 0)
            {
                denominaciones_euros.Add(20, Convert.ToDecimal(txt20Euros.Text));
                valor = 20;
                _numeros_euros.Add(valor);
            }
            if (Convert.ToDecimal(txt10Euros.Text) > 0)
            {
                denominaciones_euros.Add(10, Convert.ToDecimal(txt10Euros.Text));
                valor = 10;
                _numeros_euros.Add(valor);
            }
            if (Convert.ToDecimal(txt5Euros.Text) > 0)
            {
                denominaciones_euros.Add(5, Convert.ToDecimal(txt5Euros.Text));
                valor = 5;
                _numeros_euros.Add(valor);
            }
            
            return denominaciones_euros;
        }

        /// <summary>
        /// Generar las cargas para una moneda específica.
        /// </summary>
        private void generarCargasMoneda(Monedas moneda, DateTime fecha,
                                         Dictionary<double, decimal> denominaciones, 
                                         ArrayList numeros, Dictionary<double, CalidadBilletes> calidades)
        {
            // Leer las denominaciones

           // this.identificarDenominaciones(numeros, moneda);


                Canal canal = (Canal)cboCanal.SelectedItem;

                PedidoBancos carga = this.buscarCarga(canal, fecha);

                foreach (Decimal d in numeros)
                {
                    Denominacion denominacion = new Denominacion(valor: Convert.ToDecimal(d), moneda: moneda);

                    _mantenimiento.verificarDenominacion(ref denominacion);

                    this.asignarCartuchos(Convert.ToDouble(denominacion.Valor), ref carga,denominaciones,moneda, calidades);
                }          

        }



        /// <summary>
        /// Buscar si ya se registro la carga para una Sucursal.
        /// </summary>
        private PedidoBancos buscarCarga(Canal canal, DateTime fecha)
        {
            PedidoBancos nueva = new PedidoBancos();
            
            foreach (PedidoBancos carga in _pedidos)
                if (carga.Canal.Nombre == canal.Nombre)
                    return carga;

            if (rdbEntrega.Checked == true)
            {
                //ManifiestoPedidoBanco manifiesto = new ManifiestoPedidoBanco(dtpFecha.Value, txtSerieTula.Text);
                //_atencion.agregarManifiestoBancoPedido(ref manifiesto);
                //txtNumeroManifiesto.Text = manifiesto.ID.ToString();
                nueva = new PedidoBancos(canal, transportadora: (EmpresaTransporte)cboTransportadora.SelectedItem, fecha_pedido: DateTime.Today, registrador: _colaborador, fecha_asignada: dtpFecha.Value,estado:EstadosPedidoBanco.Entrega_a_Boveda);
            }
            else if (rdbPedido.Checked == true)//venta
            {
                nueva = new PedidoBancos(canal, transportadora: (EmpresaTransporte)cboTransportadora.SelectedItem, fecha_pedido: DateTime.Today, registrador: _colaborador, fecha_asignada: dtpFecha.Value, estado: EstadosPedidoBanco.Pedido_Boveda, ganancia: Convert.ToDecimal(txtMontoGanancia.Text), gananciaDolares: Convert.ToDecimal(txtMontoGananciaDolares.Text), gananciaEuros: Convert.ToDecimal(txtMontoGananciaEuros.Text));
            }
            else if (rdbImportacion.Checked == true)
            {
                nueva = new PedidoBancos(canal, transportadora: (EmpresaTransporte)cboTransportadora.SelectedItem, fecha_pedido: DateTime.Today, registrador: _colaborador, fecha_asignada: dtpFecha.Value, estado: EstadosPedidoBanco.Importacion);
            }
            else
            {
                nueva = new PedidoBancos(canal, transportadora: (EmpresaTransporte)cboTransportadora.SelectedItem, fecha_pedido: DateTime.Today, registrador: _colaborador, fecha_asignada: dtpFecha.Value, estado: EstadosPedidoBanco.Exportacion, ganancia: 0, gananciaDolares: 0, gananciaEuros: 0);
            }

            _pedidos.Add(nueva);

            return nueva;
        }

        /// <summary>
        /// Identificar las denominaciones solicitadas.
        /// </summary>
        private void identificarDenominaciones(ArrayList denominaciones, Monedas moneda)
        {
       
            foreach (decimal d in denominaciones)
            {
                decimal valor = d;

                Denominacion denominacion = new Denominacion(valor: valor, moneda: moneda);

                _mantenimiento.verificarDenominacion(ref denominacion);

                _denominaciones.Add(denominacion);
            }

        }

        /// <summary>
        /// Asignar los cartuchos de una carga y determinar si el monto erra correcto.
        /// </summary>
        private void asignarCartuchos(double p_monto, ref PedidoBancos carga, Dictionary<double, decimal> denominaciones, Monedas moneda, Dictionary<double, CalidadBilletes> calidades)
        {
            decimal monto = 0;
            CalidadBilletes calidad = new CalidadBilletes();

            monto = denominaciones[p_monto];
            calidad = calidades[p_monto];

            Denominacion denominacion = new Denominacion(valor: Convert.ToDecimal(p_monto), moneda: moneda);

            _mantenimiento.verificarDenominacion(ref denominacion);

                double cantidad_total = (double)Math.Ceiling(monto / denominacion.Valor);

                double cantidad_cartucho = (double)(monto / denominacion.Valor);

                 BolsaCargaBanco cartucho = new BolsaCargaBanco(movimiento: carga, cantidad_asignada: cantidad_cartucho,
                                                                     denominacion: denominacion,calidad:calidad);

                    carga.agregarCartucho(cartucho);

                switch (denominacion.Moneda)
                {
                    case Monedas.Colones: carga.Monto_pedido_colones += monto; break;
                    case Monedas.Dolares: carga.Monto_pedido_dolares += monto; break;
                    case Monedas.Euros: carga.Monto_pedido_euros += monto; break;
                }

        }

        private Dictionary<double, CalidadBilletes> obtenerCalidadesColones()
        {
            _calidades_colones.Clear();
            decimal valor = 0;
            Dictionary<double, CalidadBilletes> calidades_colones = new Dictionary<double, CalidadBilletes>();


            if (Convert.ToDecimal(txt50000Colones.Text) > 0)
            {
                calidades_colones.Add(50000, (CalidadBilletes)cbo50000colones.SelectedItem);
                valor = 50000;
            }
            if (Convert.ToDecimal(txt20000Colones.Text) > 0)
            {
                calidades_colones.Add(20000, (CalidadBilletes)cbo20000colones.SelectedItem);
                valor = 20000;
            }
            if (Convert.ToDecimal(txt10000Colones.Text) > 0)
            {
                calidades_colones.Add(10000, (CalidadBilletes)cbo10000colones.SelectedItem);
                valor = 10000;
            }
            if (Convert.ToDecimal(txt5000Colones.Text) > 0)
            {
                calidades_colones.Add(5000, (CalidadBilletes)cbo5000colones.SelectedItem);
                valor = 5000;
            }
            if (Convert.ToDecimal(txt2000Colones.Text) > 0)
            {
                calidades_colones.Add(2000, (CalidadBilletes)cbo2000colones.SelectedItem);
                valor = 2000;
            }
            if (Convert.ToDecimal(txt1000Colones.Text) > 0)
            {
                calidades_colones.Add(1000, (CalidadBilletes)cbo1000colones.SelectedItem);
                valor = 1000;
            }
            if (Convert.ToDecimal(txt500Colones.Text) > 0)
            {
                calidades_colones.Add(500, (CalidadBilletes)cbo500colones.SelectedItem);
                valor = 500;
            }
            if (Convert.ToDecimal(txt100Colones.Text) > 0)
            {
                calidades_colones.Add(100, (CalidadBilletes)cbo100colones.SelectedItem);
                valor = 100;
            }
            if (Convert.ToDecimal(txt50Colones.Text) > 0)
            {
                calidades_colones.Add(50, (CalidadBilletes)cbo50colones.SelectedItem);
                valor = 50;
            }
            if (Convert.ToDecimal(txt25Colones.Text) > 0)
            {

                calidades_colones.Add(25, (CalidadBilletes)cbo25colones.SelectedItem);
                valor = 25;
            }
            if (Convert.ToDecimal(txt10Colones.Text) > 0)
            {
                calidades_colones.Add(10, (CalidadBilletes)cbo10colones.SelectedItem);
                valor = 10;
            }
            if (Convert.ToDecimal(txt5Colones.Text) > 0)
            {
                calidades_colones.Add(5, (CalidadBilletes)cbo5colones.SelectedItem);
                valor = 5;
            }

            return calidades_colones;
        }


        private Dictionary<double, CalidadBilletes> obtenerCalidadesDolares()
        {
            _calidades_dolares.Clear();
            decimal valor = 0;
            Dictionary<double, CalidadBilletes> calidades_dolares = new Dictionary<double, CalidadBilletes>();

            if (Convert.ToDecimal(txt100Dolares.Text) > 0)
            {
                calidades_dolares.Add(100, (CalidadBilletes)cbo100dolares.SelectedItem);
                valor = 100;
                _calidades_dolares.Add(valor);
            }
            if (Convert.ToDecimal(txt50Dolares.Text) > 0)
            {
                calidades_dolares.Add(50, (CalidadBilletes)cbo50dolares.SelectedItem);
                valor = 50;
                _calidades_dolares.Add(valor);
            }
            if (Convert.ToDecimal(txt20Dolares.Text) > 0)
            {
                calidades_dolares.Add(20, (CalidadBilletes)cbo20dolares.SelectedItem);
                valor = 20;
                _calidades_dolares.Add(valor);
            }
            if (Convert.ToDecimal(txt10Dolares.Text) > 0)
            {
                calidades_dolares.Add(10, (CalidadBilletes)cbo10dolares.SelectedItem);
                valor = 10;
                _calidades_dolares.Add(valor);
            }
            if (Convert.ToDecimal(txt5Dolares.Text) > 0)
            {
                calidades_dolares.Add(5, (CalidadBilletes)cbo5dolares.SelectedItem);
                valor = 5;
                _calidades_dolares.Add(valor);

            }

            if (Convert.ToDecimal(txt2Dolares.Text) > 0)
            {
                calidades_dolares.Add(2, (CalidadBilletes)cbo2dolares.SelectedItem);
                valor = 2;
                _calidades_dolares.Add(valor);

            }

            if (Convert.ToDecimal(txt1Dolar.Text) > 0)
            {
                calidades_dolares.Add(1, (CalidadBilletes)cbo1dolares.SelectedItem);
                valor = 1;
                _calidades_dolares.Add(valor);

            }

            return calidades_dolares;
        }

        private Dictionary<double, CalidadBilletes> obtenerCalidadesEuros()
        {
            _calidades_euros.Clear();
            decimal valor = 0;
            Dictionary<double, CalidadBilletes> calidades_euros = new Dictionary<double, CalidadBilletes>();

            if (Convert.ToDecimal(txt500Euros.Text) > 0)
            {
                calidades_euros.Add(500, (CalidadBilletes)cbo500euros.SelectedItem);
                valor = 500;
                _calidades_euros.Add(valor);
            }
            if (Convert.ToDecimal(txt200Euros.Text) > 0)
            {
                calidades_euros.Add(200, (CalidadBilletes)cbo200euros.SelectedItem);
                valor = 200;
                _calidades_euros.Add(valor);
            }
            if (Convert.ToDecimal(txt100Euros.Text) > 0)
            {
                calidades_euros.Add(100, (CalidadBilletes)cbo100euros.SelectedItem);
                valor = 100;
                _calidades_euros.Add(valor);
            }
            if (Convert.ToDecimal(txt50Euros.Text) > 0)
            {
                calidades_euros.Add(50, (CalidadBilletes)cbo50euros.SelectedItem);
                valor = 50;
                _calidades_euros.Add(valor);
            }
            if (Convert.ToDecimal(txt20Euros.Text) > 0)
            {
                calidades_euros.Add(20, (CalidadBilletes)cbo20euros.SelectedItem);
                valor = 20;
                _calidades_euros.Add(valor);
            }
            if (Convert.ToDecimal(txt10Euros.Text) > 0)
            {
                calidades_euros.Add(10, (CalidadBilletes)cbo10euros.SelectedItem);
                valor = 10;
                _calidades_euros.Add(valor);
            }
            if (Convert.ToDecimal(txt5Euros.Text) > 0)
            {
                calidades_euros.Add(5, (CalidadBilletes)cbo5euros.SelectedItem);
                valor = 5;
                _calidades_euros.Add(valor);
            }

            return calidades_euros;
        }



        #endregion Métodos Privados

     
     }
}
