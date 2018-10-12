//
//  @ Project : 
//  @ File Name : frmMantenimientoClientes.cs
//  @ Date : 01/06/2011
//  @ Author : Erick Chavarría 
//

using System;
using System.ComponentModel;
using System.Windows.Forms;

using CommonObjects;
using BussinessLayer;
using LibreriaMensajes;
using CommonObjects.Clases;
using LibreriaReportesOffice;

namespace GUILayer
{

    public partial class frmMantenimientoClientes : Form
    {

        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private string _archivo = string.Empty;
        private Cliente _cliente = null;
        private BindingList<PuntoVenta> _puntos = new BindingList<PuntoVenta>();
        private BindingList<TarifaPuntoVentaTransportadora> _tarifas = new BindingList<TarifaPuntoVentaTransportadora>();
        private BindingList<Cuenta> _cuentas = new BindingList<Cuenta>();
        private BindingList<Denominacion> _denominaciones = new BindingList<Denominacion>();
        private BindingList<Denominacion> _denominaciones_ensobrado = new BindingList<Denominacion>();
        private BindingList<Denominacion> _denominaciones_chorreado = new BindingList<Denominacion>();

        private PuntoVenta puntito = null;



        #endregion Atributos

        #region Constructor

        public frmMantenimientoClientes()
        {
            InitializeComponent();

            //cboEmpaque.SelectedIndex = (byte)Empaques.Ninguno;

            cboContratoTransporte.SelectedIndex = (byte)Contratos_Transporte.Ninguno;
            dgvTarifasTransportadora.AutoGenerateColumns = false;

            this.formatoVentana();

            
            dgvNombresJuridicos.DataSource = new BindingList<NombreJuridico>();
            dgvPuntosVenta.DataSource = new BindingList<PuntoVenta>();
            dgvTelefonos.DataSource = new BindingList<Telefono>();
            dgvCorreos.DataSource = new BindingList<Correo>();
            dgvTarifasTransportadora.DataSource = new BindingList<TarifaPuntoVentaTransportadora>();
            dgvCuentasPuntosVenta.DataSource = new BindingList<Cuenta>();

            
           
        }

        public frmMantenimientoClientes(Cliente cliente)
        {
            InitializeComponent();

            _cliente = cliente;

            txtNombre.Text = _cliente.Nombre;
            txtContacto.Text = _cliente.Contacto;
            chkSolicitudRemesas.Checked = _cliente.Solicitud_remesas;
            cboContratoTransporte.SelectedIndex = (byte)_cliente.Contrato_transporte;
            cboTransportadora.ListaMostrada = _mantenimiento.listarEmpresasTransporte();
            cboPuntoVentaTransportadora.ListaMostrada = cliente.Puntos_venta;
            cboPuntoVentasCuentas.ListaMostrada = cliente.Puntos_venta;
            dgvTarifasTransportadora.AutoGenerateColumns = false;
            cboPuntoVentaComision.ListaMostrada = _cliente.Puntos_venta;
            this.formatoVentana();

            dgvNombresJuridicos.DataSource = _cliente.Nombres_juridicos;
            dgvPuntosVenta.DataSource = _cliente.Puntos_venta;
            dgvTelefonos.DataSource = _cliente.Telefonos;
            dgvCorreos.DataSource = _cliente.Correos;
            dgvTarifasTransportadora.DataSource = _cliente.Tarifas_Transportadoras;
            dgvDenominacionesChorreado.DataSource = new BindingList<Denominacion>();
            dgvDenominacionesEnsobrado.DataSource = new BindingList<Denominacion>();
    


            cboPuntodeVenta.ListaMostrada = cliente.Puntos_venta;
        }

        /// <summary>
        /// Dar formato a ciertas opciones de la ventana.
        /// </summary>
        private void formatoVentana()
        {
            dgvNombresJuridicos.AutoGenerateColumns = false;
            dgvCuentas.AutoGenerateColumns = false;
            dgvPuntosVenta.AutoGenerateColumns = false;
            dgvTelefonos.AutoGenerateColumns = false;
            dgvCorreos.AutoGenerateColumns = false;
            dgvCuentasPuntosVenta.AutoGenerateColumns = false;
            dgvDenominacion.AutoGenerateColumns = false;
            dgvDenominacionesEnsobrado.AutoGenerateColumns = false;
            dgvDenominacionesChorreado.AutoGenerateColumns = false;
            //cboMonedaComision.SelectedIndex = (byte)Monedas.Colones;
            cboMonedaCuentaPuntoVenta.SelectedIndex = (byte)Monedas.Colones;
        }

        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de guardar.
        /// </summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Verificar que se hayan seleccionado los datos

            if (txtNombre.Text.Equals(string.Empty))
            {
                Excepcion.mostrarMensaje("ErrorClienteDatosRegistro");
                return;
            }

