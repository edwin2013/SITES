//
//  @ Project : 
//  @ File Name : frmAsignacionMontosCEF.cs
//  @ Date : 27/07/2011
//  @ Author : Erick Chavarría 
//

using System;
using System.ComponentModel;
using System.Windows.Forms;

using CommonObjects;
using BussinessLayer;
using LibreriaMensajes;

namespace GUILayer
{

    public partial class frmAsignacionMontosCEF : Form
    {

        #region Atributos

        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;
        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private SeguridadBL _seguridad = SeguridadBL.Instancia;
        private AtencionBL _atencion = AtencionBL.Instancia;

        private BindingList<PuntoVenta> _puntos = new BindingList<PuntoVenta>();

        private PlanillaCEF _planilla = null;
        private Colaborador _coordinador = null;
        private Colaborador _cajero_receptor = null;

        private DateTime _fecha_actual;
        private bool _supervisor = false;
        private bool _coordinador_valido = false;
        private bool _dia_valido = false;

        #endregion Atributos

        #region Constructor

        public frmAsignacionMontosCEF(Colaborador coordinador)
        {
            InitializeComponent();

            _coordinador = coordinador;

            try
            {
                dgvManifiestos.AutoGenerateColumns = false;
                dgvSegregados.AutoGenerateColumns = false;

                dgvSegregados.DataSource = new BindingList<SegregadoCEF>();

                // Obtener la fecha del servidor

                _fecha_actual = _coordinacion.obtenerFechaHora().Date;

                // Cargar las listas

                cboCoordinador.ListaMostrada = _seguridad.listarColaboradoresPorPuestoArea(Areas.CentroEfectivo, Puestos.Coordinador);
                cboDigitador.ListaMostrada = _seguridad.listarColaboradoresPorPuestoArea(Areas.CentroEfectivo, Puestos.Digitador);
                cboCajero.ListaMostrada = _seguridad.listarColaboradoresPorPuestoArea(Areas.CentroEfectivo, Puestos.CajeroA, Puestos.CajeroB);;
                cboCliente.ListaMostrada = _mantenimiento.listarClientes(string.Empty);

                cboCoordinador.Text = _coordinador.ToString();

                foreach (Cliente cliente in cboCliente.ListaMostrada)
                {

                    foreach (PuntoVenta punto in cliente.Puntos_venta)
                        _puntos.Add(punto);

                }

                // Validar si el coordinador tiene permisos de supervisor

                _supervisor = _coordinador.Puestos.Contains(Puestos.Supervisor);
                
                dtpFecha.Enabled = _supervisor;
            }
            catch (Excepcion ex)
            {
                this.Close();
                throw ex;
            }

        }

        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de buscar.
        /// </summary>
        private void btnBuscar_Click(object sender, EventArgs e)
        {

            try
            {
                string codigo = txtCodigoBuscado.Text;

                if (codigo == string.Empty && codigo.Length < 4) return;
                
               dgvManifiestos.DataSource = _atencion.listarManifiestosCEFRecientes(codigo);

                txtCodigoBuscado.Text = string.Empty;

                if (dgvManifiestos.RowCount > 0 && gbDatosManifiesto.Enabled)
                {

                    if (rbCliente.Checked)
                        cboCliente.Focus();
                    else
                        mtbCodigoCliente.Focus();

                }

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

            if (cboCliente.SelectedItem == null || cboPuntoVenta.SelectedItem == null ||
                cboDigitador.SelectedItem == null || cboCajero.SelectedItem == null ||
                cboCoordinador.SelectedItem == null)
            {
                Excepcion.mostrarMensaje("ErrorManifiestoDatosActualizacionCEF");
                return;
            }

            try
            {
                Colaborador coordinador = (Colaborador)cboCoordinador.SelectedItem;
                Colaborador cajero = (Colaborador)cboCajero.SelectedItem;
                Colaborador digitador = (Colaborador)cboDigitador.SelectedItem;
                PuntoVenta punto_venta = (PuntoVenta)cboPuntoVenta.SelectedItem;
                //Colaborador cajeroreceptor = _cajero_receptor;
                
                decimal monto_colones = nudMontoColones.Value;
                decimal monto_dolares = nudMontoDolares.Value;
                decimal monto_euros = nudMontoEuros.Value;

                short depositos = (short)nudDepositos.Value;

                DateTime fecha_procesamiento = dtpFecha.Value;


                PlanillaCEF copia = null;

                if (_planilla is ManifiestoCEF)
                {
                    ManifiestoCEF manifiesto = (ManifiestoCEF)_planilla;
                    
                   

                    copia = new ManifiestoCEF(manifiesto.DB_ID, cajero: cajero, digitador: digitador, coordinador: coordinador,
                                              punto_venta: punto_venta, monto_colones: monto_colones, monto_dolares: monto_dolares,
                                              depositos: depositos, fecha_procesamiento: fecha_procesamiento, monto_euros: monto_euros);
                }

                else {
                    SegregadoCEF segregado = (SegregadoCEF)_planilla;

                    copia = new SegregadoCEF(segregado.Id, cajero, digitador, coordinador, punto_venta, monto_colones, monto_dolares,monto_euros, depositos, fecha_procesamiento);
                }

                _atencion.actualizarPlanillaCEF(copia, _coordinador);

                _planilla.Cajero = cajero;
                _planilla.Digitador = digitador;
                _planilla.Coordinador = coordinador;
                _planilla.Punto_venta = punto_venta;
                _planilla.Fecha_procesamiento = fecha_procesamiento;
                _planilla.Monto_colones = monto_colones;
                _planilla.Monto_dolares = monto_dolares;
                _planilla.Monto_Euros = monto_euros;
                _planilla.Depositos = depositos;

                txtCajero.Text = _planilla.Cajero.ToString();
                txtDigitador.Text = _planilla.Digitador.ToString();
                txtCoordinador.Text =  _planilla.Coordinador.ToString();
                txtCliente.Text = _planilla.Punto_venta.Cliente.Nombre;
                txtPuntoVenta.Text = _planilla.Punto_venta.Nombre;

                txtFechaProcesamiento.Text = ((DateTime)_planilla.Fecha_procesamiento).ToShortDateString();

                txtCodigoBuscado.Focus();

                Mensaje.mostrarMensaje("MensajeManifiestoConfirmacionActualizacion");

                // Actualizar el manifiesto en la lista de manifiestos

                dgvManifiestos.SelectedRows[0].Tag = _planilla;
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de reiniciar.
        /// </summary>
        private void btnReiniciar_Click(object sender, EventArgs e)
        {

            try
            {
                if (_planilla is ManifiestoCEF)
                    _atencion.actualizarManifiestoReiniciar((Manifiesto)_planilla);
                else
                    _atencion.reiniciarSegregado((SegregadoCEF)_planilla);

                _planilla.Cajero = null;
                _planilla.Digitador = null;
                _planilla.Coordinador = null;
                _planilla.Monto_colones = 0;
                _planilla.Monto_dolares = 0;
                _planilla.Depositos = 0;
                _planilla.Monto_Euros = 0;
                _planilla.Punto_venta = null;
               

                this.borrarDatos();
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
        /// Se selecciona un manifiesto de la lista de manifiestos.
        /// </summary>
        private void dgvManifiestos_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvManifiestos.SelectedRows.Count > 0)
            {
                ManifiestoCEF manifiesto = (ManifiestoCEF)dgvManifiestos.SelectedRows[0].DataBoundItem;

                if (manifiesto.Cajero_Reasignado != null)
                {
                    cboCajero.Text = Convert.ToString(manifiesto.Cajero_Reasignado);
                    txtCajeroAsignado.Text = Convert.ToString(manifiesto.Cajero_Reasignado);
                    _cajero_receptor = manifiesto.Cajero_Reasignado;
                }
                else
                {
                    if (manifiesto.Cajero_Receptor != null)
                    {
                        cboCajero.Text = Convert.ToString(manifiesto.Cajero_Receptor);
                        txtCajeroAsignado.Text = Convert.ToString(manifiesto.Cajero_Receptor);
                        _cajero_receptor = manifiesto.Cajero_Receptor;
                    }
                    else
                        txtCajeroAsignado.Text = string.Empty;
                }

                txtCodigoManifiesto.Text = manifiesto.Codigo;
                dgvSegregados.DataSource = manifiesto.Segregados;
                dgvSegregados.Enabled = true;

                if (manifiesto.Segregados.Count > 0) return;

                this.mostrarDatos(manifiesto);
            }
            else
            {
                this.deshabilitarOpciones();
            }

        }


        /// <summary>
        /// Se selecciona un manifiesto segregado de la lista de manifiestos segregados.
        /// </summary>
        private void dgvSegregados_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvSegregados.SelectedRows.Count > 0)
            {
                SegregadoCEF segregado = (SegregadoCEF)dgvSegregados.SelectedRows[0].DataBoundItem;

                this.mostrarDatos(segregado);
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
            }

        }

        /// <summary>
        /// Se escribe en el texto de búsqueda.
        /// </summary>
        private void txtCodigoBuscado_TextChanged(object sender, EventArgs e)
        {
            btnBuscar.Enabled = txtCodigoBuscado.Text.Length >= 4;
        }

        /// <summary>
        /// Se selecciona el cuadro de texto de búsqueda.
        /// </summary>
        private void txtCodigoBuscado_Enter(object sender, EventArgs e)
        {
            this.AcceptButton = btnBuscar;
        }

        /// <summary>
        /// Se selecciona la lista de clientes.
        /// </summary>
        private void cboCliente_Enter(object sender, EventArgs e)
        {
            this.AcceptButton = this.btnGuardar;
        }

        /// <summary>
        /// Se selecciona el cuadro de texto para la digitación del código del punto de venta.
        /// </summary>
        private void mtbCodigoCliente_Enter(object sender, EventArgs e)
        {
            this.AcceptButton = null;
        }

        /// <summary>
        /// Se selecciona el cuadro númerico del monto en colones.
        /// </summary>
        private void nudMontoColones_Enter(object sender, EventArgs e)
        {
            nudMontoColones.ResetText();
            this.AcceptButton = this.btnGuardar;
        }

        /// <summary>
        /// Se selecciona el cuadro númerico del monto en dolares.
        /// </summary>
        private void nudMontoDolares_Enter(object sender, EventArgs e)
        {
            nudMontoDolares.ResetText();
            this.AcceptButton = this.btnGuardar;
        }

        /// <summary>
        /// Se selecciona el cuadro númerico del número de depositos.
        /// </summary>
        private void nudDepositos_Enter(object sender, EventArgs e)
        {
            nudDepositos.ResetText();
            this.AcceptButton = this.btnGuardar;
        }

        /// <summary>
        /// El cuadro de texto del código del cliente pierde el foco.
        /// </summary>
        private void mtbCodigoCliente_Leave(object sender, EventArgs e)
        {
            this.validarCodigo();
        }

        /// <summary>
        /// Se presiona una tecla en el cuadro de texto del código del cliente.
        /// </summary>
        private void mtbCodigoCliente_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar.Equals('\r'))
                this.validarCodigo();

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

