using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonObjects;
using BussinessLayer;
using LibreriaReportesOffice;
using LibreriaMensajes;
using System.Globalization;
using CommonObjects.Clases;
using System.Collections;
using GUILayer.Formularios.Boveda;
using GUILayer.Formularios.Sucursales;

namespace GUILayer.Formularios.Blindados
{
    public partial class frmPedidoSucursales : Form
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
        private BindingList<CargaSucursal>  _cargas = new BindingList<CargaSucursal>();
        private BindingList<Denominacion> _denominaciones = new BindingList<Denominacion>();
        bool aux50000colones = true, aux20000colones = true, aux10000colones= true, aux5000colones= true, aux2000colones= true, aux1000colones=true, aux500colones=true,
            aux100colones= true, aux50colones=true, aux25colones=true, aux10colones=true, aux5colones=true,
            aux100dolares=true, aux50dolares=true, aux20dolares=true, aux10dolares=true, aux5dolares=true, aux1dolares=true, aux500euros=true
            , aux200euros=true, aux100euros=true, aux50euros=true, aux20euros=true, aux10euros=true, aux5euros = true, auxniquel = false;
        private Colaborador _colaborador = null;

        private string _archivo = string.Empty;

        private List<int> _filas_incorrectas = new List<int>();

        private BindingList<ManifiestoSucursalCarga> _manifiestos = null;

        private EmpresaTransporte _transportadora = null;

        private Colaborador _colaborador_verificacion = null;

        #endregion Atributos

        #region Constructor

        public frmPedidoSucursales(Colaborador colaborador)
        {
            InitializeComponent();
            cboSucursal.ListaMostrada = _mantenimiento.listarSucursalesRecientes();
            cboTransportadora.ListaMostrada = _mantenimiento.listarEmpresasTransporte();
            _total_colones = 0;
            _total_dolares = 0;
            _total_euros = 0;
            _colaborador = colaborador;
            _cargas.Clear();
            _validados.Clear();

        }

        #endregion Constructor

        #region Eventos

      
        
