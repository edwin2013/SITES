//
//  @ Project : 
//  @ File Name : frmRegistroDenominacionesCajeros.cs
//  @ Date : 24/10/2011
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

    public partial class frmRegistroDenominacionesCajeros : Form
    {

        #region Atributos

        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;
        private SeguridadBL _seguridad = SeguridadBL.Instancia;
        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;

        private RegistroDenominacionesCierre _registro = null;
        private Colaborador _coordinador = null;

        private decimal _colones_cincuenta_mil = 0;
        private decimal _colones_veinte_mil = 0;
        private decimal _colones_diez_mil = 0;
        private decimal _colones_cinco_mil = 0;
        private decimal _colones_dos_mil = 0;
        private decimal _colones_mil = 0;
        private decimal _colones_quinientos = 0;
        private decimal _colones_cien = 0;
        private decimal _colones_cincuenta = 0;
        private decimal _colones_veinticinco = 0;
        private decimal _colones_diez = 0;
        private decimal _colones_cinco = 0;

        private decimal _dolares_cien = 0;
        private decimal _dolares_cincuenta = 0;
        private decimal _dolares_veinte = 0;
        private decimal _dolares_diez = 0;
        private decimal _dolares_cinco = 0;
        private decimal _dolares_uno = 0;

        private DateTime _fecha;

        private bool _seleccion_fecha = false;
        private bool _coordinador_valido = false;
        private bool _nuevo = false;

        #endregion Atributos

        #region Constructor

        public frmRegistroDenominacionesCajeros(Colaborador coordinador)
        {
            InitializeComponent();

            _coordinador = coordinador;

            try
            {
                cboCajero.ListaMostrada = _seguridad.listarColaboradoresPorPuestoArea(Areas.CentroEfectivo, Puestos.CajeroA, Puestos.CajeroB);
                cboCoordinador.ListaMostrada = _seguridad.listarColaboradoresPorPuestoArea(Areas.CentroEfectivo,Puestos.Coordinador);
                cboTransportadora.ListaMostrada = _mantenimiento.listarEmpresasTransporte();
                cboCliente.ListaMostrada = _mantenimiento.listarClientes(string.Empty);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            // Crear las filas de la tabla

            this.crearTabla();

            // Dar fomato a las filas

            this.formatoCeldaSoloLectura(13, 21);
            this.formatoCeldaSeparador(0, 14);

            // Validar si el usuario puede cambiar la fecha

            if (coordinador.Puestos.Contains(Puestos.Supervisor) ||
                coordinador.Area == Areas.Boveda)
            {
                dtpFecha.Enabled = true;
                btnEliminar.Visible = true;
                cboCoordinador.Enabled = true;
            }

        }

        /// <summary>
        /// Crear las filas del DataGridView.
        /// </summary>
        private void crearTabla()
        {
            dgvMontos.Rows.Add("Colones", string.Empty);
            dgvMontos.Rows.Add("50.000", 0);
            dgvMontos.Rows.Add("20.000", 0);
            dgvMontos.Rows.Add("10.000", 0);
            dgvMontos.Rows.Add("5.000", 0);
            dgvMontos.Rows.Add("2.000", 0);
            dgvMontos.Rows.Add("1.000", 0);
            dgvMontos.Rows.Add("500", 0);
            dgvMontos.Rows.Add("100", 0);
            dgvMontos.Rows.Add("50", 0);
            dgvMontos.Rows.Add("25", 0);
            dgvMontos.Rows.Add("10", 0);
            dgvMontos.Rows.Add("5", 0);
            dgvMontos.Rows.Add("Total", 0);
            dgvMontos.Rows.Add("Dólares", string.Empty);
            dgvMontos.Rows.Add("100", 0);
            dgvMontos.Rows.Add("50", 0);
            dgvMontos.Rows.Add("20", 0);
            dgvMontos.Rows.Add("10", 0);
            dgvMontos.Rows.Add("5", 0);
            dgvMontos.Rows.Add("1", 0);
            dgvMontos.Rows.Add("Total", 0);
        }
        
        /// <summary>
        /// Dar formato de solo lectura a las filas que lo requieran.
        /// </summary>
        private void formatoCeldaSoloLectura(params int[] filas)
        {

            foreach (int fila in filas)
            {
                dgvMontos.Rows[fila].ReadOnly = true;
                dgvMontos.Rows[fila].DefaultCellStyle.BackColor = Denominacion.DefaultCellStyle.BackColor;
                dgvMontos.Rows[fila].DefaultCellStyle.SelectionBackColor = Denominacion.DefaultCellStyle.BackColor;
            }

        }

        /// <summary>
        /// Dar formato a las celdas que son separadoras.
        /// </summary>
        private void formatoCeldaSeparador(params int[] filas)
        {

            foreach (int fila in filas)
            {
                dgvMontos.Rows[fila].ReadOnly = true;
                dgvMontos.Rows[fila].DefaultCellStyle.BackColor = dgvMontos.GridColor;
                dgvMontos.Rows[fila].DefaultCellStyle.SelectionBackColor = dgvMontos.GridColor;
            }

        }

        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de eliminar.
        /// </summary>
        private void btnEliminar_Click(object sender, EventArgs e)
        {

            try
            {

                if (Mensaje.mostrarMensajeConfirmacion("MensajeRegistroDenominacionesCierreEliminacion") == DialogResult.Yes)
                {
                    _coordinacion.eliminarRegistroDenominacionesCierre(_registro);

                    Mensaje.mostrarMensaje("MensajeRegistroDenominacionesCierreConfirmacionEliminacion");

                    btnEliminar.Enabled = false;

                    // Reiniciar el cierre

                    _fecha = dtpFecha.Value;

                    Colaborador cajero = (Colaborador)cboCajero.SelectedItem;
                    RegistroDenominacionesCierre nuevo = new RegistroDenominacionesCierre(cajero, _coordinador, _fecha);

                    _registro = nuevo;
                    _nuevo = true;

                    this.mostrarDatos();
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
            _registro.Colones_cincuenta_mil = _colones_cincuenta_mil;
            _registro.Colones_veinte_mil = _colones_veinte_mil;
            _registro.Colones_diez_mil = _colones_diez_mil;
            _registro.Colones_cinco_mil = _colones_cinco_mil;
            _registro.Colones_dos_mil = _colones_dos_mil;
            _registro.Colones_mil = _colones_mil;
            _registro.Colones_quinientos = _colones_quinientos;
            _registro.Colones_cien = _colones_cien;
            _registro.Colones_cincuenta = _colones_cincuenta;
            _registro.Colones_veinticinco = _colones_veinticinco;
            _registro.Colones_diez = _colones_diez;
            _registro.Colones_cinco = _colones_cinco;

            _registro.Dolares_cien = _dolares_cien;
            _registro.Dolares_cincuenta = _dolares_cincuenta;
            _registro.Dolares_veinte = _dolares_veinte;
            _registro.Dolares_diez = _dolares_diez;
            _registro.Dolares_cinco = _dolares_cinco;
            _registro.Dolares_uno = _dolares_uno;

            Cliente cliente = null;
            EmpresaTransporte empresa = null;

            if (cboCliente.SelectedIndex == 0 && cboCliente.SelectedItem == null)
                cliente = null;
            else
                cliente = (Cliente)cboCliente.SelectedItem;


            if (cboTransportadora.SelectedIndex == 0 && cboTransportadora.SelectedItem == null)
                empresa = null;
            else
                empresa = (EmpresaTransporte)cboTransportadora.SelectedItem;

             

            bool externo = chkProcesamientoExterno.Checked;

            _registro.Cliente = cliente;
            _registro.Transportadora = empresa;
            _registro.ProcesamientoExterno = externo; 

            try
            {
                Colaborador coordinador = (Colaborador)cboCoordinador.SelectedItem;

                // Verificar si los montos del cierre se registran por primera vez

                _registro.Coordinador = coordinador;

                if (_nuevo)
                {
                    // Registrar los montos del cierre

                    _coordinacion.agregarRegistroDenominacionesCierre(ref _registro);
                    _coordinacion.agregarCorteRegistroDenominacionesCierre(_registro);

                    _nuevo = false;

                    btnEliminar.Enabled = _coordinador_valido;

                    Mensaje.mostrarMensaje("MensajeRegistroDenominacionesCierreConfirmacionRegistro");
                }
                else
                {
                    // Actualizar los montos del cierre

                    _coordinacion.actualizarRegistroDenominacionesCierre(_registro);

                    Mensaje.mostrarMensaje("MensajeRegistroDenominacionesCierreConfirmacionActualizacion");
                }

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de generar un corte del cierre.
        /// </summary>
        private void btnCorte_Click(object sender, EventArgs e)
        {

            try
            {
                _registro.Colones_cincuenta_mil = _colones_cincuenta_mil;
                _registro.Colones_veinte_mil = _colones_veinte_mil;
                _registro.Colones_diez_mil = _colones_diez_mil;
                _registro.Colones_cinco_mil = _colones_cinco_mil;
                _registro.Colones_dos_mil = _colones_dos_mil;
                _registro.Colones_mil = _colones_mil;
                _registro.Colones_quinientos = _colones_quinientos;
                _registro.Colones_cien = _colones_cien;
                _registro.Colones_cincuenta = _colones_cincuenta;
                _registro.Colones_veinticinco = _colones_veinticinco;
                _registro.Colones_diez = _colones_diez;
                _registro.Colones_cinco = _colones_cinco;

                _registro.Dolares_cien = _dolares_cien;
                _registro.Dolares_cincuenta = _dolares_cincuenta;
                _registro.Dolares_veinte = _dolares_veinte;
                _registro.Dolares_diez = _dolares_diez;
                _registro.Dolares_cinco = _dolares_cinco;
                _registro.Dolares_uno = _dolares_uno;

                _coordinacion.agregarCorteRegistroDenominacionesCierre(_registro);

                Mensaje.mostrarMensaje("MensajeCierreDenominacionesCorteConfirmacionRegistro");
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
        /// Se selecciona otro cajero.
        /// </summary>
        private void cboCajero_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cargarDatos();
        }

        /// <summary>
        /// Se selecciona otra fecha para el cierre.
        /// </summary>
        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            if (_seleccion_fecha) return;

            this.cargarDatos();
        }

        /// <summary>
        /// Se muestra el dropdownlist para seleccionar una fecha para el cierre.
        /// </summary>
        private void dtpFecha_DropDown(object sender, EventArgs e)
        {
            _seleccion_fecha = true;
        }

        /// <summary>
        /// Se oculta el dropdownlist al seleccionar una fecha para el cierre.
        /// </summary>
        private void dtpFecha_CloseUp(object sender, EventArgs e)
        {
            _seleccion_fecha = false;

            this.cargarDatos();
        }

        /// <summary>
        /// Se cambia un valor en el datagrid.
        /// </summary>
        private void dgvMontos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            if (dgvMontos.RowCount > 0)
            {
                DataGridViewCell celda = dgvMontos[e.ColumnIndex, e.RowIndex];

                if (celda.ReadOnly) return;

                _colones_cincuenta_mil = Convert.ToDecimal(dgvMontos[Monto.Index, 1].Value);
                _colones_veinte_mil = Convert.ToDecimal(dgvMontos[Monto.Index, 2].Value);
                _colones_diez_mil = Convert.ToDecimal(dgvMontos[Monto.Index, 3].Value);
                _colones_cinco_mil = Convert.ToDecimal(dgvMontos[Monto.Index, 4].Value);
                _colones_dos_mil = Convert.ToDecimal(dgvMontos[Monto.Index, 5].Value);
                _colones_mil = Convert.ToDecimal(dgvMontos[Monto.Index, 6].Value);
                _colones_quinientos = Convert.ToDecimal(dgvMontos[Monto.Index, 7].Value);
                _colones_cien = Convert.ToDecimal(dgvMontos[Monto.Index, 8].Value);
                _colones_cincuenta = Convert.ToDecimal(dgvMontos[Monto.Index, 9].Value);
                _colones_veinticinco = Convert.ToDecimal(dgvMontos[Monto.Index, 10].Value);
                _colones_diez = Convert.ToDecimal(dgvMontos[Monto.Index, 11].Value);
                _colones_cinco = Convert.ToDecimal(dgvMontos[Monto.Index, 12].Value);

                _dolares_cien = Convert.ToDecimal(dgvMontos[Monto.Index, 15].Value);
                _dolares_cincuenta = Convert.ToDecimal(dgvMontos[Monto.Index, 16].Value);
                _dolares_veinte = Convert.ToDecimal(dgvMontos[Monto.Index, 17].Value);
                _dolares_diez = Convert.ToDecimal(dgvMontos[Monto.Index, 18].Value);
                _dolares_cinco = Convert.ToDecimal(dgvMontos[Monto.Index, 19].Value);
                _dolares_uno = Convert.ToDecimal(dgvMontos[Monto.Index, 20].Value);

                // Calculo de los montos totales

                decimal total_colones = _colones_cincuenta_mil + _colones_veinte_mil +
                                        _colones_diez_mil + _colones_cinco_mil +
                                        _colones_dos_mil + _colones_mil +
                                        _colones_quinientos + _colones_cien +
                                        _colones_cincuenta + _colones_veinticinco +
                                        _colones_diez + _colones_cinco;


                decimal total_dolares = _dolares_cien + _dolares_cincuenta +
                                        _dolares_veinte + _dolares_diez +
                                        _dolares_cinco + _dolares_uno;

                dgvMontos[Monto.Index, 13].Value = total_colones;
                dgvMontos[Monto.Index, 21].Value = total_dolares;
            }

        }

        /// <summary>
        /// Validar las celdas de montos.
        /// </summary>
        private void dgvMontos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == Denominacion.Index) return;

            DataGridViewCell celda = dgvMontos[e.ColumnIndex, e.RowIndex];

            decimal valor = 0;

            if (!decimal.TryParse(celda.Value.ToString(), out valor))
                celda.Value = valor;

        }

        #endregion Eventos

        #region Métodos Privados

        /// <summary>
        /// Obtener los datos del cierre del colaborador.
        /// </summary>
        private void cargarDatos()
        {

            try
            {
                this.borrarDatos();

                if (cboCajero.SelectedItem != null)
                {
                    Colaborador cajero = (Colaborador)cboCajero.SelectedItem;

                    _fecha = dtpFecha.Value;
                    _registro = new RegistroDenominacionesCierre(cajero, _coordinador, _fecha);

                    _coordinacion.obtenerDatosRegistroDenominacionesCierre(ref _registro);

                    _nuevo = _registro.Id == 0;

                    cboCoordinador.Text = _registro.Coordinador.ToString();

                    _coordinador_valido = _registro.Coordinador.Equals(_coordinador) || _coordinador.Puestos.Contains(Puestos.Supervisor);

                    if (_registro.Transportadora != null)
                        cboTransportadora.Text = _registro.Transportadora.ToString();

                    if (_registro.Cliente != null)
                    {
                        cboCliente.Text = _registro.Cliente.ToString();
                        chkProcesamientoExterno.Checked = true; 
                    }

                    this.mostrarDatos();
                    this.validarOpciones();
                }
                else
                {
                    dgvMontos.Enabled = false;
                    btnGuardar.Enabled = false;
                    btnEliminar.Enabled = false;
                    btnCorte.Enabled = false;
                }

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Mostrar los datos de un registro por denominación.
        /// </summary>
        private void mostrarDatos()
        {
            dgvMontos[Monto.Index, 1].Value = _registro.Colones_cincuenta_mil;
            dgvMontos[Monto.Index, 2].Value = _registro.Colones_veinte_mil;
            dgvMontos[Monto.Index, 3].Value = _registro.Colones_diez_mil;
            dgvMontos[Monto.Index, 4].Value = _registro.Colones_cinco_mil;
            dgvMontos[Monto.Index, 5].Value = _registro.Colones_dos_mil;
            dgvMontos[Monto.Index, 6].Value = _registro.Colones_mil;
            dgvMontos[Monto.Index, 7].Value = _registro.Colones_quinientos;
            dgvMontos[Monto.Index, 8].Value = _registro.Colones_cien;
            dgvMontos[Monto.Index, 9].Value = _registro.Colones_cincuenta;
            dgvMontos[Monto.Index, 10].Value = _registro.Colones_veinticinco;
            dgvMontos[Monto.Index, 11].Value = _registro.Colones_diez;
            dgvMontos[Monto.Index, 12].Value = _registro.Colones_cinco;

            dgvMontos[Monto.Index, 15].Value = _registro.Dolares_cien;
            dgvMontos[Monto.Index, 16].Value = _registro.Dolares_cincuenta;
            dgvMontos[Monto.Index, 17].Value = _registro.Dolares_veinte;
            dgvMontos[Monto.Index, 18].Value = _registro.Dolares_diez;
            dgvMontos[Monto.Index, 19].Value = _registro.Dolares_cinco;
            dgvMontos[Monto.Index, 20].Value = _registro.Dolares_uno;
        }

        /// <summary>
        /// Habilitar o desabilitar la edición de los datos.
        /// </summary>
        private void validarOpciones()
        {
            dgvMontos.Enabled = _coordinador_valido;
            btnGuardar.Enabled = _coordinador_valido && cboCoordinador.SelectedItem != null;

            if (_coordinador_valido && !_nuevo)
            {
                btnEliminar.Enabled = true;
                btnCorte.Enabled = true;
            }
            else
            {
                btnEliminar.Enabled = false;
                btnCorte.Enabled = false;
            }

        }

        /// <summary>
        /// Borrar los datos del DataGrid.
        /// </summary>
        private void borrarDatos()
        {
            dgvMontos[Monto.Index, 1].Value = 0;
            dgvMontos[Monto.Index, 2].Value = 0;
            dgvMontos[Monto.Index, 3].Value = 0;
            dgvMontos[Monto.Index, 4].Value = 0;
            dgvMontos[Monto.Index, 5].Value = 0;
            dgvMontos[Monto.Index, 6].Value = 0;
            dgvMontos[Monto.Index, 7].Value = 0;
            dgvMontos[Monto.Index, 8].Value = 0;
            dgvMontos[Monto.Index, 9].Value = 0;
            dgvMontos[Monto.Index, 10].Value = 0;
            dgvMontos[Monto.Index, 11].Value = 0;
            dgvMontos[Monto.Index, 12].Value = 0;

            dgvMontos[Monto.Index, 15].Value = 0;
            dgvMontos[Monto.Index, 16].Value = 0;
            dgvMontos[Monto.Index, 17].Value = 0;
            dgvMontos[Monto.Index, 18].Value = 0;
            dgvMontos[Monto.Index, 19].Value = 0;
            dgvMontos[Monto.Index, 20].Value = 0;
        }

        #endregion Métodos Privados

   

    }

}
