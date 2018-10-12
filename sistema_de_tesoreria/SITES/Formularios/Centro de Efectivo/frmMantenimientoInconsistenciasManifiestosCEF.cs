//
//  @ Project : 
//  @ File Name : frmMantenimientoInconsistenciasManifiestosCEF.cs
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

    public partial class frmMantenimientoInconsistenciasManifiestosCEF : Form
    {

        #region Constantes

        #endregion Constantes

        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private SeguridadBL _seguridad = SeguridadBL.Instancia;
        private AtencionBL _atencion = AtencionBL.Instancia;
        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;

        private BindingList<PuntoVenta> _puntos = new BindingList<PuntoVenta>();

        private InconsistenciaManifiestoCEF _inconsistencia = null;
        private ManifiestoCEF _manifiesto = null;
        private Colaborador _coordinador = null;

        DateTime _fecha_actual;
        private bool _supervisor = false;
        private bool _coordinador_valido = false;
        private bool _dia_valido = false;

        #endregion Atributos

        #region Constructor

        public frmMantenimientoInconsistenciasManifiestosCEF(Colaborador coordinador)
        {
            InitializeComponent();

            _coordinador = coordinador;

            cboCoordinador.Text = _coordinador.ToString();

            try
            {
                this.cargarDatos();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public frmMantenimientoInconsistenciasManifiestosCEF(InconsistenciaManifiestoCEF inconsistencia, Colaborador coordinador)
        {
            InitializeComponent();

            _inconsistencia = inconsistencia;
            _coordinador = coordinador;

            try
            {
                this.cargarDatos();
                
                // Mostrar los datos de la inconsistencia

                cboCamara.Text = _inconsistencia.Camara.Identificador;

                txtComentario.Text = _inconsistencia.Comentario;

                this.mostrarDatos(_inconsistencia.Manifiesto);

                nudMontoColonesReportado.Value = _inconsistencia.Monto_colones_reportado;
                nudMontoDolaresReportado.Value = _inconsistencia.Monto_dolares_reportado;
                nudMontoEurosReportado.Value = _inconsistencia.Monto_euros_reportado;
                nudMontoTotalReportado.Value = _inconsistencia.Monto_total_reportado;
                nudMontoTotalReal.Value = _inconsistencia.Monto_total_real;

                BindingList<Manifiesto> manifiestos = (BindingList<Manifiesto>)dgvManifiestos.DataSource;

                manifiestos.Add(_inconsistencia.Manifiesto);

                // Validar si se pueden modificar los datos de la inconsistencia

                bool estado = _supervisor || (_coordinador_valido && _dia_valido);

                gbManifiestos.Enabled = estado;
                gbDatosReportados.Enabled = estado;
                gbDetalle.Enabled = estado;
                btnGuardar.Enabled = estado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        /// <summary>
        /// Cargar los datos de las listas.
        /// </summary>
        private void cargarDatos()
        {

            try
            {
                dgvManifiestos.AutoGenerateColumns = false;

                // Obtener la fecha del servidor

                _fecha_actual = _coordinacion.obtenerFechaHora();

                // Validar si el coordinador tiene permisos de supervisor

                _supervisor = _coordinador.Puestos.Contains(Puestos.Supervisor);

                cboCoordinador.Enabled = _supervisor;
                dtpFechaManifiesto.Enabled = _supervisor;

                // Cargar las listas

                cboCajero.ListaMostrada = _seguridad.listarColaboradoresPorPuestoArea(Areas.CentroEfectivo, Puestos.CajeroA, Puestos.CajeroB);
                cboDigitador.ListaMostrada = _seguridad.listarColaboradoresPorPuestoArea(Areas.CentroEfectivo, Puestos.Digitador);
                cboCliente.ListaMostrada = _mantenimiento.listarClientes(string.Empty);
                cboCamara.ListaMostrada = _mantenimiento.listarCamarasPorArea(Areas.CentroEfectivo);

                foreach (Cliente cliente in cboCliente.ListaMostrada)
                {

                    foreach (PuntoVenta punto in cliente.Puntos_venta)
                        _puntos.Add(punto);

                }

                dgvManifiestos.DataSource = new BindingList<Manifiesto>();

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
                ex.mostrarMensaje();
            }

        }

        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de buscar manifiesto.
        /// </summary>
        private void btnBuscarManifiesto_Click(object sender, EventArgs e)
        {

            try
            {
                string codigo = txtManifiesto.Text;

                if (codigo == string.Empty && codigo.Length < 4) return;

                dgvManifiestos.DataSource = _atencion.listarManifiestosCEFRecientes(codigo);

                txtManifiesto.Text = string.Empty;
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

            if (dgvManifiestos.SelectedRows.Count == 0 || cboCajero.SelectedItem == null || cboDigitador.SelectedItem == null ||
                cboPuntoVenta.SelectedItem == null || cboCamara.SelectedItem == null)
            {
                Excepcion.mostrarMensaje("ErrorInconsistenciaDatosRegistro");
                return;
            }

            try
            {
                frmAdministracionInconsistenciasCEF padre = (frmAdministracionInconsistenciasCEF)this.Owner;

                Camara camara = (Camara)cboCamara.SelectedItem;
                DateTime fecha = dtpFecha.Value;
                string comentario = txtComentario.Text;

                decimal monto_colones_reportado = nudMontoColonesReportado.Value;
                decimal monto_dolares_reportado = nudMontoDolaresReportado.Value;
                decimal monto_total_reportado = nudMontoTotalReportado.Value;
                decimal monto_euros_reportado = nudMontoEurosReportado.Value;

                PuntoVenta punto_venta = (PuntoVenta)cboPuntoVenta.SelectedItem;
                Colaborador cajero = (Colaborador)cboCajero.SelectedItem;
                Colaborador digitador = (Colaborador)cboDigitador.SelectedItem;
                DateTime fecha_manifiesto = dtpFechaManifiesto.Value;

                decimal monto_colones = nudMontoColonesReal.Value;
                decimal monto_dolares = nudMontoDolaresReal.Value;
                decimal monto_total = nudMontoTotalReal.Value;
                decimal monto_euros = nudMontoEurosReal.Value;
                short depositos = (short)nudDepositosReales.Value;

                _manifiesto.Cajero = cajero;
                _manifiesto.Digitador = digitador;
                _manifiesto.Coordinador = _coordinador;
                _manifiesto.Fecha_procesamiento = fecha_manifiesto;
                _manifiesto.Punto_venta = punto_venta;
                _manifiesto.Monto_colones = monto_colones;
                _manifiesto.Monto_dolares = monto_dolares;
                _manifiesto.Depositos = depositos;
                _manifiesto.Monto_Euros = monto_euros;

                // Verificar si la inconsistencia es nueva

                if (_inconsistencia == null)
                {
                    // Agregar la inconsistencia

                    if (Mensaje.mostrarMensajeConfirmacion("MensajeInconsistenciaRegistro") == DialogResult.Yes)
                    {
                        InconsistenciaManifiestoCEF nueva =
                            new InconsistenciaManifiestoCEF(_manifiesto, camara, fecha, monto_colones_reportado,
                                                            monto_dolares_reportado, monto_total_reportado, monto_total,
                                                            comentario, monto_euros_reportado);

                        _coordinacion.agregarInconsistenciaManifiestoCEF(ref nueva);

                        padre.agregarInconsistenciaManifiestoCEF(nueva);
                        Mensaje.mostrarMensaje("MensajeInconsistenciaConfirmacionRegistro");
                        this.Close();
                    }

                }
                else
                {
                    InconsistenciaManifiestoCEF copia =
                            new InconsistenciaManifiestoCEF(_inconsistencia.Id, _manifiesto, camara, fecha, monto_colones_reportado, 
                                                            monto_dolares_reportado, monto_total_reportado, monto_total,
                                                            comentario,monto_euros_reportado);

                    _coordinacion.actualizarInconsistenciaManifiestoCEF(copia);

                    //Actualizar la inconsistencia

                    _inconsistencia.Manifiesto = _manifiesto;
                    _inconsistencia.Camara = camara;
                    _inconsistencia.Fecha = fecha;

                    _inconsistencia.Monto_colones_reportado = monto_colones_reportado;
                    _inconsistencia.Monto_dolares_reportado = monto_dolares_reportado;

                    _inconsistencia.Monto_total_reportado = monto_total_reportado;
                    _inconsistencia.Monto_total_real = monto_total;

                    padre.actualizarListaClientesManifiestos();
                    Mensaje.mostrarMensaje("MensajeInconsistenciaConfirmacionActualizacion");
                    this.Close();
                }

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
        /// Selección de otro manifiesto.
        /// </summary>
        private void dgvManifiestos_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvManifiestos.SelectedRows.Count > 0)
            {
                ManifiestoCEF manifiesto = (ManifiestoCEF)dgvManifiestos.SelectedRows[0].DataBoundItem;

                this.mostrarDatos(manifiesto);
            }
            else
            {
                this.deshabilitarOpciones();
            }

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
        /// Se selecciona el cuadro de búsqueda del manifiesto.
        /// </summary>
        private void txtManifiesto_Enter(object sender, EventArgs e)
        {
            this.AcceptButton = btnBuscarManifiesto;
        }

        /// <summary>
        /// Se deselecciona el cuadro de búsqueda del manifiesto.
        /// </summary>
        private void txtManifiesto_Leave(object sender, EventArgs e)
        {
            this.AcceptButton = btnGuardar;
        }

        /// <summary>
        /// El cuadro de texto del código del cliente pierde el foco.
        /// </summary>
        private void mtbCodigoCliente_Leave(object sender, EventArgs e)
        {
            this.validarCodigo();
        }

        /// <summary>
        /// Se cambia la fecha del manifiesto.
        /// </summary>
        private void dtpFechaManifiesto_ValueChanged(object sender, EventArgs e)
        {
            dtpFecha.MinDate = dtpFechaManifiesto.Value;
        }

        #endregion Eventos

        #region Métodos Privados

        /// <summary>
        /// Validar el código del punto de venta digitado.
        /// </summary>
        private void validarCodigo()
        {
            string codigo_cliente = mtbCodigoCliente.Text;

            if (!codigo_cliente.Equals(string.Empty))
            {
                int codigo = int.Parse(codigo_cliente);

                foreach (PuntoVenta punto in _puntos)
                {

                    if (punto.Id == codigo)
                    {
                        cboCliente.Text = punto.Cliente.Nombre;
                        cboPuntoVenta.Text = punto.Nombre;
                        mtbCodigoCliente.Text = string.Empty;

                        return;
                    }

                }

                cboCliente.Text = string.Empty;
                cboPuntoVenta.Text = string.Empty;

                cboCliente.Focus();
            }

        }

        /// <summary>
        /// Mostrar los datos de un manifiesto.
        /// </summary>
        private void mostrarDatos(ManifiestoCEF manifiesto)
        {
            _manifiesto = manifiesto;

            // Mostrar los datos

            nudMontoColonesReal.Value = _manifiesto.Monto_colones;
            nudMontoDolaresReal.Value = _manifiesto.Monto_dolares;
            nudDepositosReales.Value = _manifiesto.Depositos;

            bool estado = true;

            if (_manifiesto.Coordinador != null)
            {
                _coordinador_valido = _manifiesto.Coordinador.Equals(_coordinador);
                _dia_valido = manifiesto.Fecha_procesamiento.Date == _fecha_actual.Date;

                estado = _supervisor || (_coordinador_valido && _dia_valido);

                cboCajero.Text = _manifiesto.Cajero.ToString();
                cboDigitador.Text = _manifiesto.Digitador.ToString();
                cboCoordinador.Text = _manifiesto.Coordinador.ToString();
                dtpFechaManifiesto.Value = (DateTime)_manifiesto.Fecha_procesamiento;
            }

            // Validar si el coordinador puede modificar el manifiesto

            pnlDetallesManifiesto.Enabled = estado;
            btnGuardar.Enabled = estado;

            if (_manifiesto.Punto_venta != null)
            {
                cboCliente.Text = _manifiesto.Punto_venta.Cliente.Nombre;
                cboPuntoVenta.Text = _manifiesto.Punto_venta.Nombre;
            }
            else
            {
                cboCliente.Text = string.Empty;
                cboPuntoVenta.Text = string.Empty;
            }

        }

        /// <summary>
        /// Borrar los datos.
        /// </summary>
        private void borrarDatos()
        {
            cboCajero.Text = string.Empty;
            cboDigitador.Text = string.Empty;
            cboCoordinador.Text = _coordinador.ToString();
            cboCliente.Text = string.Empty;
            cboPuntoVenta.Text = string.Empty;

            dtpFechaManifiesto.Value = DateTime.Today;

            nudMontoColonesReal.Value = 0;
            nudMontoDolaresReal.Value = 0;
            nudDepositosReales.Value = 0;
        }

        /// <summary>
        /// Deshabilitar las ocpiones de guardado y modificación.
        /// </summary>
        private void deshabilitarOpciones()
        {
            this.borrarDatos();

            pnlDetallesManifiesto.Enabled = false;
            btnGuardar.Enabled = false;
        }

        #endregion Métodos Privados

    }

}