                        nudMontoColones.Focus();

                        return;
                    }

                }

                cboCliente.Text = string.Empty;
                cboPuntoVenta.Text = string.Empty;

                cboCliente.Focus();
            }

        }

        /// <summary>
        /// Mostrar los datos de un manifiesto o un manifiesto segregado.
        /// </summary>
        private void mostrarDatos(PlanillaCEF planilla)
        {
            _planilla = planilla;

            // Mostrar los datos

            this.borrarDatos();

            bool estado = true;

            if (_planilla.Coordinador != null)
            {
                _coordinador_valido = _planilla.Coordinador.Equals(_coordinador);
                _dia_valido = _planilla.Fecha_procesamiento.Date == _fecha_actual;

                estado = _supervisor || (_coordinador_valido && _dia_valido);

                txtCajero.Text = _planilla.Cajero.ToString();
                txtDigitador.Text = _planilla.Digitador.ToString();
                txtCoordinador.Text = _planilla.Coordinador.ToString();
                txtFechaProcesamiento.Text = ((DateTime)_planilla.Fecha_procesamiento).ToShortDateString();

                nudMontoColones.Value = _planilla.Monto_colones;
                nudMontoDolares.Value = _planilla.Monto_dolares;
                nudMontoEuros.Value = _planilla.Monto_Euros;
                nudDepositos.Value = _planilla.Depositos;

                if (_planilla.Punto_venta != null)
                {
                    txtCliente.Text = _planilla.Punto_venta.Cliente.Nombre;
                    txtPuntoVenta.Text = _planilla.Punto_venta.Nombre;
                }

            }

            // Validar si el coordinador puede modificar el manifiesto

            gbDatosManifiesto.Enabled = estado;
            btnGuardar.Enabled = estado;
            btnReiniciar.Enabled = estado;
        }

        /// <summary>
        /// Borrar los datos.
        /// </summary>
        private void borrarDatos()
        {
            nudMontoColones.Value = 0;
            nudMontoDolares.Value = 0;
            nudMontoEuros.Value = 0;
            nudDepositos.Value = 0;

            txtCajero.Text = string.Empty;
            txtDigitador.Text = string.Empty;
            txtCoordinador.Text = string.Empty;
            txtCliente.Text = string.Empty;
            txtPuntoVenta.Text = string.Empty;
            txtFechaProcesamiento.Text = string.Empty;
        }

        /// <summary>
        /// Deshabilitar las ocpiones de guardado y reinicio.
        /// </summary>
        private void deshabilitarOpciones()
        {
            this.borrarDatos();

            dgvSegregados.DataSource = null;
            dgvSegregados.Enabled = false;

            gbDatosManifiesto.Enabled = false;
            btnReiniciar.Enabled = false;
            btnGuardar.Enabled = false;
        }

        #endregion Métodos Privados

        private void cboCoordinador_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }

}
