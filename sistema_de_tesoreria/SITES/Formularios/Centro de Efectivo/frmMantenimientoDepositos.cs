//
//  @ Project : 
//  @ File Name : frmMantenimientoInconsistenciasDigitador.cs
//  @ Date : 27/07/2011
//  @ Author : Erick Chavarría 
//

using System;
using System.Windows.Forms;
using System.Globalization;

using CommonObjects;
using BussinessLayer;
using LibreriaMensajes;

namespace GUILayer
{

    public partial class frmMantenimientoDepositos : Form
    {

        #region Atributos

        private AtencionBL _atencion = AtencionBL.Instancia;
        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;

        private Deposito _deposito = null;

        #endregion Atributos

        #region Constructor

        public frmMantenimientoDepositos()
        {
            InitializeComponent();

            cboMoneda.SelectedIndex = (byte)Monedas.Colones;
        }

        public frmMantenimientoDepositos(Deposito deposito)
        {
            InitializeComponent();

            _deposito = deposito;

            nudMonto.Value = deposito.Monto;
            mtbCuenta.Text = deposito.Cuenta.ToString();
            mtbReferencia.Text = deposito.Referencia.ToString();
            cboMoneda.SelectedIndex = (byte)deposito.Moneda;
        }

        /// <summary>
        /// Definir los separadores de millares y decimales.
        /// </summary>
        private void definirSeparadores()
        {
            CultureInfo anterior = System.Threading.Thread.CurrentThread.CurrentCulture;
            CultureInfo nueva = (CultureInfo)anterior.Clone();

            nueva.NumberFormat.NumberDecimalSeparator = ".";
            nueva.NumberFormat.NumberGroupSeparator = ",";
            System.Threading.Thread.CurrentThread.CurrentCulture = nueva;

            CultureInfo cultura = System.Threading.Thread.CurrentThread.CurrentCulture;
        }

        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de guardar.
        /// </summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Verificar que se hayan seleccionado los datos

            if (mtbCuenta.Text.Equals(string.Empty) ||
                mtbReferencia.Text.Equals(string.Empty) ||
                cboMoneda.SelectedItem == null)
            {
                Excepcion.mostrarMensaje("ErrorDepositoDatosRegistro");
                return;
            }

            try
            {
                long referencia = long.Parse(mtbReferencia.Text);
                long cuenta = long.Parse(mtbCuenta.Text);
                decimal monto = nudMonto.Value;
                Monedas moneda = (Monedas)cboMoneda.SelectedIndex;

                // Si el deposito es nuevo

                if (_deposito == null)
                {
                    // Agregar el deposito

                    if (Mensaje.mostrarMensajeConfirmacion("MensajeDepositoRegistro") == DialogResult.Yes)
                    {
                        Deposito nuevo = new Deposito(referencia, monto: monto, moneda: moneda, cuenta: cuenta);

                        _atencion.agregarDeposito(ref nuevo);

                        Mensaje.mostrarMensaje("MensajeDepositoConfirmacionRegistro");
                        this.Close();
                    }

                }
                else
                {
                    Deposito copia = new Deposito(referencia, id: _deposito.ID, monto: monto, moneda: moneda, cuenta: cuenta);

                    _atencion.actualizarDeposito(copia);

                    // Actualizar el deposito

                    _deposito.Referencia = referencia;
                    _deposito.Monto = monto;
                    _deposito.Moneda = moneda;
                    _deposito.Cuenta = cuenta;

                    Mensaje.mostrarMensaje("MensajeDepositoConfirmacionActualizacion");
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

        #endregion Eventos

    }

}