            try
            {
                frmAdministracionClientes padre = (frmAdministracionClientes)this.Owner;

                string nombre = txtNombre.Text;
                string contacto = txtContacto.Text;
                bool solicitud_remesas = chkSolicitudRemesas.Checked;
                Contratos_Transporte contrato_transporte = (Contratos_Transporte)cboContratoTransporte.SelectedIndex;

                BindingList<NombreJuridico> nombres = (BindingList<NombreJuridico>)dgvNombresJuridicos.DataSource;
                BindingList<PuntoVenta> puntos_venta = (BindingList<PuntoVenta>)dgvPuntosVenta.DataSource;
                BindingList<Telefono> telefonos = (BindingList<Telefono>)dgvTelefonos.DataSource;
                BindingList<Correo> correos = (BindingList<Correo>)dgvCorreos.DataSource;

                BindingList<TarifaPuntoVentaTransportadora> tarifas = (BindingList<TarifaPuntoVentaTransportadora>)dgvTarifasTransportadora.DataSource;
               
                BindingList<Cuenta> cuentaspuntoventa = (BindingList<Cuenta>)dgvCuentasPuntosVenta.DataSource;
                //BindingList<Comision> comisiones = (BindingList<Comision>)dgvComisiones.DataSource;
                PuntoVenta p = new PuntoVenta();
                BindingList<PuntoVenta> puntos_cuenta = (BindingList<PuntoVenta>)cboPuntoVentasCuentas.ListaMostrada;
                p.Cuentas = cuentaspuntoventa;

                // Si el cliente es nuevo

                if (_cliente == null)
                {
                    // Agregar el cliente

                    if (Mensaje.mostrarMensajeConfirmacion("MensajeClienteRegistro") == DialogResult.Yes)
                    {
                        Cliente nuevo = new Cliente(nombre, contrato_transporte, solicitud_remesas, contacto);

                        foreach (NombreJuridico nombre_juridico in nombres)
                            nuevo.agregarNombreJuridico(nombre_juridico);

                        foreach (Telefono telefono in telefonos)
                            nuevo.agregarTelefono(telefono);

                        foreach (Correo correo in correos)
                            nuevo.agregarCorreo(correo);

                        foreach (PuntoVenta punto_venta in puntos_venta)
                            nuevo.agregarPuntoVenta(punto_venta);

                        //foreach (Comision comision in comisiones)
                        //    nuevo.agregarComision(comision);

                        //foreach (TarifaPuntoVentaTransportadora tar in tarifas)
                        //    nuevo.agregarTarifaTransportadora(tar);

                        _mantenimiento.agregarCliente(ref nuevo);

                        padre.agregarCliente(nuevo);

                        Mensaje.mostrarMensaje("MensajeClienteConfirmacionRegistro");
                        this.Close();
                    }

                }
                else
                {
                    Cliente copia = new Cliente(_cliente.Id, nombre, contrato_transporte, solicitud_remesas, contacto);

                    foreach (NombreJuridico nombre_juridico in nombres)
                        copia.agregarNombreJuridico(nombre_juridico);

                    foreach (Telefono telefono in telefonos)
                        copia.agregarTelefono(telefono);

                    foreach (Correo correo in correos)
                        copia.agregarCorreo(correo);

                    foreach (PuntoVenta punto_venta in puntos_venta)
                        copia.agregarPuntoVenta(punto_venta);

                    copia.puntos_cuentas = puntos_cuenta;

                    foreach (PuntoVenta punto_venta in puntos_venta)
                    { 
                        foreach (TarifaPuntoVentaTransportadora tar in punto_venta.Tarifas)
                        copia.agregarTarifaTransportadora(tar);
                    }

                    _mantenimiento.actualizarCliente(copia);

                    // Actualizar el cliente

                    _cliente.Nombre = nombre;
                    _cliente.Solicitud_remesas = solicitud_remesas;
                    _cliente.Contrato_transporte = contrato_transporte;
                    _cliente.Telefonos = copia.Telefonos;
                    _cliente.Correos = copia.Correos;
                    _cliente.Puntos_venta = copia.Puntos_venta;
                        
                    padre.actualizarLista();
                    Mensaje.mostrarMensaje("MensajeClienteConfirmacionActualizacion");
                    this.Close();
                }

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de agregar nombre jurídico.
        /// </summary>
        private void btnAgregarNombreJuridico_Click(object sender, EventArgs e)
        {
            if (mtbCIF.Text.Equals(string.Empty) || txtNombreJuridico.Equals(string.Empty))
                return;

            int cif = int.Parse(mtbCIF.Text);
            string nombre = txtNombreJuridico.Text;

            NombreJuridico nombre_juridico = new NombreJuridico(cif: cif, nombre: nombre);
            BindingList<NombreJuridico> nombres = (BindingList<NombreJuridico>)dgvNombresJuridicos.DataSource;

            nombres.Add(nombre_juridico);

            dgvNombresJuridicos.Refresh();
            dgvNombresJuridicos.AutoResizeColumns();
        }

        /// <summary>
        /// Clic en el botón de quitar nombre jurídico.
        /// </summary>
        private void btnQuitarNombreJuridico_Click(object sender, EventArgs e)
        {
            dgvNombresJuridicos.Rows.Remove(dgvNombresJuridicos.SelectedRows[0]);
        }

        /// <summary>
        /// Clic en el botón de agregar cuenta.
        /// </summary>
        private void btnAgregarCuenta_Click(object sender, EventArgs e)
        {
            if (mtbCuenta.Text.Equals(string.Empty)) return;

            long numero_cuenta = long.Parse(mtbCuenta.Text);
            Monedas moneda = (Monedas)cboMonedaCuenta.SelectedIndex;

            Cuenta cuenta = new Cuenta(numero_cuenta, Monedas.Colones);
            BindingList<Cuenta> cuentas = (BindingList<Cuenta>)dgvCuentas.DataSource;

            cuentas.Add(cuenta);

            dgvCuentas.Refresh();
            dgvCuentas.AutoResizeColumns();
        }

        /// <summary>
        /// Clic en el botón de quitar cuenta.
        /// </summary>
        private void btnQuitarCuenta_Click(object sender, EventArgs e)
        {
            dgvCuentas.Rows.Remove(dgvCuentas.SelectedRows[0]);
        }

        /// <summary>
        /// Clic en el botón de agregar un punto de venta.
        /// </summary>
        private void btnAgregarPuntoVenta_Click(object sender, EventArgs e)
        {
            if (txtPuntoVenta.Text.Equals(string.Empty)) return;

            string nombre = txtPuntoVenta.Text;

            PuntoVenta punto_venta = new PuntoVenta(nombre);
            BindingList<PuntoVenta> puntos_venta = (BindingList<PuntoVenta>)dgvPuntosVenta.DataSource;

            puntos_venta.Add(punto_venta);

            dgvPuntosVenta.Refresh();
        }

        /// <summary>
        /// Clic en el botón de quitar un punto de venta.
        /// </summary>
        private void btnQuitarPuntoVenta_Click(object sender, EventArgs e)
        {
            dgvPuntosVenta.Rows.Remove(dgvPuntosVenta.SelectedRows[0]);
        }

        /// <summary>
        /// Clic en el botón de agregar teléfono.
        /// </summary>
        private void btnAgregarTelefono_Click(object sender, EventArgs e)
        {
            Telefono telefono = new Telefono(txtTelefono.Text);

            BindingList<Telefono> telefonos = (BindingList<Telefono>)dgvTelefonos.DataSource;

            telefonos.Add(telefono);
        }

        /// <summary>
        /// Clic en el botón de quitar teléfono.
        /// </summary>
        private void btnQuitarTelefono_Click(object sender, EventArgs e)
        {
            dgvTelefonos.Rows.Remove(dgvTelefonos.SelectedRows[0]);
        }

        /// <summary>
        /// Clic en el botón de agregar correo.
        /// </summary>
        private void btnAgregarCorreo_Click(object sender, EventArgs e)
        {
            Correo correo = new Correo(txtCorreo.Text);

            BindingList<Correo> correos = (BindingList<Correo>)dgvCorreos.DataSource;

            correos.Add(correo);
        }

        /// <summary>
        /// Clic en el botón de quitar correo.
        /// </summary>
        private void btnEliminarCorreo_Click(object sender, EventArgs e)
        {
            dgvCorreos.Rows.Remove(dgvCorreos.SelectedRows[0]);
        }

        /// <summary>
        /// Clic en el botón de salir.
        /// </summary>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Se marca o desmarca la opción de comisión fija.
        /// </summary>
        private void rbComisionFija_CheckedChanged(object sender, EventArgs e)
        {
            //nudComisionFija.Enabled = rbComisionFija.Checked;
            //cboMonedaComision.Enabled = rbComisionFija.Checked;
        }

        /// <summary>
        /// Se marca o desmarca la opción de comisión variable.
        /// </summary>
        private void rbComisionVariable_CheckedChanged(object sender, EventArgs e)
        {
            //nudComisionVariable.Enabled = rbComisionVariable.Checked;
        }
      

        /// <summary>
        /// Se selecciona un nombre jurídico de la lista de nombres jurídicos.
        /// </summary>
        private void dgvNombresJuridicos_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvNombresJuridicos.SelectedRows.Count > 0)
            {
                NombreJuridico nombre = (NombreJuridico)dgvNombresJuridicos.SelectedRows[0].DataBoundItem;

                dgvCuentas.DataSource = nombre.Cuentas;
                btnQuitarNombreJuridico.Enabled = true;
                pnlCuentas.Enabled = true;
            }
            else
            {
                dgvCuentas.DataSource = null;
                btnQuitarNombreJuridico.Enabled = false;
                pnlCuentas.Enabled = false;
            }
            
        }

