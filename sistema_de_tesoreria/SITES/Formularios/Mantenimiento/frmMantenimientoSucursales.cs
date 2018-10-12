//
//  @ Project : 
//  @ File Name : frmMantenimientoSucursales.cs
//  @ Date : 30/04/2012
//  @ Author : Erick Chavarría 
//

using System;
using System.Windows.Forms;

using CommonObjects;
using BussinessLayer;
using LibreriaMensajes;
using CommonObjects.Clases;
using System.ComponentModel;
using LibreriaReportesOffice;

namespace GUILayer
{

    public partial class frmMantenimientoSucursales : Form
    {

        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private string _archivo = string.Empty;
        private BindingList<TarifaPuntoVentaTransportadora> _tarifas = new BindingList<TarifaPuntoVentaTransportadora>();
        private Sucursal _sucursal = new Sucursal();

        #endregion Atributos

        #region Constructor

        public frmMantenimientoSucursales()
        {
            InitializeComponent();

            cboProvincias.SelectedIndex = 0;
            cboTransportadora.ListaMostrada = _mantenimiento.listarEmpresasTransporte();
            cboTransportadoraTarifa.ListaMostrada = _mantenimiento.listarEmpresasTransporte();
        }

        public frmMantenimientoSucursales(Sucursal sucursal)
        {
            InitializeComponent();

            _sucursal = sucursal;

            txtNombre.Text = _sucursal.Nombre;
            txtDireccion.Text = _sucursal.Direccion;
            cboProvincias.SelectedIndex = (byte)_sucursal.Provincia;
            cboTipo.SelectedIndex = (byte)_sucursal.TipoSucursal;
            cboTransportadora.ListaMostrada = _mantenimiento.listarEmpresasTransporte();
            cboTransportadoraTarifa.ListaMostrada = _mantenimiento.listarEmpresasTransporte();
            dgvTarifasTransportadora.AutoGenerateColumns = false;

            if (sucursal.Tarifas == null)
                sucursal.Tarifas = new BindingList<TarifaPuntoVentaTransportadora>();
            dgvTarifasTransportadora.DataSource = _sucursal.Tarifas;

            
            cboTransportadora.SelectedItem = _sucursal.Empresa;
            mtbNumero.Text = _sucursal.Codigo.ToString();
            chkExterno.Checked = _sucursal.Externo;
            mtbNumero.Enabled = false;
            chkCajaEmpresarial.Checked = _sucursal.CajaEmpresarial;
            foreach (Dias dia in _sucursal.Dias_carga)
                clbDiasCarga.SetItemChecked((byte)dia - 1, true);

            

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
                Excepcion.mostrarMensaje("ErrorSucursalDatosRegistro");
                return;
            }

