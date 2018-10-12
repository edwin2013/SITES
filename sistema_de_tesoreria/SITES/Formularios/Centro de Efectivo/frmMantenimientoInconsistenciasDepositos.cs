//
//  @ Project : 
//  @ File Name : frmMantenimientoInconsistenciasClientes.cs
//  @ Date : 27/07/2011
//  @ Author : Erick Chavarría 
//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

using CommonObjects;
using BussinessLayer;
using LibreriaMensajes;

namespace GUILayer
{

    public partial class frmMantenimientoInconsistenciasDepositos : Form
    {

        #region Constantes

        #endregion Constantes

        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private SeguridadBL _seguridad = SeguridadBL.Instancia;
        private AtencionBL _atencion = AtencionBL.Instancia;
        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;

        private BindingList<PuntoVenta> _puntos = new BindingList<PuntoVenta>();

        private InconsistenciaDeposito _inconsistencia = null;
        private Colaborador _coordinador = null;
        private PlanillaCEF _planilla = null;

        DateTime _fecha_actual;
        private bool _supervisor = false;
        private bool _coordinador_valido = false;
        private bool _dia_valido = false;

        #endregion Atributos

        #region Constructor

        public frmMantenimientoInconsistenciasDepositos(Colaborador coordinador)
        {
            InitializeComponent();

            _coordinador = coordinador;

            cboCoordinador.Text = _coordinador.ToString();

            try
            {
                this.cargarDatos();

                dgvValores.DataSource = new BindingList<Valor>();
                dgvSobres.DataSource = new BindingList<Sobre>();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public frmMantenimientoInconsistenciasDepositos(InconsistenciaDeposito inconsistencia, Colaborador coordinador)
        {
            InitializeComponent();

            _inconsistencia = inconsistencia;
            _coordinador = coordinador;

            try
            {
                this.cargarDatos();
                
                // Mostrar los datos de la inconsistencia

                cboCamara.Text = _inconsistencia.Camara.Identificador;
                dtpFecha.Value = _inconsistencia.Fecha;

                nudDiferenciaColones.Value = _inconsistencia.Diferencia_colones;
                nudDiferenciaDolares.Value = _inconsistencia.Diferencia_dolares;
                nudDiferenciaEuros.Value = _inconsistencia.Diferencia_euros;

                dgvValores.DataSource = _inconsistencia.Valores;
                dgvSobres.DataSource = _inconsistencia.Sobres;

                BindingList<Deposito> depositos = (BindingList<Deposito>)dgvDepositos.DataSource;
                BindingList<Tula> tulas = (BindingList<Tula>)dgvTulas.DataSource;
                BindingList<Manifiesto> manifiestos = (BindingList<Manifiesto>)dgvManifiestos.DataSource;

                manifiestos.Add(_inconsistencia.Manifiesto);
                depositos.Add(_inconsistencia.Deposito);
                tulas.Add(_inconsistencia.Tula);

                if (_inconsistencia.Segregado == null)
                {
                    this.mostrarDatos(_inconsistencia.Manifiesto);
                }
                else
                {
                    this.mostrarDatos(_inconsistencia.Segregado);

                    nudBolso.Value = (short)_inconsistencia.Bolso;
                }

                // Validar si se pueden modificar los datos de la inconsistencia

                bool estado = _supervisor || (_coordinador_valido && _dia_valido);

                gbDetalle.Enabled = estado;
                gbManifiestos.Enabled = estado;
                gbTulas.Enabled = estado;
                gbDeposito.Enabled = estado;
                gbValores.Enabled = estado;
                gbSobres.Enabled = estado;
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
                // Obtener la fecha del servidor

                _fecha_actual = _coordinacion.obtenerFechaHora().Date;

                dgvTulas.AutoGenerateColumns = false;
                dgvManifiestos.AutoGenerateColumns = false;
                dgvSegregados.AutoGenerateColumns = false;
                dgvDepositos.AutoGenerateColumns = false;
                dgvValores.AutoGenerateColumns = false;
                dgvSobres.AutoGenerateColumns = false;

                // Validar si el coordinador tiene permisos de supervisor

                _supervisor = _coordinador.Puestos.Contains(Puestos.Supervisor);

                cboCoordinador.Enabled = _supervisor;
                dtpFechaManifiesto.Enabled = _supervisor;

                // Cargar las listas

                dgvDepositos.DataSource = new BindingList<Deposito>();
                dgvManifiestos.DataSource = new BindingList<Manifiesto>();
                dgvTulas.DataSource = new BindingList<Tula>();

                cboCajero.ListaMostrada = _seguridad.listarColaboradoresPorPuestoArea(Areas.CentroEfectivo, Puestos.CajeroA, Puestos.CajeroB);
                cboCoordinador.ListaMostrada = _seguridad.listarColaboradoresPorPuestoArea(Areas.CentroEfectivo, Puestos.Coordinador);
                cboDigitador.ListaMostrada = _seguridad.listarColaboradoresPorPuestoArea(Areas.CentroEfectivo, Puestos.Digitador);
                cboCliente.ListaMostrada = _mantenimiento.listarClientes(string.Empty);
                cboCamara.ListaMostrada = _mantenimiento.listarCamarasPorArea(Areas.CentroEfectivo);

                foreach (Cliente cliente in cboCliente.ListaMostrada)
                {

                    foreach (PuntoVenta punto in cliente.Puntos_venta)
                        _puntos.Add(punto);

                }

                // Establecer el separador de decimales

                CultureInfo anterior = System.Threading.Thread.CurrentThread.CurrentCulture;
                CultureInfo nueva = (CultureInfo)anterior.Clone();

                nueva.NumberFormat.NumberDecimalSeparator = ".";
                nueva.NumberFormat.NumberGroupSeparator = ",";
                System.Threading.Thread.CurrentThread.CurrentCulture = nueva;

                CultureInfo cultura = System.Threading.Thread.CurrentThread.CurrentCulture;

                // Validar si el colaborador puede modificar el coordinador del manifiesto

                cboCoordinador.Enabled = _coordinador.Puestos.Contains(Puestos.Supervisor);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
            
        }

        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Carga del formulario.
        /// </summary>
        private void frmMantenimientoInconsistenciasClientesDepositos_Load(object sender, EventArgs e)
        {
            foreach (TabPage page in tcDatos.TabPages) page.Show();

            if (_inconsistencia != null)
            {

                if (_inconsistencia.Segregado != null)
                {
                    ManifiestoCEF manifiesto = _inconsistencia.Manifiesto;
                    BindingList<SegregadoCEF> segregados = manifiesto.Segregados;
                    SegregadoCEF segregado = _inconsistencia.Segregado;

                    dgvSegregados.Rows[segregados.IndexOf(segregado)].Selected = true;
                }

            }

        }

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
            
            if (dgvManifiestos.SelectedRows.Count == 0 || dgvTulas.SelectedRows.Count == 0 || 
                dgvDepositos.SelectedRows.Count == 0 || cboCajero.SelectedItem == null ||
                cboDigitador.SelectedItem == null || cboPuntoVenta.SelectedItem == null ||
                cboCamara.SelectedItem == null)
            {
                Excepcion.mostrarMensaje("ErrorInconsistenciaDatosRegistro");
                return;
            }

            try
            {
                frmAdministracionInconsistenciasCEF padre = (frmAdministracionInconsistenciasCEF)this.Owner;

                PuntoVenta punto_venta = (PuntoVenta)cboPuntoVenta.SelectedItem;

                SegregadoCEF segregado = null;
                ManifiestoCEF manifiesto_cef = null;

                DateTime fecha = dtpFecha.Value;
                Camara camara = (Camara)cboCamara.SelectedItem;
                Deposito deposito = (Deposito)dgvDepositos.SelectedRows[0].DataBoundItem;
                Tula tula = (Tula)dgvTulas.SelectedRows[0].DataBoundItem;

                decimal diferencia_colones = nudDiferenciaColones.Value;
                decimal diferencia_dolares = nudDiferenciaDolares.Value;
                decimal diferencia_euros = nudDiferenciaEuros.Value;
                short bolso = (short)nudBolso.Value;
                string comentario = txtComentario.Text;

                Colaborador cajero = (Colaborador)cboCajero.SelectedItem;
                Colaborador digitador = (Colaborador)cboDigitador.SelectedItem;
                Colaborador coordinador = (Colaborador)cboCoordinador.SelectedItem;
                DateTime fecha_planilla = dtpFechaManifiesto.Value;

                if (_planilla is SegregadoCEF)
                {
                    segregado = (SegregadoCEF)_planilla;
                    manifiesto_cef = (ManifiestoCEF)dgvManifiestos.SelectedRows[0].DataBoundItem;

                    segregado.Cajero = cajero;
                    segregado.Digitador = digitador;
                    segregado.Coordinador = coordinador;
                    segregado.Punto_venta = punto_venta;
                    
                    manifiesto_cef.Fecha_procesamiento = fecha_planilla;
                }
                else
                {
                    manifiesto_cef = (ManifiestoCEF)_planilla;

                    manifiesto_cef.Cajero = cajero;
                    manifiesto_cef.Digitador = digitador;
                    manifiesto_cef.Coordinador = coordinador;
                    manifiesto_cef.Punto_venta = punto_venta;
                    manifiesto_cef.Fecha_procesamiento = fecha_planilla;
                }

                BindingList<Valor> valores = (BindingList<Valor>)dgvValores.DataSource;
                BindingList<Sobre> sobres = (BindingList<Sobre>)dgvSobres.DataSource;

                // Verificar si la inconsistencia es nueva

                if (_inconsistencia == null)
                {
                    // Agregar la inconsistencia

                    if (Mensaje.mostrarMensajeConfirmacion("MensajeInconsistenciaRegistro") == DialogResult.Yes)
                    {
                        InconsistenciaDeposito nueva =
                            new InconsistenciaDeposito(manifiesto_cef, segregado, bolso, tula, deposito, camara,
                                                       fecha, diferencia_colones, diferencia_dolares, comentario, diferencia_euros);

                        foreach (Valor valor in valores)
                            nueva.agregarValor(valor);

                        foreach (Sobre sobre in sobres)
                            nueva.agregarSobre(sobre);

                        _coordinacion.agregarInconsistenciaDeposito(ref nueva);

                        padre.agregarInconsistenciaClienteDeposito(nueva);
                        Mensaje.mostrarMensaje("MensajeInconsistenciaConfirmacionRegistro");
                        this.Close();
                    }

                }
                else
                {
                    InconsistenciaDeposito copia =
                        new InconsistenciaDeposito(_inconsistencia.Id, manifiesto_cef, segregado, bolso, tula, deposito, camara,
                                                   fecha, diferencia_colones, diferencia_dolares, comentario, diferencia_euros);

                    foreach (Valor sobre in valores)
                        copia.agregarValor(sobre);

                    foreach (Sobre sobre in sobres)
                        copia.agregarSobre(sobre);

                    _coordinacion.actualizarInconsistenciaDeposito(copia);

                    //Actualizar la inconsistencia

                    _inconsistencia.Manifiesto = manifiesto_cef;
                    _inconsistencia.Segregado = segregado;
                    _inconsistencia.Camara = camara;
                    _inconsistencia.Fecha = fecha;
                    _inconsistencia.Comentario = comentario;
                    _inconsistencia.Deposito = deposito;
                    _inconsistencia.Tula = tula;

                    _inconsistencia.Diferencia_colones = diferencia_colones;
                    _inconsistencia.Diferencia_dolares = diferencia_dolares;

                    _inconsistencia.Valores = copia.Valores;
                    _inconsistencia.Sobres = copia.Sobres;

                    padre.actualizarListaClientesDepositos();
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
        /// Clic en el botón de buscar deposito.
        /// </summary>
        private void btnBuscarDeposito_Click(object sender, EventArgs e)
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
        /// Clic en el botón de agregar valor.
        /// </summary>
        private void btnAgregarValor_Click(object sender, EventArgs e)
        {
            frmMantenimientoValores formulario = new frmMantenimientoValores();

            formulario.ShowDialog(this);
        }

        /// <summary>
        /// Clic en el botón de quitar valor.
        /// </summary>
        private void btnQuitarValor_Click(object sender, EventArgs e)
        {
            dgvValores.Rows.Remove(dgvValores.SelectedRows[0]);
        }

        /// <summary>
        /// Clic en el botón de agregar sobre.
        /// </summary>
        private void btnAgregarSobre_Click(object sender, EventArgs e)
        {
            frmMantenimientoSobres formulario = new frmMantenimientoSobres();

            formulario.ShowDialog(this);
        }

        /// <summary>
        /// Clic en el botón de quitar sobre.
        /// </summary>
        private void btnQuitarSobre_Click(object sender, EventArgs e)
        {
            dgvSobres.Rows.Remove(dgvSobres.SelectedRows[0]);
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

                this.mostrarTulasSegregados(manifiesto);

                if (manifiesto.Segregados.Count > 0) return;

                this.mostrarDatos(manifiesto);
            }
            else
            {
                this.deshabilitarOpciones();
            }

        }

        /// <summary>
        /// Selección de otro segregado.
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
        /// Selección de otro deposito.
        /// </summary>
        private void dgvDepositos_SelectionChanged(object sender, EventArgs e)
        {
            btnModificarDeposito.Enabled = dgvDepositos.SelectedRows.Count > 0;
        }

        /// <summary>
        /// Se selecciona otro valor.
        /// </summary>
        private void dgvValores_SelectionChanged(object sender, EventArgs e)
        {
            btnQuitarValor.Enabled = dgvValores.SelectedRows.Count > 0;
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

        /// <summary>
        /// Formato de una celda de la lista de valores.
        /// </summary>
        private void dgvValores_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if (e.ColumnIndex == Tipo.Index)
            {
                Valor valor = (Valor)dgvValores.Rows[e.RowIndex].DataBoundItem;

                String tipo = string.Empty;

                switch(valor.Tipo)
                {
                    case TipoValor.BilleteFalso:
                        tipo = "Billete Falso";
                        break;
                    case TipoValor.ChequeInvalido:
                        tipo = "Cheque Inválido";
                        break;
                    case TipoValor.OtroValor:
                        tipo = "Otro Valor";
                        break;
                }

                dgvValores[Tipo.Index, e.RowIndex].Value = tipo;
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
        /// Se escribe dentro del NumericUpDown del monto real.
        /// </summary>
        private void nudMontoRealDeposito_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.') e.KeyChar = ',';
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
        }

        /// <summary>
        /// Mostrar los datos de un manifiesto o un manifiesto segregado.
        /// </summary>
        private void mostrarDatos(PlanillaCEF planilla)
        {
            _planilla = planilla;

            // Mostrar los datos

            bool estado = true;

            if (_planilla.Coordinador != null)
            {
                _coordinador_valido = _planilla.Coordinador.Equals(_coordinador);
                _dia_valido = _planilla.Fecha_procesamiento.Date == _fecha_actual.Date;

                estado = _supervisor || (_coordinador_valido && _dia_valido);

                cboCajero.Text = _planilla.Cajero.ToString();
                cboDigitador.Text = _planilla.Digitador.ToString();
                cboCoordinador.Text = _planilla.Coordinador.ToString();
                dtpFechaManifiesto.Value = (DateTime)_planilla.Fecha_procesamiento;
            }

            // Validar si el coordinador puede modificar el manifiesto

            pnlDetallesManifiesto.Enabled = estado;
            btnGuardar.Enabled = estado;
            nudBolso.Enabled = _planilla is SegregadoCEF;

            if (_planilla.Punto_venta != null)
            {
                cboCliente.Text = _planilla.Punto_venta.Cliente.Nombre;
                cboPuntoVenta.Text = _planilla.Punto_venta.Nombre;
            }
            else
            {
                cboCliente.Text = string.Empty;
                cboPuntoVenta.Text = string.Empty;
            }

        }

        /// <summary>
        /// Mostrar las tulas y segregados ligados a un manifiesto.
        /// </summary>
        private void mostrarTulasSegregados(ManifiestoCEF manifiesto)
        {

            try
            {
                dgvSegregados.DataSource = manifiesto.Segregados;
                dgvSegregados.Enabled = manifiesto.Segregados.Count > 0;

                dgvTulas.DataSource = _atencion.listarTulasPorManifiesto(manifiesto);
                dgvTulas.Enabled = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Deshabilitar las ocpiones de guardado y modificación.
        /// </summary>
        private void deshabilitarOpciones()
        {
            this.borrarDatos();

            dgvSegregados.DataSource = null;
            dgvSegregados.Enabled = false;

            dgvTulas.DataSource = null;
            dgvTulas.Enabled = true;

            nudBolso.Enabled = false;
            pnlDetallesManifiesto.Enabled = false;
            btnGuardar.Enabled = false;
        }

        #endregion Métodos Privados

        #region Métodos Públicos

        /// <summary>
        /// Agregar un valor a la lista de valores.
        /// </summary>
        public void agregarValor(Valor valor)
        {
            BindingList<Valor> valores = (BindingList<Valor>)dgvValores.DataSource;

            valores.Add(valor);
            dgvValores.AutoResizeColumns();
        }

        /// <summary>
        /// Agregar un sobre a la lista de sobres.
        /// </summary>
        public void agregarSobre(Sobre sobre)
        {
            BindingList<Sobre> sobres = (BindingList<Sobre>)dgvSobres.DataSource;

            sobres.Add(sobre);
            dgvSobres.AutoResizeColumns();
        }

        #endregion Métodos Públicos

    }

}
