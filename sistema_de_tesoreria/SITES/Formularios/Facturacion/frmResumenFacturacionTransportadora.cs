using BussinessLayer;
using CommonObjects;
using CommonObjects.Clases;
using LibreriaMensajes;
using LibreriaReportesOffice;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GUILayer.Formularios.Facturacion
{
    public partial class frmResumenFacturacionTransportadora : Form
    {
        #region Atributos

        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;
        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;

        private FacturacionTransportadora _facturacion_transportadora = null;
        private Colaborador _usuario = null;

        String[] Mes = { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };  


        Decimal _monto_cobrar = 0;
        Decimal _monto_cobrar_salientes = 0;
        Decimal _monto_cobrar_sucursales = 0;
        Decimal _monto_cobrar_procesamiento = 0;
        Decimal _penalidades = 0;

        // Atributos Cuenta Corriente Entrante
        private string _modelo_cuenta_corriente_entrante = "";
        private string _cc_cuenta_corriente_entrante = "";
        private string _factura_cuenta_corriente_entrante = "";
        private decimal _monto_cuenta_corriente_entrante = 0;
        private decimal _creditosdebitos_cuenta_corriente_entrante = 0;
        
        //Atributos Cuenta Corriente Salida

        private string _modelo_cuenta_corriente_saliente = "";
        private string _cc_cuenta_corriente_saliente = "";
        private string _factura_cuenta_corriente_saliente = "";
        private decimal _monto_cuenta_corriente_saliente = 0;
        private decimal _creditosdebitos_cuenta_corriente_saliente = 0;

        // Atributos Sucursales

        private string _modelo_sucursales = "";
        private string _cc_sucursales = "";
        private string _factura_sucursales = "";
        private decimal _monto_sucursales = 0;
        private decimal _creditosdebitos_sucursales = 0;

        //Atributos Procesamiento

        private string _modelo_procesamiento = "";
        private string _cc_procesamiento = "";
        private string _factura_procesamiento = "";
        private decimal _monto_procesamiento = 0;
        private decimal _creditosdebitos_procesamiento = 0;

        // Atributos Material Operativo


        private string _modelo_material_operativo = "";
        private string _cc_material_operativo = "";
        private string _factura_material_operativo = "";
        private decimal _monto_material_operativo = 0;
        private decimal _creditosdebitos_material_operativo = 0;

        // Atributos Servicios Especiales

        private string _modelo_servicios_especiales = "";
        private string _cc_servicios_especiales = "";
        private string _factura_servicios_especiales = "";
        private decimal _monto_servicios_especiales = 0;
        private decimal _creditosdebitos_servicios_especiales = 0;



        // Eticket

        private string _modelo_eticket = "";
        private string _cc_eticket = "";
        private string _factura_eticket = "";
        private decimal _monto_eticket = 0;
        private decimal _creditosdebitos_eticket = 0;
       
        #endregion Atributos

        #region Constructor

        public frmResumenFacturacionTransportadora()
        {
            InitializeComponent();

        }

        public frmResumenFacturacionTransportadora(Colaborador usuario)
        {
            InitializeComponent();

            _usuario = usuario;

            cboCliente.ListaMostrada = _mantenimiento.listarClientes(string.Empty);
            cboTransportadora.ListaMostrada = _mantenimiento.listarEmpresasTransporte();

            crearTabla(dgvFacturar);

            
            

        }

        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de guardar.
        /// </summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Verificar que se hayan seleccionado los datos

                


                try
                {
                    Cliente cliente = cboCliente.SelectedIndex == 0 ?
                   null : (Cliente)cboCliente.SelectedItem;


                    EmpresaTransporte transportadora = cboTransportadora.SelectedIndex == 0 ?
                   null : (EmpresaTransporte)cboTransportadora.SelectedItem;

                    string observ = txtObservaciones.Text;
                    DateTime fecha_inicio = dtpFecha.Value;
                    DateTime fecha_fin = dtpFechaFin.Value;
                    FacturacionTransportadora facturacion = new FacturacionTransportadora();


                    BindingList<CategoriaFacturacionTransportadora> lista = new BindingList<CategoriaFacturacionTransportadora>();

                    // Carga los datos de la tabla

                    CategoriaFacturacionTransportadora cuenta_corriente_entrante = new CategoriaFacturacionTransportadora(monto: _monto_cuenta_corriente_entrante, creditosdebitos: _creditosdebitos_cuenta_corriente_entrante, centro_costos: _cc_cuenta_corriente_entrante,
                        factura: _factura_cuenta_corriente_entrante, categoria: CategoriasFacturacion.Cuenta_Corriente_Entrantes,modelo:_modelo_cuenta_corriente_entrante);

                    CategoriaFacturacionTransportadora cuenta_corriente_saliente = new CategoriaFacturacionTransportadora(monto: _monto_cuenta_corriente_saliente, creditosdebitos: _creditosdebitos_cuenta_corriente_saliente, centro_costos: _cc_cuenta_corriente_saliente,
                        factura: _factura_cuenta_corriente_saliente, categoria: CategoriasFacturacion.Cuenta_Corriente_Salientes, modelo: _modelo_cuenta_corriente_saliente);

                    CategoriaFacturacionTransportadora sucursales = new CategoriaFacturacionTransportadora(monto: _monto_sucursales, creditosdebitos: _creditosdebitos_sucursales, centro_costos: _cc_sucursales, factura: _factura_sucursales, categoria: CategoriasFacturacion.Sucursales, modelo: _modelo_sucursales);

                    CategoriaFacturacionTransportadora material_operativo = new CategoriaFacturacionTransportadora(monto: _monto_material_operativo, creditosdebitos: _creditosdebitos_material_operativo, centro_costos: _cc_material_operativo, factura: _factura_material_operativo, categoria: CategoriasFacturacion.Material_Operativo, modelo: _modelo_material_operativo);

                    CategoriaFacturacionTransportadora procesamiento = new CategoriaFacturacionTransportadora(monto: _monto_procesamiento, creditosdebitos: _creditosdebitos_procesamiento, centro_costos: _cc_procesamiento, factura: _factura_procesamiento, categoria: CategoriasFacturacion.Procesamiento, modelo: _modelo_procesamiento);

                    CategoriaFacturacionTransportadora servicios_especiales = new CategoriaFacturacionTransportadora(monto: _monto_servicios_especiales, creditosdebitos: _creditosdebitos_servicios_especiales, centro_costos: _cc_servicios_especiales,
                        factura: _factura_servicios_especiales, categoria: CategoriasFacturacion.Servicios_Especiales, modelo: _modelo_servicios_especiales);


                    CategoriaFacturacionTransportadora eticket = new CategoriaFacturacionTransportadora(monto: _monto_eticket, creditosdebitos: _creditosdebitos_eticket, centro_costos: _cc_eticket,
                        factura: _factura_eticket, categoria: CategoriasFacturacion.Eticket, modelo: _modelo_eticket);


                    lista.Add(cuenta_corriente_entrante);
                    lista.Add(cuenta_corriente_saliente);
                    lista.Add(sucursales);
                    lista.Add(material_operativo);
                    lista.Add(procesamiento);
                    lista.Add(servicios_especiales);
                    lista.Add(eticket);


                   
                  

                    // Verificar si el vehiculo ya está registrado

                    if (_facturacion_transportadora == null)
                    {
                        // Agregar los datos del vehiculo

                        if (Mensaje.mostrarMensajeConfirmacion("MensajeFacturacionTransportadoraRegistro") == DialogResult.Yes)
                        {
                            _facturacion_transportadora = new FacturacionTransportadora(cliente: cliente, transportadora: transportadora, fecha: fecha_inicio
                                , fecha_fin: fecha_fin, observaciones: observ);

                            _facturacion_transportadora.ListaCategoria = lista;

                            _coordinacion.agregarFacturacionTransportadora(ref _facturacion_transportadora);


                            Mensaje.mostrarMensaje("MensajeFacturacionTransportadoraConfirmacionRegistro");
                            this.Close();
                        }

                    }
                    else
                    {
                        // Actualizar los datos de la ubicación

                        FacturacionTransportadora copia = new FacturacionTransportadora(id: _facturacion_transportadora.ID, cliente: cliente, transportadora: transportadora, fecha: fecha_inicio
                                , fecha_fin: fecha_fin, observaciones: observ);

                        copia.ListaCategoria = lista;

                        _coordinacion.actualizarFacturacionTransportadora(copia);


                        Mensaje.mostrarMensaje("MensajeFacturacionTransportadoraConfirmacionActualizacion");
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
        /// Verifica si la informacion en la celda es numerica o no
        /// </summary>
        private void dgvFacturar_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == clmModelo.Index) return;
            if (e.ColumnIndex == clmFactura.Index) return;
            if (e.ColumnIndex == clmCC.Index) return;

            DataGridViewCell celda = dgvFacturar[e.ColumnIndex, e.RowIndex];

            if (e.ColumnIndex > 3)
            {
                decimal valor = 0;

                if (!decimal.TryParse(celda.Value.ToString(), out valor))
                    celda.Value = valor;
            }
            else
            {
                int valor = 0;

                if (!int.TryParse(celda.Value.ToString(), out valor))
                    celda.Value = valor;
            }
        }


        /// <summary>
        /// Obtento los valores de las celdas
        /// </summary>
        private void dgvFacturar_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvFacturar.RowCount > 0)
            {
                DataGridViewCell celda = dgvFacturar[e.ColumnIndex, e.RowIndex];

                // Cuenta Corriente
                _modelo_cuenta_corriente_entrante = dgvFacturar[clmModelo.Index, 0].Value.ToString();
                _cc_cuenta_corriente_entrante = dgvFacturar[clmCC.Index, 0].Value.ToString();
                _factura_cuenta_corriente_entrante = dgvFacturar[clmFactura.Index, 0].Value.ToString();
                _modelo_cuenta_corriente_entrante = dgvFacturar[clmModelo.Index, 0].Value.ToString();
                _monto_cuenta_corriente_entrante = Convert.ToDecimal(dgvFacturar[clmMonto.Index, 0].Value);
                _creditosdebitos_cuenta_corriente_entrante = Convert.ToDecimal(dgvFacturar[clmNotasDebitoCredito.Index, 0].Value);
                

                //Cuenta Salida


                _modelo_cuenta_corriente_saliente = dgvFacturar[clmModelo.Index, 1].Value.ToString();
                _cc_cuenta_corriente_saliente = dgvFacturar[clmCC.Index, 1].Value.ToString();
                _factura_cuenta_corriente_saliente = dgvFacturar[clmFactura.Index, 1].Value.ToString();
                _modelo_cuenta_corriente_saliente = dgvFacturar[clmModelo.Index, 1].Value.ToString();
                _monto_cuenta_corriente_saliente = Convert.ToDecimal(dgvFacturar[clmMonto.Index, 1].Value);
                _creditosdebitos_cuenta_corriente_saliente = Convert.ToDecimal(dgvFacturar[clmNotasDebitoCredito.Index, 1].Value);


                // Sucursales 

                _modelo_sucursales = dgvFacturar[clmModelo.Index, 2].Value.ToString();
                _cc_sucursales = dgvFacturar[clmCC.Index, 2].Value.ToString();
                _factura_sucursales = dgvFacturar[clmFactura.Index, 2].Value.ToString();
                _modelo_sucursales = dgvFacturar[clmModelo.Index, 2].Value.ToString();
                _monto_sucursales = Convert.ToDecimal(dgvFacturar[clmMonto.Index, 2].Value);
                _creditosdebitos_sucursales = Convert.ToDecimal(dgvFacturar[clmNotasDebitoCredito.Index, 2].Value);



                // Material Operativo


                _modelo_material_operativo = dgvFacturar[clmModelo.Index, 3].Value.ToString();
                _cc_material_operativo = dgvFacturar[clmCC.Index, 3].Value.ToString();
                _factura_material_operativo = dgvFacturar[clmFactura.Index, 3].Value.ToString();
                _modelo_material_operativo = dgvFacturar[clmModelo.Index, 3].Value.ToString();
                _monto_material_operativo = Convert.ToDecimal(dgvFacturar[clmMonto.Index, 3].Value);
                _creditosdebitos_material_operativo = Convert.ToDecimal(dgvFacturar[clmNotasDebitoCredito.Index, 3].Value);



                // Procesamiento


                _modelo_procesamiento = dgvFacturar[clmModelo.Index, 4].Value.ToString();
                _cc_procesamiento = dgvFacturar[clmCC.Index, 4].Value.ToString();
                _factura_procesamiento = dgvFacturar[clmFactura.Index, 4].Value.ToString();
                _modelo_procesamiento = dgvFacturar[clmModelo.Index, 4].Value.ToString();
                _monto_procesamiento = Convert.ToDecimal(dgvFacturar[clmMonto.Index, 4].Value);
                _creditosdebitos_procesamiento = Convert.ToDecimal(dgvFacturar[clmNotasDebitoCredito.Index, 4].Value);



                // Servicios Especiales

                _modelo_servicios_especiales = dgvFacturar[clmModelo.Index, 5].Value.ToString();
                _cc_servicios_especiales = dgvFacturar[clmCC.Index, 5].Value.ToString();
                _factura_servicios_especiales = dgvFacturar[clmFactura.Index, 5].Value.ToString();
                _modelo_servicios_especiales = dgvFacturar[clmModelo.Index, 5].Value.ToString();
                _monto_servicios_especiales = Convert.ToDecimal(dgvFacturar[clmMonto.Index, 5].Value);
                _creditosdebitos_servicios_especiales = Convert.ToDecimal(dgvFacturar[clmNotasDebitoCredito.Index, 5].Value);


                // Eticket

                _modelo_eticket = dgvFacturar[clmModelo.Index, 6].Value.ToString();
                _cc_eticket = dgvFacturar[clmCC.Index, 6].Value.ToString();
                _factura_eticket = dgvFacturar[clmFactura.Index, 6].Value.ToString();
                _modelo_eticket = dgvFacturar[clmModelo.Index, 6].Value.ToString();
                _monto_eticket = Convert.ToDecimal(dgvFacturar[clmMonto.Index, 6].Value);
                _creditosdebitos_eticket = Convert.ToDecimal(dgvFacturar[clmNotasDebitoCredito.Index, 6].Value);

                // Calculos de Subtotales

                decimal subtotal_monto = _monto_cuenta_corriente_entrante + _monto_cuenta_corriente_saliente + _monto_material_operativo +
                    _monto_procesamiento + _monto_servicios_especiales + _monto_sucursales;

                decimal subtotal_creditos_debitos = _creditosdebitos_cuenta_corriente_entrante + _creditosdebitos_cuenta_corriente_saliente +
                    _creditosdebitos_material_operativo + _creditosdebitos_procesamiento + _creditosdebitos_servicios_especiales +
                    _creditosdebitos_sucursales;


                dgvFacturar[clmMonto.Index, 8].Value = subtotal_monto;
                dgvFacturar[clmNotasDebitoCredito.Index, 8].Value = subtotal_creditos_debitos;


                // Calculo del Total

                decimal total = subtotal_monto + subtotal_creditos_debitos;

                dgvFacturar[clmMonto.Index, 10].Value = total;
               

            }
        }

        /// <summary>
        /// Carga los datos del resumen de facturacion
        /// </summary>
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fechai = dtpFecha.Value;
                DateTime fechaf = dtpFechaFin.Value;

                Cliente cliente = cboCliente.SelectedIndex == 0 ?
                        null : (Cliente)cboCliente.SelectedItem;

                EmpresaTransporte empresa = cboTransportadora.SelectedIndex == 0 ?
                    null : (EmpresaTransporte)cboTransportadora.SelectedItem;

                _monto_cobrar = _coordinacion.calcularResumenFacturacion(cliente, empresa, fechai, fechaf);
                _monto_cobrar_salientes = _coordinacion.calcularResumenFacturacionSalientes(cliente, empresa, fechai, fechaf);
                _monto_cobrar_sucursales = _coordinacion.calcularResumenFacturacionSucursales(cliente, empresa, fechai, fechaf);
                _monto_cobrar_procesamiento = _coordinacion.calcularResumenFacturacionProcesamiento(cliente, empresa, fechai, fechaf);
                _penalidades = _coordinacion.calcularCreditosFacturacionTransportadora(cliente, empresa, fechai, fechaf);

                FacturacionTransportadora facturacion = _coordinacion.obtenerResumenTransportadora(cliente, empresa, fechai, fechaf);

                if (facturacion != null)
                {
                    foreach (CategoriaFacturacionTransportadora c in facturacion.ListaCategoria)
                    {
                        if (c.Categoria == CategoriasFacturacion.Cuenta_Corriente_Entrantes && c.Monto == 0 && c.MontoCreditoDebito == 0)
                        {
                            c.Monto = _monto_cobrar;
                            c.MontoCreditoDebito = _penalidades;
                        }
                        if (c.Categoria == CategoriasFacturacion.Cuenta_Corriente_Salientes && c.Monto == 0 && c.MontoCreditoDebito == 0)
                        {
                            c.Monto = _monto_cobrar_salientes;
                            
                        }
                    }
                }
                else
                {
                    facturacion = new FacturacionTransportadora();
                    facturacion.ListaCategoria = new BindingList<CategoriaFacturacionTransportadora>();
                    facturacion.Cliente = cliente;
                    facturacion.Empresa_encargada = empresa;

                    CategoriaFacturacionTransportadora nueva_cuenta = new CategoriaFacturacionTransportadora();
                    _modelo_cuenta_corriente_entrante = dgvFacturar[clmModelo.Index, 0].Value.ToString();
                    _cc_cuenta_corriente_entrante = dgvFacturar[clmCC.Index, 0].Value.ToString();
                    _factura_cuenta_corriente_entrante = dgvFacturar[clmFactura.Index, 0].Value.ToString();



                    CategoriaFacturacionTransportadora categoria_clientes_saliente = new CategoriaFacturacionTransportadora();
                    _modelo_cuenta_corriente_saliente = dgvFacturar[clmModelo.Index, 1].Value.ToString();
                    _cc_cuenta_corriente_saliente = dgvFacturar[clmCC.Index, 1].Value.ToString();
                    _factura_cuenta_corriente_saliente= dgvFacturar[clmFactura.Index, 1].Value.ToString();

                    
                    //Sucursales
                    CategoriaFacturacionTransportadora categoria_sucursales = new CategoriaFacturacionTransportadora();
                    _modelo_sucursales = dgvFacturar[clmModelo.Index, 2].Value.ToString();
                    _cc_sucursales = dgvFacturar[clmCC.Index, 2].Value.ToString();
                    _factura_sucursales = dgvFacturar[clmFactura.Index, 2].Value.ToString();


                    //Procesamiento
                    CategoriaFacturacionTransportadora categoria_procesamiento = new CategoriaFacturacionTransportadora();
                    _modelo_procesamiento = dgvFacturar[clmModelo.Index, 4].Value.ToString();
                    _cc_procesamiento = dgvFacturar[clmCC.Index, 4].Value.ToString();
                    _factura_procesamiento = dgvFacturar[clmFactura.Index, 4].Value.ToString();


                    //Entrate de clientes
                    nueva_cuenta.Modelo = _modelo_cuenta_corriente_entrante;
                    nueva_cuenta.CentroCostos = _cc_cuenta_corriente_entrante;
                    nueva_cuenta.Factura = _factura_cuenta_corriente_entrante;
                    nueva_cuenta.Categoria = CategoriasFacturacion.Cuenta_Corriente_Entrantes;
                    nueva_cuenta.Monto = _monto_cobrar;
                    nueva_cuenta.MontoCreditoDebito = _penalidades * -1;

                    //Saliente de Clientes

                    categoria_clientes_saliente.Modelo = _modelo_cuenta_corriente_saliente;
                    categoria_clientes_saliente.CentroCostos = _cc_cuenta_corriente_saliente;
                    categoria_clientes_saliente.Factura = _factura_cuenta_corriente_saliente;
                    categoria_clientes_saliente.Categoria = CategoriasFacturacion.Cuenta_Corriente_Salientes;
                    categoria_clientes_saliente.Monto = _monto_cobrar_salientes;
                    categoria_clientes_saliente.MontoCreditoDebito = 0;


                    //Sucursales

                    categoria_sucursales.Modelo = _modelo_sucursales;
                    categoria_sucursales.CentroCostos = _cc_sucursales;
                    categoria_sucursales.Factura = _factura_sucursales;
                    categoria_sucursales.Categoria = CategoriasFacturacion.Sucursales;
                    categoria_sucursales.Monto = _monto_sucursales;
                    categoria_sucursales.MontoCreditoDebito = 0;


                    //Procesamiento

                    categoria_procesamiento.Modelo = _modelo_procesamiento;
                    categoria_procesamiento.CentroCostos = _cc_procesamiento;
                    categoria_procesamiento.Factura = _factura_procesamiento;
                    categoria_procesamiento.Categoria = CategoriasFacturacion.Procesamiento;
                    categoria_procesamiento.Monto = _monto_procesamiento;
                    categoria_procesamiento.MontoCreditoDebito = 0;



                    facturacion.ListaCategoria.Add(nueva_cuenta);
                    facturacion.ListaCategoria.Add(categoria_clientes_saliente);
                    facturacion.ListaCategoria.Add(categoria_sucursales);
                    facturacion.ListaCategoria.Add(categoria_procesamiento);

                }

                llenarDatos(facturacion);

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }




        /// <summary>
        /// Exporta el reporte del resumen de facturación
        /// </summary>
        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {



                Cliente cliente = cboCliente.SelectedIndex == 0 ?
                  null : (Cliente)cboCliente.SelectedItem;


                EmpresaTransporte transportadora = cboTransportadora.SelectedIndex == 0 ?
               null : (EmpresaTransporte)cboTransportadora.SelectedItem;

                string observ = txtObservaciones.Text;
                DateTime fecha_inicio = dtpFecha.Value;
                DateTime fecha_fin = dtpFechaFin.Value;
                FacturacionTransportadora facturacion = new FacturacionTransportadora();


                BindingList<CategoriaFacturacionTransportadora> lista = new BindingList<CategoriaFacturacionTransportadora>();

                // Carga los datos de la tabla

                CategoriaFacturacionTransportadora cuenta_corriente_entrante = new CategoriaFacturacionTransportadora(monto: _monto_cuenta_corriente_entrante, creditosdebitos: _creditosdebitos_cuenta_corriente_entrante, centro_costos: _cc_cuenta_corriente_entrante,
                    factura: _factura_cuenta_corriente_entrante, categoria: CategoriasFacturacion.Cuenta_Corriente_Entrantes, modelo: _modelo_cuenta_corriente_entrante);

                CategoriaFacturacionTransportadora cuenta_corriente_saliente = new CategoriaFacturacionTransportadora(monto: _monto_cuenta_corriente_saliente, creditosdebitos: _creditosdebitos_cuenta_corriente_saliente, centro_costos: _cc_cuenta_corriente_saliente,
                    factura: _factura_cuenta_corriente_saliente, categoria: CategoriasFacturacion.Cuenta_Corriente_Salientes, modelo: _modelo_cuenta_corriente_saliente);

                CategoriaFacturacionTransportadora sucursales = new CategoriaFacturacionTransportadora(monto: _monto_sucursales, creditosdebitos: _creditosdebitos_sucursales, centro_costos: _cc_sucursales, factura: _factura_sucursales, categoria: CategoriasFacturacion.Sucursales, modelo: _modelo_sucursales);

                CategoriaFacturacionTransportadora material_operativo = new CategoriaFacturacionTransportadora(monto: _monto_material_operativo, creditosdebitos: _creditosdebitos_material_operativo, centro_costos: _cc_material_operativo, factura: _factura_material_operativo, categoria: CategoriasFacturacion.Material_Operativo, modelo: _modelo_material_operativo);

                CategoriaFacturacionTransportadora procesamiento = new CategoriaFacturacionTransportadora(monto: _monto_procesamiento, creditosdebitos: _creditosdebitos_procesamiento, centro_costos: _cc_procesamiento, factura: _factura_procesamiento, categoria: CategoriasFacturacion.Procesamiento, modelo: _modelo_procesamiento);

                CategoriaFacturacionTransportadora servicios_especiales = new CategoriaFacturacionTransportadora(monto: _monto_servicios_especiales, creditosdebitos: _creditosdebitos_servicios_especiales, centro_costos: _cc_servicios_especiales,
                    factura: _factura_servicios_especiales, categoria: CategoriasFacturacion.Servicios_Especiales, modelo: _modelo_servicios_especiales);


                CategoriaFacturacionTransportadora eticket = new CategoriaFacturacionTransportadora(monto: _monto_eticket, creditosdebitos: _creditosdebitos_eticket, centro_costos: _cc_eticket,
                    factura: _factura_eticket, categoria: CategoriasFacturacion.Eticket, modelo: _modelo_eticket);


                lista.Add(cuenta_corriente_entrante);
                lista.Add(cuenta_corriente_saliente);
                lista.Add(sucursales);
                lista.Add(material_operativo);
                lista.Add(procesamiento);
                lista.Add(servicios_especiales);
                lista.Add(eticket);


                DocumentoExcel documento = new DocumentoExcel(Application.StartupPath + "\\Plantillas\\plantilla_resumen_facturacion.xlt", true);

                documento.seleccionarHoja(1);

                // Escribir los datos

                documento.seleccionarCelda("J2");
                documento.actualizarValorCelda("Resumen para Pago" + Mes[dtpFechaFin.Value.Month - 1] + " " + dtpFechaFin.Value.Year.ToString() + "pagado en " + Mes[dtpFechaFin.Value.Month]  +" " + dtpFechaFin.Value.Year.ToString());

                documento.seleccionarCelda("M4");
                documento.actualizarValorCelda(cuenta_corriente_entrante.Factura);

                documento.seleccionarCelda("N4");
                documento.actualizarValorCelda(cuenta_corriente_entrante.Monto.ToString("N0"));

                documento.seleccionarCelda("O4");
                documento.actualizarValorCelda(cuenta_corriente_entrante.MontoCreditoDebito.ToString("N0"));

                documento.seleccionarCelda("M5");
                documento.actualizarValorCelda(cuenta_corriente_saliente.Factura);

                documento.seleccionarCelda("N5");
                documento.actualizarValorCelda(cuenta_corriente_saliente.Monto.ToString("N0"));

                documento.seleccionarCelda("O5");
                documento.actualizarValorCelda(cuenta_corriente_saliente.MontoCreditoDebito.ToString("N0"));

                documento.seleccionarCelda("M6");
                documento.actualizarValorCelda(sucursales.Factura);

                documento.seleccionarCelda("N6");
                documento.actualizarValorCelda(sucursales.Monto.ToString("N0"));

                documento.seleccionarCelda("O6");
                documento.actualizarValorCelda(sucursales.MontoCreditoDebito.ToString("N0"));

                documento.seleccionarCelda("M7");
                documento.actualizarValorCelda(material_operativo.Factura);

                documento.seleccionarCelda("N7");
                documento.actualizarValorCelda(material_operativo.Monto.ToString("N0"));

                documento.seleccionarCelda("O7");
                documento.actualizarValorCelda(material_operativo.MontoCreditoDebito.ToString("N0"));

                documento.seleccionarCelda("M8");
                documento.actualizarValorCelda(procesamiento.Factura);

                documento.seleccionarCelda("N8");
                documento.actualizarValorCelda(procesamiento.Monto.ToString("N0"));

                documento.seleccionarCelda("O8");
                documento.actualizarValorCelda(procesamiento.MontoCreditoDebito.ToString("N0"));

                documento.seleccionarCelda("M9");
                documento.actualizarValorCelda(servicios_especiales.Factura);

                documento.seleccionarCelda("N9");
                documento.actualizarValorCelda(servicios_especiales.Monto.ToString("N0"));

                documento.seleccionarCelda("O9");
                documento.actualizarValorCelda(servicios_especiales.MontoCreditoDebito.ToString("N0"));

                documento.seleccionarCelda("J15");
                documento.actualizarValorCelda("Hecho por "+_usuario.ToString());

              
                // Mostrar el archivo

                documento.mostrar();
                documento.cerrar();
            }
            catch (Exception)
            {
                Excepcion.mostrarMensaje("ErrorExcel");
            }

        }

        #endregion Eventos

        #region Metodos Privados


        /// <summary>
        /// Crear las filas de los DataGridView's.
        /// </summary>
        private void crearTabla(DataGridView tabla)
        {
            tabla.Rows.Add("Cuenta Corriente (Entrantes)", "650033", "173BAC", string.Empty, 0, 0);
            tabla.Rows.Add("Cuenta Corriente (Salientes)", "650033", "173BAC", string.Empty, 0, 0);
            tabla.Rows.Add("Sucursales", "650032", "DETALLE", string.Empty, 0, 0);
            tabla.Rows.Add("Material Operativo", "650033", "173BAC", string.Empty, 0, 0);
            tabla.Rows.Add("Procesamiento", "650032", "154BAC", string.Empty, 0, 0);
            tabla.Rows.Add("Servicios Especiales", "", "", string.Empty, 0, 0);
            tabla.Rows.Add("Eticket", "", "", string.Empty, 0, 0);
            tabla.Rows.Add(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);
            tabla.Rows.Add("SubTotal", string.Empty, string.Empty, string.Empty, 0, 0);
            tabla.Rows.Add(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);
            tabla.Rows.Add("Total", string.Empty, string.Empty, string.Empty, 0, 0);


            this.protegerCeldas(tabla);
        }




        /// <summary>
        /// Proteger las celdas para evitar su edición.
        /// </summary>
        private void protegerCeldas(DataGridView tabla)
        {
            
            this.formatoCeldaSoloLecturaColumna(tabla, clmDescripcion.Index, 0, 1, 2, 3, 4, 5, 6);


            this.formatoCeldaSeparador(tabla, 7);

            this.formatoCeldaSeparador(tabla, 9);

            //this.formatoCeldaSoloLecturaColumna(tabla, MontoColones.Index, 30);
            //this.formatoCeldaSoloLecturaColumna(tabla, MontoDolares.Index, 31);

           this.formatoCeldaFormato(tabla, clmMonto.Index, "N0", 0, 1, 2, 3, 4, 5, 6);

           this.formatoCeldaSoloLectura(tabla, 8);
           this.formatoCeldaSoloLectura(tabla, 10);
        }

        /// <summary>
        /// Dar formato de solo lectura a las filas que lo requieran.
        /// </summary>
        private void formatoCeldaSoloLectura(DataGridView tabla, params int[] filas)
        {

            foreach (int fila in filas)
            {
                tabla.Rows[fila].ReadOnly = true;
                tabla.Rows[fila].DefaultCellStyle.BackColor = clmDescripcion.DefaultCellStyle.BackColor;
            }

        }

        /// <summary>
        /// Dar formato  de solo lectura a las filas que lo requieran.
        /// </summary>
        private void formatoCeldaSoloLecturaColumna(DataGridView tabla, int columna, params int[] filas)
        {

            foreach (int fila in filas)
            {
                tabla[columna, fila].ReadOnly = true;
                tabla[columna, fila].Style.BackColor = clmDescripcion.DefaultCellStyle.BackColor;
            }

        }

        /// <summary>
        /// Dar formato a las celdas que lo requieran.
        /// </summary>
        private void formatoCeldaFormato(DataGridView tabla, int columna, string formato, params int[] filas)
        {

            foreach (int fila in filas) tabla[columna, fila].Style.Format = "N0";

        }

        /// <summary>
        /// Dar formato a las celdas que son separadoras.
        /// </summary>
        private void formatoCeldaSeparador(DataGridView tabla, params int[] filas)
        {

            foreach (int fila in filas)
            {
                tabla.Rows[fila].ReadOnly = true;
                tabla.Rows[fila].DefaultCellStyle.BackColor = tabla.GridColor;
            }

        }


     

        /// <summary>
        /// Metodo que valida que no se digiten numeros
        /// </summary>
        private void txtNumeroA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar) < 48 && e.KeyChar != 8 && e.KeyChar != 44) || e.KeyChar > 57)
            {
                MessageBox.Show("Sólo se permiten Números");
                e.Handled = true;
            }
        }


        /// <summary>
        /// Llena los datos de la Facturacion en la tabla
        /// </summary>
        /// <param name="f">Objeto Facturacion con los datos a pintar</param>
        private void llenarDatos(FacturacionTransportadora f)
        {

            if (f.Cliente != null)
                cboCliente.Text = f.Cliente.ToString();
            else
                cboCliente.SelectedIndex = 0;

            if (f.Empresa_encargada != null)
                cboTransportadora.Text = f.Empresa_encargada.ToString();
            else
                cboTransportadora.SelectedIndex = 0;

           
            txtObservaciones.Text = f.Observaciones;

            foreach (CategoriaFacturacionTransportadora c in f.ListaCategoria)
            {
                switch (c.Categoria){

                    case CategoriasFacturacion.Cuenta_Corriente_Entrantes:

                        dgvFacturar[1, 0].Value = c.Modelo;
                        dgvFacturar[2, 0].Value = c.CentroCostos;
                        dgvFacturar[3, 0].Value = c.Factura;
                        dgvFacturar[4, 0].Value = c.Monto;
                        dgvFacturar[5,0].Value = c.MontoCreditoDebito;
  
                    break;

                    case(CategoriasFacturacion.Cuenta_Corriente_Salientes):

                        dgvFacturar[1, 1].Value = c.Modelo;
                        dgvFacturar[2, 1].Value = c.CentroCostos;
                        dgvFacturar[3, 1].Value = c.Factura;
                        dgvFacturar[4, 1].Value = c.Monto;
                        dgvFacturar[5, 1].Value = c.MontoCreditoDebito;

                    break;

                    case (CategoriasFacturacion.Sucursales):

                    dgvFacturar[1, 2].Value = c.Modelo;
                    dgvFacturar[2, 2].Value = c.CentroCostos;
                    dgvFacturar[3, 2].Value = c.Factura;
                    dgvFacturar[4, 2].Value = c.Monto;
                    dgvFacturar[5, 2].Value = c.MontoCreditoDebito;

                    break;



                    case (CategoriasFacturacion.Material_Operativo):

                    dgvFacturar[1, 3].Value = c.Modelo;
                    dgvFacturar[2, 3].Value = c.CentroCostos;
                    dgvFacturar[3, 3].Value = c.Factura;
                    dgvFacturar[4, 3].Value = c.Monto;
                    dgvFacturar[5, 3].Value = c.MontoCreditoDebito;

                    break;



                    case (CategoriasFacturacion.Procesamiento):

                    dgvFacturar[1, 4].Value = c.Modelo;
                    dgvFacturar[2, 4].Value = c.CentroCostos;
                    dgvFacturar[3, 4].Value = c.Factura;
                    dgvFacturar[4, 4].Value = c.Monto;
                    dgvFacturar[5, 4].Value = c.MontoCreditoDebito;

                    break;

                    case (CategoriasFacturacion.Servicios_Especiales):

                    dgvFacturar[1, 5].Value = c.Modelo;
                    dgvFacturar[2, 5].Value = c.CentroCostos;
                    dgvFacturar[3, 5].Value = c.Factura;
                    dgvFacturar[4, 5].Value = c.Monto;
                    dgvFacturar[5, 5].Value = c.MontoCreditoDebito;

                    break;


                    case (CategoriasFacturacion.Eticket):

                    dgvFacturar[1, 6].Value = c.Modelo;
                    dgvFacturar[2, 6].Value = c.CentroCostos;
                    dgvFacturar[3, 6].Value = c.Factura;
                    dgvFacturar[4, 6].Value = c.Monto;
                    dgvFacturar[5, 6].Value = c.MontoCreditoDebito;

                    break;

                }
            }



        }

        #endregion Metodos Privados

        private void gbFiltro_Enter(object sender, EventArgs e)
        {

        }



       

        

    }
}