        /// <summary>
        /// Se selecciona una cuenta de la lista de cuentas.
        /// </summary>
        private void dgvCuentas_SelectionChanged(object sender, EventArgs e)
        {
            btnQuitarCuenta.Enabled = dgvCuentas.RowCount > 0;
        }

        /// <summary>
        /// Se agrega una cuenta a la lista de cuentas.
        /// </summary>
        private void dgvCuentas_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

            for (int contador = 0; contador < e.RowCount; contador++)
            {
                DataGridViewRow fila = dgvCuentas.Rows[e.RowIndex + contador];

                Cuenta cuenta = (Cuenta)fila.DataBoundItem;

                String moneda = string.Empty;

                switch (cuenta.Moneda)
                {
                    case Monedas.Colones:
                        moneda = "Colones";
                        break;
                    case Monedas.Dolares:
                        moneda = "Dólares";
                        break;
                    case Monedas.Euros:
                        moneda = "Euros";
                        break;
                }

                fila.Cells[Moneda.Index].Value = moneda;
            }

        }

        /// <summary>
        /// Se selecciona un teléfono de la lista de teléfonos.
        /// </summary>
        private void dgvTelefonos_SelectionChanged(object sender, EventArgs e)
        {
            btnQuitarTelefono.Enabled = dgvTelefonos.RowCount > 0;
        }

        /// <summary>
        /// Se selecciona un correo de la lista de correos.
        /// </summary>
        private void dgvCorreos_SelectionChanged(object sender, EventArgs e)
        {
            btnQuitarCorreo.Enabled = dgvCorreos.RowCount > 0;
        }

        /// <summary>
        /// Se selecciona un punto de venta de la lista de puntos de venta.
        /// </summary>
        private void dgvPuntosVenta_SelectionChanged(object sender, EventArgs e)
        {
            btnQuitarPuntoVenta.Enabled = dgvPuntosVenta.RowCount > 0;
        }

        /// <summary>
        /// Actualizar el nombre de un punto de venta.
        /// </summary
        private void dgvPuntosVenta_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow fila = dgvPuntosVenta.Rows[e.RowIndex];
            PuntoVenta punto = (PuntoVenta)fila.DataBoundItem;

            try
            {
                _mantenimiento.actualizarPuntoVenta(punto);
            }
            catch(Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Se cambia el texto del número de teléfono.
        /// </summary>
        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            btnAgregarTelefono.Enabled = txtTelefono.Text.Length > 0;
        }

        /// <summary>
        /// Se cambia el texto de la dirección de correo.
        /// </summary>
        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {
            btnAgregarCorreo.Enabled = txtCorreo.Text.Length > 0;
        }



        /// <summary>
        /// Agregar una tarifa a un punto de venta
        /// </summary>
        private void btnAgregarTarifa_Click(object sender, EventArgs e)
        {
            try
            {
                decimal tarifaregular = nudTarifaRegular.Value;
                decimal tarifaferiado = nudFeriados.Value;
                decimal tope = nudTope.Value;
                decimal recargo = nudRecargo.Value;
                decimal entrega_niquel = (decimal)nudEntregaNiquel.Value;
                string centrocosto = txtCentroCosto.Text;
                Monedas moneda = (Monedas)cboMonedaRegular.SelectedIndex;
                Monedas moneda_feriado = (Monedas)cboMonedaFeriados.SelectedIndex;
                Monedas moneda_entreganiquel = (Monedas)cboEntregaNiquel.SelectedIndex;
                Monedas moneda_tope = (Monedas)cboMonedaTope.SelectedIndex;
                Monedas moneda_recargo = (Monedas)cboMonedaRecargo.SelectedIndex;
                PuntoVenta punto_venta = (PuntoVenta)cboPuntodeVenta.SelectedItem;
                bool procesamiento = chkProcesamiento.Checked;


                punto_venta.CentroCostos = centrocosto;
                punto_venta.TarifaRegular = tarifaregular;
                punto_venta.TarifaFeriado = tarifaferiado;
                punto_venta.EntregaNiquel = entrega_niquel;
                punto_venta.Recargo = recargo;
                punto_venta.Tope = tope;
                punto_venta.MonedaTarifaRegular = moneda;
                punto_venta.MonedaTarifaFeriados = moneda_feriado;
                punto_venta.MonedaEntregaNiquel = moneda_entreganiquel;
                punto_venta.MonedaRecargo = moneda_recargo;
                punto_venta.MonedaTope = moneda_tope;
                punto_venta.Procesado = procesamiento;


                _mantenimiento.actualizarPuntoVenta(punto_venta);




            }
            catch (Excepcion ex)
            {

            }
        }


        /// <summary>
        /// Obtiene los datos del  Punto de venta
        /// </summary>

        private void cboPuntodeVenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            PuntoVenta punto = (PuntoVenta)cboPuntodeVenta.SelectedItem;

            nudTarifaRegular.Value = punto.TarifaRegular;
            nudFeriados.Value = punto.TarifaFeriado;
            cboMonedaRegular.SelectedIndex = (int)punto.MonedaTarifaRegular;
            cboMonedaFeriados.SelectedIndex = (int)punto.MonedaTarifaFeriados;
            cboMonedaRecargo.SelectedIndex = (int)punto.MonedaRecargo;
            cboMonedaTope.SelectedIndex = (int)punto.MonedaTope;
            cboEntregaNiquel.SelectedIndex = (int)punto.MonedaEntregaNiquel;
       
            nudTope.Value = punto.Tope;
            nudRecargo.Value = punto.Recargo;
            nudEntregaNiquel.Value = (decimal)punto.EntregaNiquel;

            chkProcesamiento.Checked = punto.Procesado;

            txtCentroCosto.Text = punto.CentroCostos;
        }


        /// <summary>
        /// Agrega una tarifa de transportadora
        /// </summary>
        private void btnAgregarTarifaTransportadora_Click(object sender, EventArgs e)
        {
            if (cboTransportadora.Text.Equals(string.Empty) || cboPuntoVentaTransportadora.Equals(string.Empty))
                return;



            PuntoVenta punto = (PuntoVenta)cboPuntoVentaTransportadora.SelectedItem;
            EmpresaTransporte transportadora = (EmpresaTransporte)cboTransportadora.SelectedItem;
            Decimal regular = nudTarifaRegularTransportadora.Value;
            Decimal feriado = nudTarifaFeriadosTransportadora.Value;
            Decimal niquel = nudTarifaNiquelTransportadora.Value;
            Decimal tope = nudTopeTransportadora.Value;
            Decimal recargo = nudRecargoTransportadora.Value;
            Decimal feriado_menudo = nudFeriadosDomingosMenudo.Value;
            Monedas moneda_tarifa_regular = (Monedas)cboMonedaTarifaRegularTransportadora.SelectedIndex;
            Monedas moneda_tarifa_feriado = (Monedas)cboMonedaFeriadoTransportadora.SelectedIndex;
            Monedas moneda_tope = (Monedas)cboMonedaTopeTransportadora.SelectedIndex;
            Monedas moneda_niquel = (Monedas)cboMonedaNiquelTransportadora.SelectedIndex;
            Monedas moneda_recargo = (Monedas)cboMonedaRecargoTransportadora.SelectedIndex;
            Monedas moneda_feriado_menudo = (Monedas)cboFeriadoDomingosMenudo.SelectedIndex;



            TarifaPuntoVentaTransportadora tarifas_transportadora = new TarifaPuntoVentaTransportadora(transportadora: transportadora, punto: punto,
                tarifaregular: regular, tarifaferiados: feriado, tarifaniquel: niquel, tope: tope, recargo: recargo, moneda_feriado: moneda_tarifa_feriado, monedaferiadomenudo:moneda_feriado_menudo,
                tarifaferiadomenudo:feriado_menudo);

            BindingList<TarifaPuntoVentaTransportadora> nombres = (BindingList<TarifaPuntoVentaTransportadora>)dgvTarifasTransportadora.DataSource;

            //nombres.Add(tarifas_transportadora);

            punto.agregarTarifa(tarifas_transportadora);
            dgvTarifasTransportadora.Refresh();
            dgvTarifasTransportadora.AutoResizeColumns();
        }


        /// <summary>
        /// Cambio en los datos de la tabla de tarifas de transportadora
        /// </summary>
        private void dgvTarifasTransportadora_SelectionChanged(object sender, EventArgs e)
        {
            btnQuitarTarifaTransportadora.Enabled = dgvTarifasTransportadora.SelectedRows.Count > 0;
            btnAlmacenarTarifa.Enabled = dgvTarifasTransportadora.Rows.Count > 0;
        }

        /// <summary>
        /// Obtiene la lista de las tarifas de un punto específico
        /// </summary>
        private void cboPuntoVentaTransportadora_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPuntoVentaTransportadora.SelectedIndex > 0)
            { 
                puntito = (PuntoVenta)cboPuntoVentaTransportadora.SelectedItem;
                dgvTarifasTransportadora.DataSource = puntito.Tarifas;
            }
        }


        /// <summary>
        /// Guarda los datos de las tarifas 
        /// </summary>
        private void btnAlmacenarTarifa_Click(object sender, EventArgs e)
        {
            try
            {
                BindingList<PuntoVenta> lista_puntos = (BindingList<PuntoVenta>)cboPuntoVentaTransportadora.ListaMostrada;

                foreach (PuntoVenta p in lista_puntos)
                {
                    p.Cliente = _cliente;
                    PuntoVenta copia_punto = p;
                    _mantenimiento.agregarTarifaTransportadora(ref copia_punto);
                    dgvTarifasTransportadora.Refresh();
                    dgvTarifasTransportadora.AutoResizeColumns();
                }
            }
            catch (Excepcion ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Quitar Tarifa de un Punto de Venta Específico
        /// </summary>
        private void btnQuitarTarifaTransportadora_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvTarifasTransportadora.SelectedRows.Count > 0)
                {
                    PuntoVenta punto = (PuntoVenta)cboPuntoVentaTransportadora.SelectedItem;

                    TarifaPuntoVentaTransportadora tar = (TarifaPuntoVentaTransportadora)dgvTarifasTransportadora.SelectedRows[0].DataBoundItem;

                    punto.quitarTarifa(tar);
                }

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }


        /// <summary>
        /// Abre un archivo de tarifas para importar
        /// </summary>
        private void btnAbrir_Click(object sender, EventArgs e)
        {
            try
            {

                if (ofdMontosCargas.ShowDialog() == DialogResult.OK)
                {
                    _archivo = ofdMontosCargas.FileName;

                    this.generarCargas();

                    btnImportar.Enabled = _puntos.Count > 0;
                }
                else
                {
                    _archivo = string.Empty;

                    _puntos.Clear();

                    btnImportar.Enabled = false;
                }
            }
            catch (Excepcion ex)
            {
            }
        }


        /// <summary>
        /// Importa los datos a la base de datos
        /// </summary>
        private void btnImportar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_puntos.Count > 0)
                {
                    foreach (PuntoVenta p in _puntos)
                    {
                        try
                        {
                            _mantenimiento.actualizarPuntoVenta(p);
                        }
                        catch(Excepcion ex)
                        {
                            ex.mostrarMensaje();
                        }
                    }

                    Mensaje.mostrarMensaje("MensajeClienteConfirmacionRegistro");
                }

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }



        /// <summary>
        /// Abre el archivo donde se importan las tarifas de las transportadoras
        /// </summary>
        private void btnAbrirTransportadora_Click(object sender, EventArgs e)
        {
            try
            {

                if (ofdMontosCargas.ShowDialog() == DialogResult.OK)
                {
                    _tarifas.Clear();
                    _archivo = ofdMontosCargas.FileName;
                    txtArchivoTransportadora.Text = _archivo;

                    this.generarTarifasTransportadora();

                    btnImportarTarifaTransportadora.Enabled = _tarifas.Count > 0;
                }
                else
                {
                    _archivo = string.Empty;

                    _tarifas.Clear();

                    btnImportarTarifaTransportadora.Enabled = false;
                }
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }


        /// <summary>
        /// Importa los datos de las tarifas leidas en el archivo
        /// </summary>
        private void btnImportarTarifaTransportadora_Click(object sender, EventArgs e)
        {
            try
            {
                if (_tarifas.Count > 0)
                {
                    try
                    {
                        foreach (TarifaPuntoVentaTransportadora t in _tarifas)
                        {
                            TarifaPuntoVentaTransportadora copia = t;

                            if (_mantenimiento.validarTarifaTransportadora(ref copia))
                            {
                                _mantenimiento.actualizarTarifaTransportadoraImportacion(ref copia);

                            }
                            else
                            {
                                _mantenimiento.agregarTarifaTransportadoraImportacion(ref copia);
                            }
                        }

                        Mensaje.mostrarMensaje("MensajeClienteConfirmacionRegistro");
                        _tarifas.Clear();
                        txtArchivoTransportadora.Text = "";
                        btnImportarTarifaTransportadora.Enabled = false;

                    }
                    catch (Excepcion ex)
                    {
                        throw ex;
                    }
                }
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {

        }

        private void gbCuentasPuntos_Enter(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// Permite escoger y mostrar las cuentas asociadas de un punto de venta
        /// </summary>
        private void cboPuntoVentasCuentas_SelectedIndexChanged(object sender, EventArgs e)
        {
            PuntoVenta punto = (PuntoVenta)cboPuntoVentasCuentas.SelectedItem;
            dgvCuentasPuntosVenta.DataSource = punto.Cuentas;
        }


        /// <summary>
        /// Permite agregar una nueva cuenta a un punto de venta especifico.
        /// </summary>
        private void btnAgregarCuentaPuntoVenta_Click(object sender, EventArgs e)
        {
            if (mtbCuentaPunto.Text.Equals(string.Empty)) return;

            PuntoVenta p = (PuntoVenta)cboPuntoVentasCuentas.SelectedItem;
            long numero_cuenta = long.Parse(mtbCuentaPunto.Text);
            Monedas moneda = (Monedas)cboMonedaCuentaPuntoVenta.SelectedIndex;

            Cuenta cuenta = new Cuenta(numero_cuenta, moneda);
            cuenta.PuntoVenta = p;
            BindingList<Cuenta> cuentas = (BindingList<Cuenta>)dgvCuentasPuntosVenta.DataSource;



            cuentas.Add(cuenta);

            p.Cuentas = cuentas;

            dgvCuentasPuntosVenta.Refresh();
            dgvCuentasPuntosVenta.AutoResizeColumns();
        }

        /// <summary>
        /// Permite eliminar los datos de una cuenta
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEliminarCuentaPuntoVenta_Click(object sender, EventArgs e)
        {
            dgvCuentasPuntosVenta.Rows.Remove(dgvCuentasPuntosVenta.SelectedRows[0]);

        }




        private void btnBuscarArchivoCuentas_Click(object sender, EventArgs e)
        {
            try
            {

                if (ofdMontosCargas.ShowDialog() == DialogResult.OK)
                {
                    _archivo = ofdMontosCargas.FileName;
                    txtArchivoCuentasPuntoVenta.Text = _archivo;

                    this.generarCuentasPuntosVenta();

                    btnImportarCuentasPuntoVenta.Enabled = _cuentas.Count > 0;
                }
                else
                {
                    _archivo = string.Empty;

                    _tarifas.Clear();

                    btnImportarTarifaTransportadora.Enabled = false;
                }
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }





        /// <summary>
        /// cambio en la tabla de denominaciones
        /// </summary>
        private void dgvDenominacion_SelectionChanged(object sender, EventArgs e)
        {
            btnAsignarChorreado.Enabled = dgvDenominacion.Rows.Count > 0;
            btnAsignarEnsobrado.Enabled = dgvDenominacion.Rows.Count > 0;

        }


        /// <summary>
        /// Cambio en la tabla de denominaciones en ensobrado
        /// </summary>
        private void dgvDenominacionesEnsobrado_SelectionChanged(object sender, EventArgs e)
        {
            btnDesasignarEnsobrado.Enabled = dgvDenominacionesEnsobrado.Rows.Count > 0;
        }


        /// <summary>
        /// Cambio en la tabla de denominaciones en chorreado
        /// </summary>
        private void dgvDenominacionesChorreado_SelectionChanged(object sender, EventArgs e)
        {
            btnDesasignarChorreado.Enabled = dgvDenominacionesChorreado.Rows.Count > 0;
        }


        /// <summary>
        /// Clic en el botón de desasignar denominaciones de ensobrado
        /// </summary>
        private void btnDesasignarEnsobrado_Click(object sender, EventArgs e)
        {
            this.desasignarDesEnsobrado(dgvDenominacionesEnsobrado.SelectedRows[0], dgvDenominacionesEnsobrado);
        }

        /// <summary>
        /// Clic en el botón de desasignar denominaciones de chorreado
        /// </summary>
        private void btnDesasignarChorreado_Click(object sender, EventArgs e)
        {
            this.desasignarDesChorreado(dgvDenominacionesChorreado.SelectedRows[0], dgvDenominacionesChorreado);
        }



        /// <summary>
        /// Importa las cuentas de los puntos de venta
        /// </summary>
        private void btnImportarCuentasPuntoVenta_Click(object sender, EventArgs e)
        {
            try
            {
                if (_cuentas.Count > 0)
                {
                    try
                    {
                        foreach (Cuenta t in _cuentas)
                        {
                            Cuenta copia = t;

                            if (_mantenimiento.validarCuentaPuntoVenta(ref copia))
                            {
                                _mantenimiento.actualizarCuentaPuntoVentaImportacion(ref copia);

                            }
                            else
                            {
                                _mantenimiento.agregarCuentaPuntoVentaImportacion(ref copia);
                            }
                        }
                    }
                    catch (Excepcion ex)
                    {
                        throw ex;
                    }
                }
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }


        /// <summary>
        /// Cambio en las tablas de cuentas de puntos de venta
        /// </summary>
        private void dgvCuentasPuntosVenta_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int contador = 0; contador < e.RowCount; contador++)
            {
                DataGridViewRow fila = dgvCuentasPuntosVenta.Rows[e.RowIndex + contador];

                Cuenta cuenta = (Cuenta)fila.DataBoundItem;

                String moneda = string.Empty;

                switch (cuenta.Moneda)
                {
                    case Monedas.Colones:
                        moneda = "Colones";
                        break;
                    case Monedas.Dolares:
                        moneda = "Dólares";
                        break;
                    case Monedas.Euros:
                        moneda = "Euros";
                        break;
                }

                fila.Cells[clmMoneda.Index].Value = moneda;
            }
        }


        /// <summary>
        /// Cambio en la tabla de cuentas de punto de venta
        /// </summary>
        private void dgvCuentasPuntosVenta_SelectionChanged(object sender, EventArgs e)
        {
            btnEliminarCuentaPuntoVenta.Enabled = dgvCuentasPuntosVenta.RowCount > 0;
        }



        /// <summary>
        /// Agrega una comision al cliente
        /// </summary>
        private void btnAgregarComision_Click(object sender, EventArgs e)
        {
            if (cboPuntoVentaComision.Text.Equals(string.Empty) || nudComisionVariable.Value == 0)
                return;

            PuntoVenta p = (PuntoVenta)cboPuntoVentaComision.SelectedItem;
            Decimal comision = (Decimal)nudComisionVariable.Value;
            p.MComision = comision;
            //Comision c = new Comision(p: p, monto_comision: comision);

   

        }


        /// <summary>
        /// Quitar una comision al cliente
        /// </summary>
        private void btnQuitarComision_Click(object sender, EventArgs e)
        {
            try
            {
                //if (dgvComisiones.SelectedRows.Count > 0)
                //{
                //    PuntoVenta tar = (PuntoVenta)dgvComisiones.SelectedRows[0].DataBoundItem;

                //    BindingList<PuntoVenta> comin = (BindingList<PuntoVenta>)dgvComisiones.DataSource;
                //    comin.Remove(tar);

                //}

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }



        /// <summary>
        /// Cambio en el punto de venta del cliente
        /// </summary>
        private void cboPuntoVentaComision_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cboPuntoVentaComision.SelectedIndex == 0)
                return;


            PuntoVenta p = (PuntoVenta)cboPuntoVentaComision.SelectedItem;
            BindingList<PuntoVenta> comisiones = new BindingList<CommonObjects.PuntoVenta>();
            //if (p.MComision > 0)
            //{
                comisiones.Add(p);
            //}

                if (p.MComision != null)
                    nudComisionVariable.Value = p.MComision;
                else
                    nudComisionVariable.Value = 0;
            
            BindingList<Denominacion> denominaciones = _mantenimiento.listarDenominacionesMonedas();

            dgvDenominacionesChorreado.DataSource = p.DenominacionChorreado;
            dgvDenominacionesEnsobrado.DataSource = p.DenominacionEnsobrado;

            foreach (Denominacion d in p.DenominacionEnsobrado)
            {
                if (denominaciones.Contains(d))
                    denominaciones.Remove(d);
            }


            foreach (Denominacion d in p.DenominacionChorreado)
            {
                if (denominaciones.Contains(d))
                    denominaciones.Remove(d);
            }

            dgvDenominacion.DataSource = denominaciones;



        }


        



        /// <summary>
        /// Clic en el botón de asignar denominaciones ensobrados
        /// </summary>
        private void btnAsignarEnsobrado_Click(object sender, EventArgs e)
        {

            PuntoVenta p = (PuntoVenta)cboPuntoVentaComision.SelectedItem;
            BindingList<Denominacion> denominaciones_pndientes = (BindingList<Denominacion>)dgvDenominacion.DataSource;
            BindingList<Denominacion> denominacion_ensobrado = p.DenominacionEnsobrado;

            Denominacion carga = (Denominacion)dgvDenominacion.SelectedRows[0].DataBoundItem;


            denominaciones_pndientes.Remove(carga);
            //denominacion_ensobrado.Add(carga);

            p.agregarDenominacionPaqueteEnsobrado(carga);

        }

        /// <summary>
        /// Clic en el botón de asignar denominaciones al paquete de  chorreado
        /// </summary>
        private void btnAsignarChorreado_Click(object sender, EventArgs e)
        {
            PuntoVenta p = (PuntoVenta)cboPuntoVentaComision.SelectedItem;

            BindingList<Denominacion> denominaciones_pndientes = (BindingList<Denominacion>)dgvDenominacion.DataSource;
            BindingList<Denominacion> denominacion_chorreados = (BindingList<Denominacion>)dgvDenominacionesChorreado.DataSource;

            Denominacion carga = (Denominacion)dgvDenominacion.SelectedRows[0].DataBoundItem;


            denominaciones_pndientes.Remove(carga);
            //denominacion_chorreados.Add(carga);

            p.agregarDenominacionPaqueteChorreado(carga);
        }




       

        #endregion Eventos

        #region Metodos Privados

        /// <summary>
        /// Leer los montos del archivo y generar las cargas.
        /// </summary>
        private void generarCargas()
        {
            DocumentoExcel archivo = null;

            try
            {
               

                _puntos.Clear();


                archivo = new DocumentoExcel(_archivo, false);

                archivo.seleccionarHoja(1);

                Celda celda_id_punto = archivo.seleccionarCelda("A2");

                Celda celda_tarifa_regular = archivo.seleccionarCelda("C2");
                Celda celda_tarifa_feriado = archivo.seleccionarCelda("E2");
                Celda celda_recargo = archivo.seleccionarCelda("I2");
                Celda celda_tope = archivo.seleccionarCelda("G2");
                Celda celda_niquel = archivo.seleccionarCelda("K2");
                Celda celda_moneda_regular = archivo.seleccionarCelda("D2");
                Celda celda_moneda_feriado = archivo.seleccionarCelda("F2");
                Celda celda_moneda_recargo = archivo.seleccionarCelda("J2");
                Celda celda_moneda_tope = archivo.seleccionarCelda("H2");
                Celda celda_moneda_niquel = archivo.seleccionarCelda("L2");
                Celda celda_centro_costos = archivo.seleccionarCelda("M2");
                Celda celda_nombre_punto = archivo.seleccionarCelda("B2");
                Celda celda_procesamiento = archivo.seleccionarCelda("N2");



                this.generarCargasMoneda(archivo, celda_tarifa_regular, celda_tarifa_feriado, celda_recargo, celda_tope, celda_niquel,
                    celda_moneda_regular, celda_moneda_feriado, celda_moneda_recargo, celda_moneda_tope, celda_moneda_niquel, celda_id_punto, celda_centro_costos, celda_nombre_punto
                    ,celda_procesamiento);

              

                archivo.mostrar();
                archivo.cerrar();

              
            }
            catch (Excepcion ex)
            {
                archivo.mostrar();
                archivo.cerrar();

                ex.mostrarMensaje();
            }

        }




        /// <summary>
        /// Generar las cargas para una moneda específica.
        /// </summary>
        private void generarCargasMoneda(DocumentoExcel archivo, Celda celda_tarifa_regular, Celda celda_tarifa_feriado, Celda celda_recargo,
            Celda celda_tope, Celda celda_niquel, Celda celda_monedaregular, Celda celda_monedaferiado, Celda celda_monedarecargo, Celda celda_monedatope,
            Celda celda_moneda_niquel, Celda celda_id_punto, Celda celda_centro_costos, Celda celda_nombre_punto, Celda celda_procesamiento)
        {
         

            while (!celda_id_punto .Valor.Equals(string.Empty))
            {
                try
                {
                    short numero_punto = (short)Convert.ToInt32(celda_id_punto.Valor);
                    Decimal tarifa_regular = Convert.ToDecimal(celda_tarifa_regular.Valor);
                    Decimal tarifa_feriado = Convert.ToDecimal(celda_tarifa_feriado.Valor);
                    Decimal recargo = Convert.ToDecimal(celda_recargo.Valor);
                    Decimal tope = Convert.ToDecimal(celda_tope.Valor);
                    Decimal niquel = Convert.ToDecimal(celda_niquel.Valor);
                    Monedas moneda_tarifa_regular = (Monedas)Convert.ToByte(celda_monedaregular.Valor);
                    Monedas moneda_tarifa_feriado = (Monedas)Convert.ToByte(celda_monedaferiado.Valor);
                    Monedas moneda_tarifa_niquel = (Monedas)Convert.ToByte(celda_moneda_niquel.Valor);
                    Monedas moneda_tope = (Monedas)Convert.ToByte(celda_monedatope.Valor);
                    Monedas moneda_recargo = (Monedas)Convert.ToByte(celda_monedarecargo.Valor);
                    string centro_costos = celda_centro_costos.Valor;
                    string nombre_punto = celda_nombre_punto.Valor;
                    bool procesamiento = Convert.ToBoolean(celda_procesamiento.Valor);


                    PuntoVenta punto = new PuntoVenta(id: numero_punto);
                    punto.CentroCostos = centro_costos;
                    punto.EntregaNiquel = niquel;
                    punto.MonedaEntregaNiquel = moneda_tarifa_niquel;
                    punto.MonedaRecargo = moneda_recargo;
                    punto.MonedaTarifaFeriados = moneda_tarifa_feriado;
                    punto.MonedaTarifaRegular = moneda_tarifa_regular;
                    punto.MonedaTope = moneda_tope;
                    punto.TarifaFeriado = tarifa_feriado;
                    punto.TarifaRegular = tarifa_regular;
                    punto.Recargo = recargo;
                    punto.Tope = tope;
                    punto.Nombre = nombre_punto;
                    punto.Procesado = procesamiento;

                    _puntos.Add(punto);

                    celda_id_punto = archivo.seleccionarCelda(celda_id_punto.Fila + 1, celda_id_punto.Columna);
                    celda_tarifa_regular = archivo.seleccionarCelda(celda_tarifa_regular.Fila + 1, celda_tarifa_regular.Columna);
                    celda_tarifa_feriado = archivo.seleccionarCelda(celda_tarifa_feriado.Fila + 1, celda_tarifa_feriado.Columna);
                    celda_recargo = archivo.seleccionarCelda(celda_recargo.Fila + 1, celda_recargo.Columna);
                    celda_tope = archivo.seleccionarCelda(celda_tope.Fila + 1, celda_tope.Columna);
                    celda_niquel = archivo.seleccionarCelda(celda_niquel.Fila + 1, celda_niquel.Columna);
                    celda_monedaregular = archivo.seleccionarCelda(celda_monedaregular.Fila + 1, celda_monedaregular.Columna);
                    celda_monedaferiado = archivo.seleccionarCelda(celda_monedaferiado.Fila + 1, celda_monedaferiado.Columna);
                    celda_monedarecargo = archivo.seleccionarCelda(celda_monedarecargo.Fila + 1, celda_monedarecargo.Columna);
                    celda_monedatope = archivo.seleccionarCelda(celda_monedatope.Fila + 1, celda_monedatope.Columna);
                    celda_moneda_niquel = archivo.seleccionarCelda(celda_moneda_niquel.Fila + 1, celda_moneda_niquel.Columna);
                    celda_centro_costos = archivo.seleccionarCelda(celda_centro_costos.Fila + 1, celda_centro_costos.Columna);
                    celda_nombre_punto = archivo.seleccionarCelda(celda_nombre_punto.Fila + 1, celda_nombre_punto.Columna);
                    celda_procesamiento = archivo.seleccionarCelda(celda_procesamiento.Fila + 1, celda_procesamiento.Columna);
                }
                catch(Excepcion ex)
                {
                    throw ex;
                }
            }

        }







        /// <summary>
        /// Leer los montos del archivo y generar las cargas.
        /// </summary>
        private void generarTarifasTransportadora()
        {
            DocumentoExcel archivo = null;

            try
            {


                _tarifas.Clear();


                archivo = new DocumentoExcel(_archivo, false);

                archivo.seleccionarHoja(2);

                Celda celda_id_punto = archivo.seleccionarCelda("A2");
                Celda celda_id_transportadora = archivo.seleccionarCelda("C2");
                Celda celda_tarifa_regular = archivo.seleccionarCelda("E2");
                Celda celda_tarifa_feriado = archivo.seleccionarCelda("G2");
                Celda celda_recargo = archivo.seleccionarCelda("M2");
                Celda celda_tope = archivo.seleccionarCelda("K2");
                Celda celda_niquel = archivo.seleccionarCelda("I2");
                Celda celda_moneda_regular = archivo.seleccionarCelda("F2");
                Celda celda_moneda_feriado = archivo.seleccionarCelda("H2");
                Celda celda_moneda_recargo = archivo.seleccionarCelda("N2");
                Celda celda_moneda_tope = archivo.seleccionarCelda("L2");
                Celda celda_moneda_niquel = archivo.seleccionarCelda("J2");
                Celda celda_tarifa_feriado_menudo = archivo.seleccionarCelda("O2");
                Celda celda_moneda_feriado_menudo = archivo.seleccionarCelda("P2");
       



                this.generarTarifasTransportadoraDatos(archivo, celda_tarifa_regular, celda_tarifa_feriado, celda_recargo, celda_tope, celda_niquel,
                    celda_moneda_regular, celda_moneda_feriado, celda_moneda_recargo, celda_moneda_tope, celda_moneda_niquel, celda_id_punto, celda_id_transportadora,
                    celda_tarifa_feriado_menudo, celda_moneda_feriado_menudo);



                archivo.mostrar();
                archivo.cerrar();


            }
            catch (Excepcion ex)
            {
                archivo.mostrar();
                archivo.cerrar();

                ex.mostrarMensaje();
            }

        }






        /// <summary>
        /// Generar las cargas para una moneda específica.
        /// </summary>
        private void generarTarifasTransportadoraDatos(DocumentoExcel archivo, Celda celda_tarifa_regular, Celda celda_tarifa_feriado, Celda celda_recargo,
            Celda celda_tope, Celda celda_niquel, Celda celda_monedaregular, Celda celda_monedaferiado, Celda celda_monedarecargo, Celda celda_monedatope,
            Celda celda_moneda_niquel, Celda celda_id_punto, Celda celda_id_transportadora, Celda celda_tarifa_feriado_menudo, Celda celda_moneda_feriado_menudo)
        {

            try
            {

                while (!celda_id_punto.Valor.Equals(string.Empty))
                {
                    try
                    {
                        short numero_punto = (short)Convert.ToInt32(celda_id_punto.Valor);
                        Decimal tarifa_regular = Convert.ToDecimal(celda_tarifa_regular.Valor);
                        Decimal tarifa_feriado = Convert.ToDecimal(celda_tarifa_feriado.Valor);
                        Decimal recargo = Convert.ToDecimal(celda_recargo.Valor);
                        Decimal tope = Convert.ToDecimal(celda_tope.Valor);
                        Decimal niquel = Convert.ToDecimal(celda_niquel.Valor);
                        Decimal tarifa_feriado_menudo = Convert.ToDecimal(celda_tarifa_feriado_menudo.Valor);
                        Monedas moneda_tarifa_regular = (Monedas)Convert.ToByte(celda_monedaregular.Valor);
                        Monedas moneda_tarifa_feriado = (Monedas)Convert.ToByte(celda_monedaferiado.Valor);
                        Monedas moneda_tarifa_niquel = (Monedas)Convert.ToByte(celda_moneda_niquel.Valor);
                        Monedas moneda_tope = (Monedas)Convert.ToByte(celda_monedatope.Valor);
                        Monedas moneda_recargo = (Monedas)Convert.ToByte(celda_monedarecargo.Valor);
                        Monedas moneda_feriado_menudo = (Monedas)Convert.ToByte(celda_moneda_feriado_menudo.Valor);


                        byte transportadora = Convert.ToByte(celda_id_transportadora.Valor);

                        PuntoVenta p = new CommonObjects.PuntoVenta(id: numero_punto);

                        EmpresaTransporte empresa = new EmpresaTransporte(id: transportadora);



                        TarifaPuntoVentaTransportadora punto = new TarifaPuntoVentaTransportadora();
                        punto.PuntoVenta = p;
                        punto.EmpresaTransporte = empresa;
                        punto.TarifaNiquel = niquel;
                        punto.MonedaTarifaNiquel = moneda_tarifa_niquel;
                        punto.MonedaRecargo = moneda_recargo;
                        punto.MonedaTarifaFeriado = moneda_tarifa_feriado;
                        punto.MonedaTarifaRegular = moneda_tarifa_regular;
                        punto.MonedaTope = moneda_tope;
                        punto.TarifaFeriados = tarifa_feriado;
                        punto.TarifaRegular = tarifa_regular;
                        punto.Recargo = recargo;
                        punto.Tope = tope;
                        punto.TarifaFeriadoDomingosMenudo = tarifa_feriado_menudo;
                        punto.MonedaFeriadosDomingosMenudo = moneda_feriado_menudo;
                       

                        _tarifas.Add(punto);

                        celda_id_punto = archivo.seleccionarCelda(celda_id_punto.Fila + 1, celda_id_punto.Columna);
                        celda_tarifa_regular = archivo.seleccionarCelda(celda_tarifa_regular.Fila + 1, celda_tarifa_regular.Columna);
                        celda_tarifa_feriado = archivo.seleccionarCelda(celda_tarifa_feriado.Fila + 1, celda_tarifa_feriado.Columna);
                        celda_recargo = archivo.seleccionarCelda(celda_recargo.Fila + 1, celda_recargo.Columna);
                        celda_tope = archivo.seleccionarCelda(celda_tope.Fila + 1, celda_tope.Columna);
                        celda_niquel = archivo.seleccionarCelda(celda_niquel.Fila + 1, celda_niquel.Columna);
                        celda_monedaregular = archivo.seleccionarCelda(celda_monedaregular.Fila + 1, celda_monedaregular.Columna);
                        celda_monedaferiado = archivo.seleccionarCelda(celda_monedaferiado.Fila + 1, celda_monedaferiado.Columna);
                        celda_monedarecargo = archivo.seleccionarCelda(celda_monedarecargo.Fila + 1, celda_monedarecargo.Columna);
                        celda_monedatope = archivo.seleccionarCelda(celda_monedatope.Fila + 1, celda_monedatope.Columna);
                        celda_moneda_niquel = archivo.seleccionarCelda(celda_moneda_niquel.Fila + 1, celda_moneda_niquel.Columna);
                        celda_id_transportadora = archivo.seleccionarCelda(celda_id_transportadora.Fila + 1, celda_id_transportadora.Columna);
                        celda_tarifa_feriado_menudo = archivo.seleccionarCelda(celda_tarifa_feriado_menudo.Fila + 1, celda_tarifa_feriado_menudo.Columna);
                        celda_moneda_feriado_menudo = archivo.seleccionarCelda(celda_moneda_feriado_menudo.Fila + 1, celda_moneda_feriado_menudo.Columna);


                    }

                    catch (Excepcion ex)
                    {
                        throw ex;
                    }
                }

                Mensaje.mostrarMensaje("MensajeImportacionTarifasTransportadoras");
            }
            catch (Excepcion ex)
            {
                Excepcion.mostrarMensaje("ErrorImportacionTarifasTransportadoras");
            }

        }


        /// <summary>
        /// Desasignar la denominación de un paquete de ensobrado
        /// </summary>
        private void desasignarDesEnsobrado(DataGridViewRow fila, DataGridView tabla)
        {
            PuntoVenta p = (PuntoVenta)cboPuntoVentaComision.SelectedItem;
            BindingList<Denominacion> cargas_pendientes = (BindingList<Denominacion>)dgvDenominacion.DataSource;
            BindingList<Denominacion> cargas_asignadas = (BindingList<Denominacion>)tabla.DataSource;

            Denominacion carga = (Denominacion)fila.DataBoundItem;


            cargas_asignadas.Remove(carga);
            cargas_pendientes.Add(carga);

            p.quitarDenominacionPaqueteEnsobrado(carga);
        }


        /// <summary>
        /// Desasignar la denominación de un paquete de chorreado
        /// </summary>
        private void desasignarDesChorreado(DataGridViewRow fila, DataGridView tabla)
        {
            PuntoVenta p = (PuntoVenta)cboPuntoVentaComision.SelectedItem;
            BindingList<Denominacion> cargas_pendientes = (BindingList<Denominacion>)dgvDenominacion.DataSource;
            BindingList<Denominacion> cargas_asignadas = (BindingList<Denominacion>)tabla.DataSource;

            Denominacion carga = (Denominacion)fila.DataBoundItem;

             
            cargas_asignadas.Remove(carga);
            cargas_pendientes.Add(carga);

            p.quitarDenominacionPaqueteChorreado(carga);
        }





        /// <summary>
        /// Leer los montos del archivo y generar las cargas.
        /// </summary>
        private void generarCuentasPuntosVenta()
        {
            DocumentoExcel archivo = null;

            try
            {


                _tarifas.Clear();


                archivo = new DocumentoExcel(_archivo, false);

                archivo.seleccionarHoja(1);

                Celda celda_id_punto = archivo.seleccionarCelda("A2");
                Celda celda_cuenta = archivo.seleccionarCelda("C2");
                Celda celda_moneda = archivo.seleccionarCelda("D2");





                this.generarCuentasPuntoVentaDatos(archivo, celda_id_punto, celda_cuenta, celda_moneda);



                archivo.mostrar();
                archivo.cerrar();


            }
            catch (Excepcion ex)
            {
                archivo.mostrar();
                archivo.cerrar();

                ex.mostrarMensaje();
            }

        }






        /// <summary>
        /// Generar las cargas para una moneda específica.
        /// </summary>
        private void generarCuentasPuntoVentaDatos(DocumentoExcel archivo, Celda celda_id_punto, Celda celda_cuenta, Celda celda_moneda)
        {

            try
            {

                while (!celda_id_punto.Valor.Equals(string.Empty))
                {
                    try
                    {
                        short numero_punto = (short)Convert.ToInt32(celda_id_punto.Valor);
                        long cuenta = (long)Convert.ToInt64(celda_cuenta.Valor);


                        Monedas moneda = (Monedas)Convert.ToByte(celda_moneda.Valor);



                        PuntoVenta p = new CommonObjects.PuntoVenta(id: numero_punto);



                        Cuenta cuentao = new Cuenta(cuenta, moneda);
                        cuentao.PuntoVenta = p;

                        _cuentas.Add(cuentao);

                        celda_id_punto = archivo.seleccionarCelda(celda_id_punto.Fila + 1, celda_id_punto.Columna);
                        celda_cuenta = archivo.seleccionarCelda(celda_cuenta.Fila + 1, celda_cuenta.Columna);
                        celda_moneda = archivo.seleccionarCelda(celda_moneda.Fila + 1, celda_moneda.Columna);

                    }

                    catch (Excepcion ex)
                    {
                        throw ex;
                    }
                }

                Mensaje.mostrarMensaje("MensajeImportacionTarifasTransportadoras");
            }
            catch (Excepcion ex)
            {
                Excepcion.mostrarMensaje("ErrorImportacionTarifasTransportadoras");
            }

        }



        #endregion Metodos Privados

        
        private void dgvComisiones_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow fila = dgvPuntosVenta.Rows[e.RowIndex];
            PuntoVenta punto = (PuntoVenta)fila.DataBoundItem;

            try
            {
                _mantenimiento.actualizarPuntoVenta(punto);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

     

        /// <summary>
        /// Validar el formato númerico de la celda de la cantidad de fórmulas de un cartucho.
        /// </summary
        private void validarFormatoNumericoCelda(DataGridViewCellParsingEventArgs e)
        {

            if (e.Value != null)
            {
                short valor;

                short.TryParse(e.Value.ToString().Replace(",", ""), out valor);

                e.Value = valor;
                e.ParsingApplied = true;
            }

        }

      

        
    }

}