        /// <summary>
        /// Clic en el botón de aceptar.
        /// </summary>
        private void btnAceptar_Click(object sender, EventArgs e)
        {

            try
            {
                if (ValidarCampos() && ValidaErroneos())
                {
                    if (rdbPedido.Checked)
                    {
                        _cargas.Clear();

                        Dictionary<double, decimal> denominaciones_colones = this.obtenerDenominacionesColones();
                        Dictionary<double, decimal> denominaciones_dolares = this.obtenerDenominacionesDolares();
                        Dictionary<double, decimal> denominaciones_euros = this.obtenerDenominacionesEuros();

                        generarCargasMoneda(Monedas.Colones, DateTime.Today, denominaciones_colones, _numeros_colones);
                        generarCargasMoneda(Monedas.Dolares, DateTime.Today, denominaciones_dolares, _numeros_dolares);
                        generarCargasMoneda(Monedas.Euros, DateTime.Today, denominaciones_euros, _numeros_euros);
                    }

                    _cargas[0].Manifiesto = _manifiestos;

                    CargaSucursal nueva = _cargas[0];
                    nueva.ColaboradorVerificadorTransportadora = _colaborador_verificacion;
                    _coordinacion.importarCargasSucursales(ref nueva,_colaborador);

                    if (nueva.Manifiesto != null)
                    {
                        _atencion.actualizarManifiestoSucursalCarga(ref nueva);
                    }
                   
                   
                    
                    Mensaje.mostrarMensaje("MensajeCargasSucursalesConfirmacionGeneracion");


                    this.Close();
                  
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

        /// <summary>
        /// Calcula los montos cada vez que sale de un campo de texto
        /// </summary>
        private void maskedTextBox1_Leave(object sender, EventArgs e)
        {
            CalcularMontoMonedas();
        }


        /// <summary>
        /// Clic en el radiobutton de entrega de pedidos a boveda
        /// </summary>
        private void rdbEntrega_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbEntrega.Checked)
            {

                btnManifiestos.Enabled = true;
            }
            else
                btnManifiestos.Enabled = false;
        }

        /// <summary>
        /// Clic en el boton de pedido de boveda
        /// </summary>
        private void rdbPedido_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbPedido.Checked)
            {
                btnManifiestos.Enabled = false;
            }
            else
                btnManifiestos.Enabled = true;
        }

    ///////////////////////////////////////// SECTOR COLONES //////////////////////////////////////
        /// <summary>
        /// Salir del campo de colones
        /// </summary>
        private void txt50000Colones_Leave(object sender, EventArgs e)
        {
            Exception ex = new Exception();
            if (txt50000Colones.Text == string.Empty || txt50000Colones.Text == "0")
            {
                txt50000Colones.Text = "0";
                epError.SetError(txt50000Colones, "");
                this.CalcularMontoBilletesColones();
            }
            else
            {

                Decimal auxiliar = Convert.ToDecimal(txt50000Colones.Text);

                if (ValidarMontos(auxiliar, 50000, txt50000Colones, ref aux50000colones) || auxiliar == 0)
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
            {
                txt20000Colones.Text = "0";
                epError.SetError(txt20000Colones, "");
                this.CalcularMontoBilletesColones();
            }
            else
            {

                Decimal auxiliar = Convert.ToDecimal(txt20000Colones.Text);

                if (ValidarMontos(auxiliar, 20000, txt20000Colones, ref aux20000colones) || auxiliar == 0)
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
            {
                txt10000Colones.Text = "0";
                epError.SetError(txt10000Colones, "");
                this.CalcularMontoBilletesColones();
            }
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
            {
                txt5000Colones.Text = "0";
                epError.SetError(txt5000Colones, "");
                this.CalcularMontoBilletesColones();
            }
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
            {
                txt2000Colones.Text = "0";
                epError.SetError(txt2000Colones, "");
                this.CalcularMontoBilletesColones();
            }
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
            {
                txt1000Colones.Text = "0";
                epError.SetError(txt1000Colones, "");
                this.CalcularMontoBilletesColones();
            }
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
            {
                txt500Colones.Text = "0";
                epError.SetError(txt500Colones, "");
                this.CalcularMontoMonedas();
            }
            else
            {

                Decimal auxiliar = Convert.ToDecimal(txt500Colones.Text);



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
            {
                txt100Colones.Text = "0";
                epError.SetError(txt100Colones, "");
                this.CalcularMontoMonedas();
            }
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
            {
                txt50Colones.Text = "0";
                epError.SetError(txt50Colones, "");
                this.CalcularMontoMonedas();
            }
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
            {
                txt25Colones.Text = "0";
                epError.SetError(txt25Colones, "");
                this.CalcularMontoMonedas();
            }
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
            {
                txt10Colones.Text = "0";
                epError.SetError(txt10Colones, "");
                this.CalcularMontoMonedas();
            }
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
            {
                txt5Colones.Text = "0";
                epError.SetError(txt5Colones, "");
                this.CalcularMontoMonedas();
            }
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
            {
                txt100Dolares.Text = "0";
                epError.SetError(txt100Dolares, "");
                this.CalcularMontoBilletesDolares();
            }
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
            {
                txt50Dolares.Text = "0";
                epError.SetError(txt50Dolares, "");
                this.CalcularMontoBilletesDolares();
            }
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
            {
                txt20Dolares.Text = "0";
                epError.SetError(txt20Dolares, "");
                this.CalcularMontoBilletesDolares();
            }
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
            {
                txt10Dolares.Text = "0";
                epError.SetError(txt10Dolares, "");
                this.CalcularMontoBilletesDolares();
            }
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
            {
                txt5Dolares.Text = "0";
                epError.SetError(txt5Dolares, "");
                this.CalcularMontoBilletesDolares();
            }
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
        private void txt1Dolares_Leave(object sender, EventArgs e)
        {
            if (txt1Dolar.Text == string.Empty || txt1Dolar.Text == "0")
            {
                txt1Dolar.Text = "0";
                epError.SetError(txt1Dolar, "");
                this.CalcularMontoBilletesDolares();
            }
            else
            {

                Decimal auxiliar = Convert.ToDecimal(txt1Dolar.Text);

                if (ValidarMontos(auxiliar, 1, txt1Dolar, ref aux1dolares))
                {
                    this.CalcularMontoBilletesDolares();
                }
            }
        }



        /// <summary>
        /// Clic en el boton de agregar manifiesto
        /// </summary>
        private void btnMutilados_Click(object sender, EventArgs e)
        {
            try
            {

                _cargas.Clear();

                Dictionary<double, decimal> denominaciones_colones = this.obtenerDenominacionesColones();
                Dictionary<double, decimal> denominaciones_dolares = this.obtenerDenominacionesDolares();
                Dictionary<double, decimal> denominaciones_euros = this.obtenerDenominacionesEuros();

                generarCargasMoneda(Monedas.Colones, DateTime.Today, denominaciones_colones, _numeros_colones);
                generarCargasMoneda(Monedas.Dolares, DateTime.Today, denominaciones_dolares, _numeros_dolares);
                generarCargasMoneda(Monedas.Euros, DateTime.Today, denominaciones_euros, _numeros_euros);

                CargaSucursal carga = new CargaSucursal();

                if (_cargas.Count > 0)
                    carga = _cargas[0];

                carga.Manifiesto = new BindingList<ManifiestoSucursalCarga>();
                carga.Fecha_verificacion = dtpFecha.Value;

                frmIngresoManifiestoSucursal formulario = new frmIngresoManifiestoSucursal(ref carga);
                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

//////////////////////////////////////// SECTOR EUROS //////////////////////////////////////
        ///<sumary>
        /// Validar los textbox de Euros
        ///</sumary>
        private bool validarMonto_Euros(Decimal monto, Decimal denominacion, TextBox t, ref bool aux)
        {
            bool bStatus = true;
            if (auxniquel == false)
            {
                if ((monto) % denominacion != 0)
                {
                    epError.SetError(t, "No se puede ingresar ese monto");   // ingresar validacion de montos
                    bStatus = false;
                }
                else
                    epError.SetError(t, "");
            }
            else
            {
                if ((monto) % denominacion != 0)
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
        /// Salir del campo de euros
        /// </summary>
        private void txt500Euros_Leave(object sender, EventArgs e)
        {
            if (txt500Euros.Text == string.Empty || txt500Euros.Text == "0")
            {
                txt500Euros.Text = "0";
                epError.SetError(txt500Euros, "");
                this.CalcularMontoBilletesEuros();
            }
            else
            {

                Decimal auxiliar = Convert.ToDecimal(txt500Euros.Text);

                if (validarMonto_Euros(auxiliar, 500, txt500Euros, ref aux500euros))
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
            {
                txt200Euros.Text = "0";
                epError.SetError(txt200Euros, "");
                this.CalcularMontoBilletesEuros();
            }
            else
            {

                Decimal auxiliar = Convert.ToDecimal(txt200Euros.Text);

                if (validarMonto_Euros(auxiliar, 200, txt200Euros, ref aux200euros))
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
            {
                txt100Euros.Text = "0";
                epError.SetError(txt100Euros, "");
                this.CalcularMontoBilletesEuros();
            }
            else
            {

                Decimal auxiliar = Convert.ToDecimal(txt100Euros.Text);

                if (validarMonto_Euros(auxiliar, 100, txt100Euros, ref aux100euros))
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
            {
                txt50Euros.Text = "0";
                epError.SetError(txt50Euros, "");
                this.CalcularMontoBilletesEuros();
            }
            else
            {

                Decimal auxiliar = Convert.ToDecimal(txt50Euros.Text);

                if (validarMonto_Euros(auxiliar, 50, txt50Euros, ref aux50euros))
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
            {
                txt20Euros.Text = "0";
                epError.SetError(txt20Euros, "");
                this.CalcularMontoBilletesEuros();
            }
            else
            {

                Decimal auxiliar = Convert.ToDecimal(txt20Euros.Text);

                if (validarMonto_Euros(auxiliar, 20, txt20Euros, ref aux20euros))
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
            {
                txt10Euros.Text = "0";
                epError.SetError(txt10Euros, "");
                this.CalcularMontoBilletesEuros();
            }
            else
            {

                Decimal auxiliar = Convert.ToDecimal(txt10Euros.Text);

                if (validarMonto_Euros(auxiliar, 10, txt10Euros, ref aux10euros))
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
            {
                txt5Euros.Text = "0";
                epError.SetError(txt5Euros, "");
                this.CalcularMontoBilletesEuros();
            }
            else
            {

                Decimal auxiliar = Convert.ToDecimal(txt5Euros.Text);

                if (validarMonto_Euros(auxiliar, 5, txt5Euros, ref aux5euros))
                {
                    this.CalcularMontoBilletesEuros();
                }
            }
        }


//////////////////////////////////////// HABILITA /////////////////////////////////////////

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

            //if (((e.KeyChar) < 48 && e.KeyChar != 8 && e.KeyChar != 44) || e.KeyChar > 57)
            //{
            //   // MessageBox.Show("Sólo se permiten Números");
            //    e.Handled = true;
            //}
        }




        /// <summary>
        /// Cambio en la cantidad de formulas de 50,000
        /// </summary>
        private void nud50000Colones_ValueChanged(object sender, EventArgs e)
        {
            txt50000Colones.Text = ((nud50000Colones2.Value * 50000)*100).ToString();
        }


        /// <summary>
        /// Cambio en la cantidad de formulas de 20,000
        /// </summary>
        private void nud20000Colones_ValueChanged(object sender, EventArgs e)
        {
            txt20000Colones.Text = ((nud20000Colones.Value * 20000)*100).ToString();
        }


        /// <summary>
        /// Cambio en la cantidad de formulas de 10,000
        /// </summary>
        private void nud10000Colones_ValueChanged(object sender, EventArgs e)
        {
            txt10000Colones.Text = ((nud10000Colones.Value * 10000)*100).ToString();
        }


        /// <summary>
        /// Cambio en la cantidad de formulas de 50,000 colones
        /// </summary>
        private void nud5000Colones_ValueChanged(object sender, EventArgs e)
        {
            txt5000Colones.Text = ((nud5000Colones.Value * 5000)*100).ToString();
        }

        /// <summary>
        /// Cambio en la cantidad de formulas de 2000 colones
        /// </summary>
        private void nud2000Colones_ValueChanged(object sender, EventArgs e)
        {
            txt2000Colones.Text = ((nud2000Colones.Value * 2000)*100).ToString();
        }



        /// <summary>
        /// Cambio en la cantidad de formulas de 1000 colones
        /// </summary>
        private void nud1000Colones_ValueChanged(object sender, EventArgs e)
        {
            txt1000Colones.Text = ((nud1000Colones.Value * 1000)*100).ToString();
        }



        /// <summary>
        /// Cambio en la cantidad de formulas de 500
        /// </summary>
        private void nud500Colones_ValueChanged(object sender, EventArgs e)
        {
            txt500Colones.Text = ((nud500Colones.Value * 500)*1000).ToString();
        }


        /// <summary>
        /// Cambio en la cantidad de 100 colones
        /// </summary>
        private void nud100Colones_ValueChanged(object sender, EventArgs e)
        {
            txt100Colones.Text = ((nud100Colones.Value * 100)*1000).ToString();
        }


        /// <summary>
        /// Cambio en la cantidad de 50 colones
        /// </summary>
        private void nud50Colones_ValueChanged(object sender, EventArgs e)
        {
            txt50Colones.Text = ((nud50Colones.Value * 50)*1000).ToString();
        }


        /// <summary>
        /// Cambio en la cantidad de 25 colones
        /// </summary>
        private void nud25Colones_ValueChanged(object sender, EventArgs e)
        {
            txt25Colones.Text = ((nud25Colones.Value * 25)*1000).ToString();
        }

        /// <summary>
        /// Cambio en la cantidad de 10 colones
        /// </summary>
        private void nud10Colones_ValueChanged(object sender, EventArgs e)
        {
            txt10Colones.Text = ((nud10Colones.Value * 10)*1000).ToString();
        }


        /// <summary>
        /// Cambio en la cantidad de 5 colones
        /// </summary>
        private void nud5Colones_ValueChanged(object sender, EventArgs e)
        {
            txt5Colones.Text = ((nud5Colones.Value * 5)*1000).ToString();
        }


        /// <summary>
        /// Cambio en la cantidad de 100 dólares
        /// </summary>

        private void nud100Dolares_ValueChanged(object sender, EventArgs e)
        {
            txt100Dolares.Text = ((nud100Dolares.Value * 100)*100).ToString();
        }


        /// <summary>
        /// Cambio en la cantidad de formulas de 50 dólares 
        /// </summary>
        private void nud50Dolares_ValueChanged(object sender, EventArgs e)
        {
            txt50Dolares.Text = ((nud50Dolares.Value * 50)*100).ToString();
        }


        /// <summary>
        /// Cambio en la cantidad de fórmulas de 20 dólares
        /// </summary>
        private void nud20Dolares_ValueChanged(object sender, EventArgs e)
        {
            txt20Dolares.Text = ((nud20Dolares.Value * 20)*100).ToString();
        }


        /// <summary>
        /// Cambio en la cantidad de fórmulas de 10 dólares
        /// </summary>
        private void nud10Dolares_ValueChanged(object sender, EventArgs e)
        {
            txt10Dolares.Text = ((nud10Dolares.Value * 10)*100).ToString();
        }



        /// <summary>
        /// Cambio en la cantidad de fórmulas de 5 dólares
        /// </summary>
        private void nud5Dolares_ValueChanged(object sender, EventArgs e)
        {
            txt5Dolares.Text = ((nud5Dolares.Value * 5)*100).ToString();
        }


        /// <summary>
        /// Cambio en la cantidad de fórmulas de 1 dólar
        /// </summary>
        private void nud1Dolar_ValueChanged(object sender, EventArgs e)
        {
            txt1Dolar.Text = ((nud1Dolar.Value * 1)*100).ToString();
        }


        /// <summary>
        /// Cambio en la cantidad de fórmulas de 500 euros
        /// </summary>
        private void nud500Euros_ValueChanged(object sender, EventArgs e)
        {
            txt500Euros.Text = (nud500Euros.Value * 500).ToString();
        }


        /// <summary>
        /// Cambio en la cantidad de fórmulas de 200 euros
        /// </summary>
        private void nud200Euros_ValueChanged(object sender, EventArgs e)
        {
            txt200Euros.Text = (nud200Euros.Value * 200).ToString();
        }



        /// <summary>
        /// Cambio en la cantidad de fórmulas de 100 euros
        /// </summary>
        private void nud100Euros_ValueChanged(object sender, EventArgs e)
        {
            txt100Euros.Text = (nud100Euros.Value * 100).ToString();
        }



        /// <summary>
        /// Cambio en la cantidad de fórmulas de 50 euros
        /// </summary>
        private void nud50Euros_ValueChanged(object sender, EventArgs e)
        {
            txt50Euros.Text = (nud50Euros.Value * 50).ToString();
        }




        /// <summary>
        /// Cambio en la cantidad de fórmulas de 20 euros
        /// </summary>
        private void nud20Euros_ValueChanged(object sender, EventArgs e)
        {
            txt20Euros.Text = (nud20Euros.Value * 20).ToString();
        }


        /// <summary>
        /// Cambio en la cantidad de fórmulas de 10 euros
        /// </summary>
        private void nud10Euros_ValueChanged(object sender, EventArgs e)
        {
            txt10Euros.Text = (nud10Euros.Value * 10).ToString();
        }


        /// <summary>
        /// Cambio en la cantidad de fórmulas de 5 euros
        /// </summary>
        private void nud5Euros_ValueChanged(object sender, EventArgs e)
        {
            txt5Euros.Text = (nud5Euros.Value * 5).ToString();
        }


        #endregion Eventos

        #region Métodos Privados

        /// <summary>
        /// Valida que los campos requeridos no esten vacion
        /// </summary>
        /// <returns>Un bool, indicando si la validacin</returns>
        private bool ValidarCampos()
        {
            bool bStatus = true;
            if (cboSucursal.Text == "")
            {
                epError.SetError(cboSucursal, "Debe ingresar una Sucursal ");
                bStatus = false;
            }
            else
                epError.SetError(cboSucursal, "");
           
            if (chkColones.Checked == false && chkDolares.Checked == false && chkEuros.Checked == false)
            {
                epError.SetError(gpbMonedas, "El pedido debe estar en alguna moneda");
                bStatus = false;
            }
            else
                epError.SetError(gpbMonedas, "");
            return bStatus;

           
        }



        /// <summary>
        /// Verifica si un monto se puede aceptar debido a la denominacion correspondiente
        /// </summary>
        /// <param name="monto">Monto digitado</param>
        /// <param name="denominacion">Denominacion correspondiente del pedido</param>
        /// <param name="t">Objeto Textbox donde se encuentra el monto</param>
        /// <returns></returns>
        private bool ValidarMontos(Decimal monto,Decimal denominacion, TextBox t, ref bool aux)
        {
            
            bool bStatus = true;
            if (auxniquel == false)
            {
                if ((monto / 100) % denominacion != 0)
                {
                    epError.SetError(t, "No se puede ingresar ese monto");   // ingresar validacion de montos
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
            aux100dolares == false || aux50dolares == false || aux20dolares == false || aux10dolares == false || aux5dolares == false || aux1dolares == false || aux500euros == false ||
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
                Convert.ToDecimal(txt10Dolares.Text) + Convert.ToDecimal(txt5Dolares.Text) + Convert.ToDecimal(txt1Dolar.Text);
          
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
                txtMontoGeneral.Text = _total_colones.ToString("C3", CultureInfo.CreateSpecificCulture("es-CR"));
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
                                         Dictionary<double,decimal> denominaciones,ArrayList numeros)
        {
            // Leer las denominaciones

           // this.identificarDenominaciones(numeros, moneda);

   
            
                Sucursal sucursal = (Sucursal)cboSucursal.SelectedItem;

                CargaSucursal carga = this.buscarCarga(sucursal, fecha);

                foreach (Decimal d in numeros)
                {
                    Denominacion denominacion = new Denominacion(valor: Convert.ToDecimal(d), moneda: moneda);

                    _mantenimiento.verificarDenominacion(ref denominacion);

                    this.asignarCartuchos(Convert.ToDouble(denominacion.Valor), ref carga,denominaciones,moneda);
                }          

        }



        /// <summary>
        /// Buscar si ya se registro la carga para una Sucursal.
        /// </summary>
        private CargaSucursal buscarCarga(Sucursal sucursal, DateTime fecha)
        {
            CargaSucursal nueva = new CargaSucursal();
            EmpresaTransporte emp = (EmpresaTransporte)cboTransportadora.SelectedItem;
            nueva.Colaborador_Registro = _colaborador;
            foreach (CargaSucursal carga in _cargas)
                if (carga.Sucursal.Codigo == sucursal.Codigo)
                    return carga;
            if (rdbEntrega.Checked == true)
            {
                Bolsa bolsita = new Bolsa();


              
                nueva = new CargaSucursal(sucursal, transportadora: emp, fecha_asignada: dtpFecha.Value, cajero: _colaborador, estado:EstadosCargasSucursales.Entrega_Boveda);
                nueva.EstadoAprobadas = EstadoAprobacionCargas.Por_Aprobar;
                nueva.EntregaBovedaSucursal = EntregaRecibo.Entregas;
                nueva.Mutilado = false;

            }
            else
            {
                nueva = new CargaSucursal(sucursal, transportadora: emp, fecha_asignada: dtpFecha.Value, cajero: _colaborador, manifiesto: null, estado: EstadosCargasSucursales.Entrega_Boveda);
                nueva.EstadoAprobadas = EstadoAprobacionCargas.Por_Aprobar;
                nueva.Mutilado = false;
                nueva.EntregaBovedaSucursal = EntregaRecibo.Pedidos;
            }
     

            _cargas.Add(nueva);

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
        private void asignarCartuchos(double p_monto, ref CargaSucursal carga,Dictionary<double,decimal> denominaciones,Monedas moneda)
        {
            decimal monto = 0;


            monto = denominaciones[p_monto];

            Denominacion denominacion = new Denominacion(valor: Convert.ToDecimal(p_monto), moneda: moneda);

            _mantenimiento.verificarDenominacion(ref denominacion);

                double cantidad_total = (double)Math.Ceiling(monto / denominacion.Valor);

                double cantidad_cartucho = (double)(monto / denominacion.Valor);

        
                    CartuchoCargaSucursal cartucho = new CartuchoCargaSucursal(movimiento: carga, cantidad_asignada: cantidad_cartucho,
                                                                     denominacion: denominacion);

                    carga.agregarCartucho(cartucho);

                switch (denominacion.Moneda)
                {
                    case Monedas.Colones: carga.Monto_pedido_colones += monto; break;
                    case Monedas.Dolares: carga.Monto_pedido_dolares += monto; break;
                    case Monedas.Euros: carga.Monto_pedido_euros += monto; break;
                }

        }

        /// <summary>
        /// 
        /// </summary>
        private void agregarCarga()
        {
 
        }


        #endregion Métodos Privados

        #region Metodos Publicos
        /// <summary>
        /// Actualiza 
        /// </summary>
        /// <param name="manifiestos"></param>
        public void actualizarManifiestos(BindingList<ManifiestoSucursalCarga> manifiestos)
        {
            try
            {
                this._manifiestos = manifiestos;
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        #endregion Metodos Publicos

        private void frmPedidoSucursales_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Cambio en la escogencia de la sucursal
        /// </summary>
        private void cboSucursal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSucursal.SelectedIndex == 0)
                return;

            Sucursal punto = (Sucursal)cboSucursal.SelectedItem;
            _transportadora = punto.Empresa;
            cboTransportadora.Text = _transportadora.ToString();
        }


        /// <summary>
        /// Cambio en la transportadora original
        /// </summary>
        private void cboTransportadora_SelectedIndexChanged(object sender, EventArgs e)
        {

            //Sucursal punto = (Sucursal)cboSucursal.SelectedItem;

            //EmpresaTransporte t = punto.Empresa;

             //EmpresaTransporte emp_combo = (EmpresaTransporte)cboTransportadora.SelectedItem;
             //CargaSucursal carga = new CargaSucursal();

            //if (_transportadora.ID != emp_combo.ID)
            //{
            //    frmValidacionCoordinadorSucursales validacion = new frmValidacionCoordinadorSucursales(ref carga);
            //    validacion.ShowDialog();

            //    _colaborador_verificacion = carga.ColaboradorVerificadorTransportadora;
            //}



        }



        


    }
}
