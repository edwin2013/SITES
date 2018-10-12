//
//  @ Project : 
//  @ File Name : frmMantenimientoInconsistenciasDigitador.cs
//  @ Date : 27/07/2011
//  @ Author : Erick Chavarría 
//

using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Globalization;

using CommonObjects;
using BussinessLayer;
using LibreriaMensajes;

namespace GUILayer
{

    public partial class frmMantenimientoInconsistenciasDigitadores : Form
    {

        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private SeguridadBL _seguridad = SeguridadBL.Instancia;
        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;
        private AtencionBL _atencion = AtencionBL.Instancia;

        private Colaborador _coordinador = null;
        private InconsistenciaDigitador _inconsistencia = null;

        #endregion Atributos

        #region Constructor

        public frmMantenimientoInconsistenciasDigitadores(Colaborador coordinador)
        {
            InitializeComponent();

            _coordinador = coordinador;

            txtCoordinador.Text = _coordinador.ToString();

            try
            {
                this.cargarDatos();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        public frmMantenimientoInconsistenciasDigitadores(InconsistenciaDigitador inconsistencia,  Colaborador coordinador)
        {
            InitializeComponent();

            _coordinador = coordinador;
            _inconsistencia = inconsistencia;

            try
            {
                this.cargarDatos();

                txtCoordinador.Text = _inconsistencia.Coordinador.ToString();
                cboDigitador.Text = _inconsistencia.Digitador.ToString();
                cboCliente.Text = _inconsistencia.Punto_venta.Cliente.Nombre;
                cboPuntoVenta.Text = _inconsistencia.Punto_venta.Nombre;

                BindingList<Deposito> depositos = (BindingList<Deposito>)dgvDepositos.DataSource;

                depositos.Add(_inconsistencia.Deposito);

                if (_inconsistencia.Referencia_erronea != null)
                {
                    chkReferencia.Checked = true;
                    mtbReferencia.Text = _inconsistencia.Referencia_erronea.ToString();
                }

                if (_inconsistencia.Cuenta_erronea != null)
                {
                    chkCuenta.Checked = true;
                    mtbCuenta.Text = _inconsistencia.Cuenta_erronea.ToString();
                }

                if (_inconsistencia.Moneda_erronea != null)
                {
                    chkMoneda.Checked = true;
                    cboMoneda.SelectedIndex = (byte)_inconsistencia.Moneda_erronea;
                }

                if (_inconsistencia.Monto_erroneo != null)
                {
                    chkMonto.Checked = true;
                    nudMonto.Value = (decimal)_inconsistencia.Monto_erroneo;
                }

                chkROECedulaIncorrecta.Checked = _inconsistencia.ROE_cedula_incorrecta;
                chkROECuentaIncorrecta.Checked = _inconsistencia.ROE_cuenta_incorrecta;
                chkROEOrigenIncorrecto.Checked = _inconsistencia.ROE_origen_incorrecto;
                chkROEReimpresion.Checked = _inconsistencia.ROE_reimpresion;
                chkROESello.Checked = _inconsistencia.ROE_sello;
                chkROEFirma.Checked = _inconsistencia.ROE_firma;
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Cargar los datos de las listas.
        /// </summary>
        private void cargarDatos()
        {

            try
            {
                dgvDepositos.AutoGenerateColumns = false;
                dgvDepositos.DataSource = new BindingList<Deposito>();

                // Cargar las listas

                cboDigitador.ListaMostrada = _seguridad.listarColaboradoresPorPuestoArea(Areas.CentroEfectivo, Puestos.Digitador);
                cboCliente.ListaMostrada = _mantenimiento.listarClientes(string.Empty);

                // Establecer el separador de decimales

                CultureInfo anterior = System.Threading.Thread.CurrentThread.CurrentCulture;
                CultureInfo nueva = (CultureInfo)anterior.Clone();

                nueva.NumberFormat.NumberDecimalSeparator = ".";
                nueva.NumberFormat.NumberGroupSeparator = ",";
                System.Threading.Thread.CurrentThread.CurrentCulture = nueva;

                CultureInfo cultura = System.Threading.Thread.CurrentThread.CurrentCulture;
            }
            catch (Excepcion ex)
            {
                throw ex;
            }

        }

        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de buscar deposito.
        /// </summary>
        private void btnBuscar_Click(object sender, EventArgs e)
        {

            try
            {
                if (txtDeposito.Text == string.Empty) return;

                string referencia = txtDeposito.Text;
                int valor_referencia = 0;

                if (!int.TryParse(referencia, out valor_referencia)) return;

                dgvDepositos.DataSource = _atencion.listarDepositos(valor_referencia);

                txtDeposito.Text = string.Empty;
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de guardar.
        /// </summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {

            try
            {

                if (dgvDepositos.SelectedRows.Count == 0 || cboDigitador.SelectedItem == null ||
                    cboPuntoVenta.SelectedItem == null)
                {
                    Excepcion.mostrarMensaje("ErrorInconsistenciaDatosRegistro");
                    return;
                }

                try
                {
                    frmAdministracionInconsistenciasDigitadores padre = (frmAdministracionInconsistenciasDigitadores)this.Owner;

                    Deposito deposito = (Deposito)dgvDepositos.SelectedRows[0].DataBoundItem;
                    Colaborador digitador = (Colaborador)cboDigitador.SelectedItem;
                    DateTime fecha = dtpFecha.Value;
                    PuntoVenta punto_venta = (PuntoVenta)cboPuntoVenta.SelectedItem;
                    byte t = (byte)nudT.Value;

                    int? referencia = chkReferencia.Checked ? (int?)int.Parse(mtbReferencia.Text) : (int?)null;
                    int? cuenta = chkCuenta.Checked ? int.Parse(mtbCuenta.Text) : (int?)null;
                    Monedas? moneda = chkMoneda.Checked ? (Monedas)cboMoneda.SelectedIndex : (Monedas?)null;
                    decimal? monto = chkMonto.Checked ? nudMonto.Value : (decimal?)null;

                    bool roe_cedula_incorrecta = chkROECedulaIncorrecta.Checked;
                    bool roe_origen_incorrecto = chkROEOrigenIncorrecto.Checked;
                    bool roe_cuenta_incorrecta = chkROECuentaIncorrecta.Checked;
                    bool roe_reimpresion = chkROEReimpresion.Checked;
                    bool roe_firma = chkROEFirma.Checked;
                    bool roe_sello = chkROESello.Checked;

                    // Verificar si la inconsistencia es nueva

                    if (_inconsistencia == null)
                    {
                        // Agregar la inconsistencia

                        if (Mensaje.mostrarMensajeConfirmacion("MensajeInconsistenciaRegistro") == DialogResult.Yes)
                        {
                            InconsistenciaDigitador nueva =
                                new InconsistenciaDigitador(deposito: deposito, coordinador: _coordinador, digitador: digitador, fecha: fecha,
                                                            punto_venta: punto_venta, t: t, referencia_erronea: referencia, 
                                                            cuenta_erronea: cuenta, monto_erroneo: monto, moneda_erronea: moneda,
                                                            roe_cedula_incorrecta: roe_cedula_incorrecta,
                                                            roe_cuenta_incorrecta: roe_cuenta_incorrecta,
                                                            roe_origen_incorrecto: roe_origen_incorrecto,
                                                            roe_reimpresion: roe_reimpresion,
                                                            roe_firma: roe_firma, roe_sello: roe_sello);

                            _coordinacion.agregarInconsistenciaDigitador(ref nueva);

                            padre.agregarInconsistencia(nueva);
                            Mensaje.mostrarMensaje("MensajeInconsistenciaConfirmacionRegistro");
                            this.Close();
                        }

                    }
                    else
                    {
                        InconsistenciaDigitador copia =
                            new InconsistenciaDigitador(id: _inconsistencia.Id, deposito: deposito, coordinador: _coordinador, digitador: digitador,
                                                        fecha: fecha, punto_venta: punto_venta, t: t, referencia_erronea:
                                                        referencia, cuenta_erronea: cuenta, monto_erroneo: monto, moneda_erronea: moneda,
                                                        roe_cedula_incorrecta: roe_cedula_incorrecta,
                                                        roe_cuenta_incorrecta: roe_cuenta_incorrecta,
                                                        roe_origen_incorrecto: roe_origen_incorrecto,
                                                        roe_reimpresion: roe_reimpresion,
                                                        roe_firma: roe_firma, roe_sello: roe_sello);

                        _coordinacion.actualizarInconsistenciaDigitador(copia);

                        //Actualizar la inconsistencia

                        _inconsistencia.Deposito = deposito;
                        _inconsistencia.Digitador = digitador;
                        _inconsistencia.Coordinador = _coordinador;
                        _inconsistencia.Fecha = fecha;
                        _inconsistencia.Punto_venta = punto_venta;
                        _inconsistencia.T = t;

                        _inconsistencia.Referencia_erronea = referencia;
                        _inconsistencia.Cuenta_erronea = cuenta;
                        _inconsistencia.Moneda_erronea = moneda;
                        _inconsistencia.Monto_erroneo = monto;

                        _inconsistencia.ROE_cedula_incorrecta = roe_cedula_incorrecta;
                        _inconsistencia.ROE_cuenta_incorrecta = roe_cuenta_incorrecta;
                        _inconsistencia.ROE_origen_incorrecto = roe_origen_incorrecto;
                        _inconsistencia.ROE_reimpresion = roe_reimpresion;
                        _inconsistencia.ROE_sello = roe_sello;
                        _inconsistencia.ROE_firma = roe_firma;

                        padre.actualizarLista();
                        Mensaje.mostrarMensaje("MensajeInconsistenciaConfirmacionActualizacion");
                        this.Close();
                    }

                }
                catch (Excepcion ex)
                {
                    ex.mostrarMensaje();
                }

            }
            catch(Excepcion ex)
            {
                ex.mostrarMensaje();
            }
            
        }

        /// <summary>
        /// Clic en el botón de agregar deposito.
        /// </summary>
        private void btnAgregarDeposito_Click(object sender, EventArgs e)
        {

            try
            {
                frmMantenimientoDepositos formulario = new frmMantenimientoDepositos();

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de modificar deposito.
        /// </summary>
        private void btnModificarDeposito_Click(object sender, EventArgs e)
        {

            try
            {
                Deposito deposito = (Deposito)dgvDepositos.SelectedRows[0].DataBoundItem;
                frmMantenimientoDepositos formulario = new frmMantenimientoDepositos(deposito);

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de agregar un punto de venta para un cliente.
        /// </summary>
        private void btnAgregarPuntoVenta_Click(object sender, EventArgs e)
        {

            try
            {
                Cliente cliente = (Cliente)cboCliente.SelectedItem;
                frmInclusionPuntosVenta formulario = new frmInclusionPuntosVenta(ref cliente);

                formulario.ShowDialog(this);

                cboPuntoVenta.ListaMostrada = cliente.Puntos_venta;
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
        /// Se selecciona otro cliente.
        /// </summary>
        private void cboCliente_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cboCliente.SelectedItem != null)
            {
                Cliente cliente = (Cliente)cboCliente.SelectedItem;

                cboPuntoVenta.ListaMostrada = cliente.Puntos_venta;
                btnAgregarPuntoVenta.Enabled = true;
            }
            else
            {
                cboPuntoVenta.ListaMostrada = null;
                btnAgregarPuntoVenta.Enabled = false;
            }

        }

        /// <summary>
        /// Se marca una inconsistencia en la cuenta.
        /// </summary>
        private void chkCuenta_CheckedChanged(object sender, EventArgs e)
        {
            mtbCuenta.Enabled = chkCuenta.Checked;
        }

        /// <summary>
        /// Se marca una inconsistencia en la referencia.
        /// </summary>
        private void chkReferencia_CheckedChanged(object sender, EventArgs e)
        {
            mtbReferencia.Enabled = chkReferencia.Checked;
        }

        /// <summary>
        /// Se marca una inconsistencia en el monto.
        /// </summary>
        private void chkMonto_CheckedChanged(object sender, EventArgs e)
        {
            nudMonto.Enabled = chkMonto.Checked;
        }

        /// <summary>
        /// Se marca una inconsistencia en la moneda.
        /// </summary>
        private void chkMoneda_CheckedChanged(object sender, EventArgs e)
        {
            cboMoneda.Enabled = chkMoneda.Checked;
        }

        /// <summary>
        /// Se selecciona otro deposito.
        /// </summary>
        private void dgvDepositos_SelectionChanged(object sender, EventArgs e)
        {
            btnModificarDeposito.Enabled = dgvDepositos.SelectedRows.Count > 0;
        }

        /// <summary>
        /// Formato de una celda de la lista de depositos.
        /// </summary>
        private void dgvDepositos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if (e.ColumnIndex == Deposito.Index)
            {
                Deposito deposito = (Deposito)dgvDepositos.Rows[e.RowIndex].DataBoundItem;

                String tipo = string.Empty;

                switch (deposito.Moneda)
                {
                    case Monedas.Colones:
                        tipo = "Colones";
                        break;
                    case Monedas.Dolares:
                        tipo = "Dólares";
                        break;
                }

                dgvDepositos[Moneda.Index, e.RowIndex].Value = tipo;
            }

        }

        #endregion Eventos

    }

}