            try
            {
                string nombre = txtNombre.Text;
                string direccion = txtDireccion.Text;
                short numero = short.Parse(mtbNumero.Text);
                bool externo = chkExterno.Checked;
                Provincias provincia = (Provincias)cboProvincias.SelectedIndex;
                TipoSucursal sucursal = (TipoSucursal)cboTipo.SelectedIndex;
                EmpresaTransporte empresa = (EmpresaTransporte)cboTransportadora.SelectedItem;
                bool caja = chkCajaEmpresarial.Checked;
                BindingList<TarifaPuntoVentaTransportadora> tarifas = (BindingList<TarifaPuntoVentaTransportadora>)dgvTarifasTransportadora.DataSource;

                frmAdministracionSucursales padre = (frmAdministracionSucursales)this.Owner;

                // Verificar si la sucursal ya está registrada

                if (_sucursal.ID == 0)
                {
                    // Agregar los datos de la sucursal

                    if (Mensaje.mostrarMensajeConfirmacion("MensajeSucursalRegistro") == DialogResult.Yes)
                    {
                        Sucursal nueva = new Sucursal(nombre, direccion: direccion, provincia: provincia,sucursal:sucursal,codigo:numero,transporte:empresa,externo:externo, caja:caja);
                        nueva.Tarifas = tarifas;

                        foreach (int dia in clbDiasCarga.CheckedIndices)
                            nueva.agregarDiaCarga((Dias)dia + 1);

                        _mantenimiento.agregarSucursal(ref nueva);

                        padre.agregarSucursal(nueva);
                        Mensaje.mostrarMensaje("MensajeSucursalConfirmacionRegistro");
                        this.Close();
                    }

                }
                else
                {
                    // Actualizar los datos de la sucursal

                    Sucursal copia = new Sucursal(nombre, direccion: direccion, provincia: provincia, sucursal: sucursal, codigo: numero, transporte: empresa, externo: externo, caja:caja);

                    copia.Tarifas = tarifas;

                    foreach (int dia in clbDiasCarga.CheckedIndices)
                        copia.agregarDiaCarga((Dias)dia + 1);


                    _mantenimiento.actualizarSucursal(copia);

                    _sucursal.Nombre = nombre;
                    _sucursal.Direccion = direccion;
                    _sucursal.Provincia = provincia;
                    _sucursal.Codigo = numero;
                    _sucursal.Empresa = empresa;
                    _sucursal.Externo = externo;
                    _sucursal.TipoSucursal = sucursal;
                    _sucursal.CajaEmpresarial = caja;

                    padre.actualizarLista();
                    Mensaje.mostrarMensaje("MensajeSucursalConfirmacionActualizacion");
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
        /// Agrega una tarifa a la lista
        /// </summary>
        private void btnAgregarTarifaTransportadora_Click(object sender, EventArgs e)
        {
            if (cboTransportadoraTarifa.Text.Equals(string.Empty))
                return;



          //  Sucursal punto = _sucursal;
            EmpresaTransporte transportadora = (EmpresaTransporte)cboTransportadoraTarifa.SelectedItem;
            Decimal regular = nudTarifaRegularTransportadora.Value;
            Decimal feriado = nudTarifaFeriadosTransportadora.Value;
            Decimal tope = nudTopeTransportadora.Value;
            Decimal recargo = nudRecargoTransportadora.Value;
            Monedas moneda_tarifa_regular = (Monedas)cboMonedaTarifaRegularTransportadora.SelectedIndex;
            Monedas moneda_tarifa_feriado = (Monedas)cboMonedaFeriadoTransportadora.SelectedIndex;
            Monedas moneda_tope = (Monedas)cboMonedaTopeTransportadora.SelectedIndex;
            Monedas moneda_recargo = (Monedas)cboMonedaRecargoTransportadora.SelectedIndex;



            TarifaPuntoVentaTransportadora tarifas_transportadora = new TarifaPuntoVentaTransportadora(transportadora: transportadora, sucursal: _sucursal,
                tarifaregular: regular, tarifaferiados: feriado, tope: tope, recargo: recargo, moneda_feriado: moneda_tarifa_feriado);

            BindingList<TarifaPuntoVentaTransportadora> nombres = (BindingList<TarifaPuntoVentaTransportadora>)dgvTarifasTransportadora.DataSource;


            if (nombres == null)
                nombres = new BindingList<TarifaPuntoVentaTransportadora>();
            nombres.Add(tarifas_transportadora);

            _sucursal.Tarifas = new BindingList<TarifaPuntoVentaTransportadora>();
            _sucursal.Tarifas = nombres;
            //_sucursal.agregarTarifa(tarifas_transportadora);

            dgvTarifasTransportadora.AutoGenerateColumns = false;
            dgvTarifasTransportadora.DataSource = null;
            dgvTarifasTransportadora.DataSource = _sucursal.Tarifas;
            dgvTarifasTransportadora.Refresh();
            dgvTarifasTransportadora.AutoResizeColumns();
        }


        /// <summary>
        /// Quitar tarifa de la sucursal seleccionada. 
        /// </summary>
        private void btnQuitarTarifaTransportadora_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvTarifasTransportadora.SelectedRows.Count > 0)
                {
                    Sucursal punto = _sucursal;

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
        /// Clic en el botón de Carga de Archivo
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
        /// Clic en el botón de importar tarifas
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

                            if (_mantenimiento.validarTarifaSucursal(ref copia))
                            {
                                _mantenimiento.actualizarTarifaSucursalImportacion(ref copia);

                            }
                            else
                            {
                                _mantenimiento.agregarTarifaSucursalImportacion(ref copia);
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


        /// <summary>
        /// Cambio en la tabla de tarifas
        /// </summary>
        private void dgvTarifasTransportadora_SelectionChanged(object sender, EventArgs e)
        {
            btnQuitarTarifaTransportadora.Enabled = dgvTarifasTransportadora.SelectedRows.Count > 0;
        }

       
        #endregion Eventos

        #region Métodos Públicos

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

                archivo.seleccionarHoja(1);

                Celda celda_id_punto = archivo.seleccionarCelda("A2");
                Celda celda_id_transportadora = archivo.seleccionarCelda("C2");
                Celda celda_tarifa_regular = archivo.seleccionarCelda("E2");
                Celda celda_tarifa_feriado = archivo.seleccionarCelda("G2");
                Celda celda_recargo = archivo.seleccionarCelda("I2");
                Celda celda_tope = archivo.seleccionarCelda("K2");
                Celda celda_moneda_regular = archivo.seleccionarCelda("F2");
                Celda celda_moneda_feriado = archivo.seleccionarCelda("H2");
                Celda celda_moneda_recargo = archivo.seleccionarCelda("J2");
                Celda celda_moneda_tope = archivo.seleccionarCelda("L2");
  




                this.generarTarifasTransportadoraDatos(archivo, celda_tarifa_regular, celda_tarifa_feriado, celda_recargo, celda_tope, 
                    celda_moneda_regular, celda_moneda_feriado, celda_moneda_recargo, celda_moneda_tope, celda_id_punto, celda_id_transportadora);



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
            Celda celda_tope, Celda celda_monedaregular, Celda celda_monedaferiado, Celda celda_monedarecargo, Celda celda_monedatope,
           Celda celda_id_punto, Celda celda_id_transportadora)
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
                        Monedas moneda_tarifa_regular = (Monedas)Convert.ToByte(celda_monedaregular.Valor);
                        Monedas moneda_tarifa_feriado = (Monedas)Convert.ToByte(celda_monedaferiado.Valor);
                        Monedas moneda_tope = (Monedas)Convert.ToByte(celda_monedatope.Valor);
                        Monedas moneda_recargo = (Monedas)Convert.ToByte(celda_monedarecargo.Valor);


                        byte transportadora = Convert.ToByte(celda_id_transportadora.Valor);

                        Sucursal p = new CommonObjects.Sucursal(codigo:numero_punto);

                        _mantenimiento.obtenerDatosSucursal(ref p);


                        EmpresaTransporte empresa = new EmpresaTransporte(id: transportadora);



                        TarifaPuntoVentaTransportadora punto = new TarifaPuntoVentaTransportadora();
                        punto.Sucursal = p;
                        punto.EmpresaTransporte = empresa;
                        punto.MonedaRecargo = moneda_recargo;
                        punto.MonedaTarifaFeriado = moneda_tarifa_feriado;
                        punto.MonedaTarifaRegular = moneda_tarifa_regular;
                        punto.MonedaTope = moneda_tope;
                        punto.TarifaFeriados = tarifa_feriado;
                        punto.TarifaRegular = tarifa_regular;
                        punto.Recargo = recargo;
                        punto.Tope = tope;

                        _tarifas.Add(punto);

                        celda_id_punto = archivo.seleccionarCelda(celda_id_punto.Fila + 1, celda_id_punto.Columna);
                        celda_tarifa_regular = archivo.seleccionarCelda(celda_tarifa_regular.Fila + 1, celda_tarifa_regular.Columna);
                        celda_tarifa_feriado = archivo.seleccionarCelda(celda_tarifa_feriado.Fila + 1, celda_tarifa_feriado.Columna);
                        celda_recargo = archivo.seleccionarCelda(celda_recargo.Fila + 1, celda_recargo.Columna);
                        celda_tope = archivo.seleccionarCelda(celda_tope.Fila + 1, celda_tope.Columna);
                        celda_monedaregular = archivo.seleccionarCelda(celda_monedaregular.Fila + 1, celda_monedaregular.Columna);
                        celda_monedaferiado = archivo.seleccionarCelda(celda_monedaferiado.Fila + 1, celda_monedaferiado.Columna);
                        celda_monedarecargo = archivo.seleccionarCelda(celda_monedarecargo.Fila + 1, celda_monedarecargo.Columna);
                        celda_monedatope = archivo.seleccionarCelda(celda_monedatope.Fila + 1, celda_monedatope.Columna);
                        celda_id_transportadora = archivo.seleccionarCelda(celda_id_transportadora.Fila + 1, celda_id_transportadora.Columna);
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

        #endregion Métodos Públicos


      
       

    }

}
