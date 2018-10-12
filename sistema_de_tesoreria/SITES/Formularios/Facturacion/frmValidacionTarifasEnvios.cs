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
    public partial class frmValidacionTarifasEnvios : Form
    {
       #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;

        private BindingList<PuntoAtencion> _cargas = new BindingList<PuntoAtencion>();
       
        private Colaborador _colaborador = null;

        private string _archivo = string.Empty;

        private List<int> _filas_incorrectas = new List<int>();

        #endregion Atributos

        #region Contructor

        public frmValidacionTarifasEnvios(Colaborador colaborador)
        {
            InitializeComponent();

            _colaborador = colaborador;
            cboTransportadora.ListaMostrada = _mantenimiento.listarEmpresasTransporte();
            dgvCargas.AutoGenerateColumns = false;
        }

        #endregion Contructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de abrir.
        /// </summary>
        private void btnAbrir_Click(object sender, EventArgs e)
        {

            string nuevo = "";

            try
            {

                if (ofdMontosCargas.ShowDialog() == DialogResult.OK)
                {
                    _archivo = ofdMontosCargas.FileName;

                    this.generarCargas();

                    btnAceptar.Enabled = _cargas.Count > 0 && _filas_incorrectas.Count == 0;
                }
                else
                {
                    _archivo = string.Empty;

                    _cargas.Clear();

                    btnAceptar.Enabled = false;
                }

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
            catch (Exception)
            {
                Excepcion.mostrarMensaje("ErrorCargasGeneracionFormatoArchivo");
            }

            txtArchivo.Text = _archivo;
        }

        /// <summary>
        /// Clic en el botón de aceptar.
        /// </summary>
        private void btnAceptar_Click(object sender, EventArgs e)
        {

            try
            {
                _coordinacion.importarPuntosAtencionFacturacionPedidos(_cargas);
               // DateTime Fecha = new DateTime(2014, 02, 10);

               
                Mensaje.mostrarMensaje("MensajeCargasATMsConfirmacionGeneracion");

                dgvCargas.DataSource = null;

                btnAceptar.Enabled = false;
       
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de revisar.
        /// </summary>
        private void btnRevisar_Click(object sender, EventArgs e)
        {
            this.mostarVentanaModificacion();
        }

        /// <summary>
        /// Clic en el botón de salir.
        /// </summary>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Se selecciona otra carga de la lista de cargas.
        /// </summary>
        private void dgvCargas_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Se presiona doble clic sobre una carga de la lista de cargas.
        /// </summary>
        private void dgvCargas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1) this.mostarVentanaModificacion();
        }


        /// <summary>
        /// Clic en el botón de exportar 
        /// </summary>
        private void btnExportar_Click(object sender, EventArgs e)
        {
            int tipo = cboTipo.SelectedIndex;
            this.exportarCargasGeneradasImportadas(tipo);
        }

        #endregion Eventos

        #region Métodos Privados


        /// <summary>
        /// Exportar los datos de la hoja de cargas importadas y generadas.
        /// </summary>
        private void exportarCargasGeneradasImportadas(int tipo)
        {

            try
            {
                DocumentoExcel documento = new DocumentoExcel(Application.StartupPath + "\\Plantillas\\pantilla niquel transportadora.xlt", true);
                DateTime fecha_inicio = dtpFechaInicio.Value;
                DateTime fecha_fin = dtpFechaFin.Value;
                EmpresaTransporte transportadora = cboTransportadora.SelectedIndex == 0 ? null : (EmpresaTransporte)cboTransportadora.SelectedItem;

  
                DataTable datos = _coordinacion.listarPuntoAtencionPedidos(fecha_inicio, fecha_fin, transportadora, tipo);

                documento.seleccionarHoja(1);



                documento.seleccionarCelda("E1");
                documento.actualizarValorCelda(transportadora == null ? "" : transportadora.ToString());


                documento.seleccionarCelda("H1");
                documento.actualizarValorCelda(transportadora == null ? "" : transportadora.ID.ToString());

                ///Nombres de las cabeceras
                ///
                //for (int contador = 1, numero_columa = 1; contador < datos.Columns.Count; contador++, numero_columa++)
                //{
                //    DataColumn columna = datos.Columns[contador];
                //    string nombre_columna = columna.ColumnName;

                //    //documento.seleccionarCelda(7, numero_columa);

                //    //nombre_columna = nombre_columna.Remove(nombre_columna.Length - 2);

                //    documento.actualizarValorCelda(nombre_columna);
                //}

                documento.seleccionarCelda("A6");
                documento.actualizarValoresTabla(datos);

                documento.mostrar();
                documento.cerrar();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        /// <summary>
        /// Mostrar la ventana de modificación.
        /// </summary>
        public void mostarVentanaModificacion()
        {
            DataGridViewRow fila = dgvCargas.SelectedCells[0].OwningRow;
            CargaATM carga = (CargaATM)fila.DataBoundItem;
            frmModificacionCarga formulario = new frmModificacionCarga(carga, _colaborador, false);

            formulario.ShowDialog(this);


            btnAceptar.Enabled = _cargas.Count > 0 && _filas_incorrectas.Count == 0;
        }

        /// <summary>
        /// Mostrar el error en los datos de una carga.
        /// </summary>
        private void mostrarError(DataGridViewColumn columna, DataGridViewRow fila, Color color)
        {
            fila.Cells[columna.Index].Style.BackColor = color;
            _filas_incorrectas.Add(fila.Index);
        }

        /// <summary>
        /// Leer los montos del archivo y generar las cargas.
        /// </summary>
        private void generarCargas()
        {
            DocumentoExcel archivo = null;

            try
            {
                _filas_incorrectas.Clear();

                _cargas.Clear();
                
                archivo = new DocumentoExcel(_archivo, false);

                archivo.seleccionarHoja(1);

                Celda celda_fecha = archivo.seleccionarCelda(mtbCeldaFecha.Text);
                Celda celda_id_bac = archivo.seleccionarCelda(mtbIDBac.Text);
                Celda celda_id_pedido = archivo.seleccionarCelda(mtbIDPedido.Text);
                Celda celda_tipo_cliente = archivo.seleccionarCelda(mtbTipoCliente.Text);
                Celda celda_tipo_servicio= archivo.seleccionarCelda(mtbTipoServicio.Text);
                Celda celda_manifiesto = archivo.seleccionarCelda(mtbManifiesto.Text);
                Celda celda_monto = archivo.seleccionarCelda(mtbCeldaMontoPlanilla.Text);
                Celda celda_monto_excedente = archivo.seleccionarCelda(mtbMontoExcedente.Text);
                Celda celda_tipo_cambio = archivo.seleccionarCelda(mtbTipoCambio.Text);
                Celda celda_tarifa = archivo.seleccionarCelda(mtbTarifa.Text);
                Celda celda_visita_nocturna = archivo.seleccionarCelda(mtbVisitaNocturna.Text);
                Celda celda_visita_compartida = archivo.seleccionarCelda(mtbVisitaCompartida.Text);
                Celda celda_recargo = archivo.seleccionarCelda(mtbRecargo.Text);
                Celda celda_total = archivo.seleccionarCelda(mtbTotal.Text);
                Celda celda_transportadora = archivo.seleccionarCelda(mtbTransportadora.Text);

               
                DateTime fecha = DateTime.Parse(celda_fecha.Texto);

                this.generarCargasMoneda(archivo, celda_fecha,celda_id_bac,celda_id_pedido,celda_tipo_cliente,celda_tipo_servicio, celda_manifiesto,celda_monto, celda_monto_excedente, celda_tipo_cambio,
                    celda_tarifa, celda_visita_nocturna, celda_visita_compartida, celda_recargo, celda_total, celda_transportadora);


                //this.generarCargasMoneda(archivo, Monedas.Dolares, fecha, celda_a, celda_b, celda_atm_a, celda_c, celda_d);

                dgvCargas.DataSource = _cargas;

                archivo.mostrar();
                archivo.cerrar();

               
            }
            catch (Exception ex)
            {
                archivo.mostrar();
                archivo.cerrar();

                throw ex;
            }

        }

       

        /// <summary>
        /// Generar las cargas para una moneda específica.
        /// </summary>
        private void generarCargasMoneda(DocumentoExcel archivo, Celda celda_fecha,Celda celda_id_bac,Celda celda_id_pedido,Celda celda_tipo_cliente,Celda celda_tipo_servicio, Celda celda_manifiesto,Celda celda_monto,Celda celda_monto_excedente,Celda celda_tipo_cambio,
                   Celda celda_tarifa, Celda celda_visita_nocturna, Celda celda_visita_compartida, Celda celda_recargo, Celda celda_total, Celda celda_transportadora)
        {

            try
            {

                // Leer las denominaciones

                string textito = "";
                decimal total_cobrar = 0;
                while (!celda_id_pedido.Valor.Equals(string.Empty))
                {
                    int numero_atm = int.Parse(celda_id_bac.Valor);
                    PuntoAtencion p = new PuntoAtencion();
                    p.TipoPuntodeAtencion = 0;

                    if (celda_tipo_cliente.Valor.Equals("1"))
                    {
                        p.TipoPuntodeAtencion = TipoPuntoAtencion.Cliente;
                    }
                    if (celda_tipo_cliente.Valor.Equals("2"))
                    {
                        p.TipoPuntodeAtencion = TipoPuntoAtencion.Sucursal;
                    }



                    if (p.TipoPuntodeAtencion != 0)
                    {
                        p.IDSites = numero_atm;

                        if (p.TipoPuntodeAtencion == TipoPuntoAtencion.Sucursal)
                        {
                            _mantenimiento.obtenerDatosSucursalPuntoAtencion(ref p);
                        }
                        if (p.TipoPuntodeAtencion == TipoPuntoAtencion.Cliente)
                        {
                            _mantenimiento.obtenerDatosClientePuntoAtencion(ref p);
                        }



                        DateTime fecha_planilla = DateTime.Parse(celda_fecha.Texto);

                        //textito = tarifa.Texto.Substring(0, 1);

                        DateTime fecha = Convert.ToDateTime(celda_fecha.Valor);
                        int id_pedido = 0;
                        int id_punto = 0;
                        EntregaRecibo tipo = EntregaRecibo.Entregas;
                        string planilla = "";
                        decimal monto = 0;
                        decimal monto_excdente = 0;
                        decimal tipo_cambio = 0;
                        decimal tarifa_niquel = 0;
                        bool visita_compartida = false;
                        int visita_nocturna = 0;
                        decimal recargo_final = 0;
                        decimal total = 0;


                        id_pedido = Convert.ToInt32(celda_id_pedido.Valor);
                        id_punto = Convert.ToInt32(celda_id_bac.Valor);

                        if (celda_tipo_servicio.Valor.Equals("Envío"))
                        {
                            tipo = EntregaRecibo.Entregas;
                        }
                        if (celda_tipo_servicio.Valor.Equals("Pedido"))
                        {
                            tipo = EntregaRecibo.Pedidos;
                        }
                       // tipo = (EntregaRecibo)Convert.ToInt32(celda_tipo_servicio.Valor);
                        planilla = celda_manifiesto.Valor;
                        monto = Convert.ToDecimal(celda_monto.Valor);
                        monto_excdente = Convert.ToDecimal(celda_monto_excedente.Valor);
                        tipo_cambio = Convert.ToDecimal(celda_tipo_cambio.Valor);
                        tarifa_niquel = Convert.ToDecimal(celda_tarifa.Valor);

                        if (celda_visita_compartida.Valor.Equals("SI"))
                        {
                            visita_compartida = true;
                        }
                        if (celda_tipo_cliente.Valor.Equals("NO"))
                        {
                            visita_compartida = false; 
                        }

                        decimal visita_nocturas = Convert.ToDecimal(celda_visita_nocturna.Valor);
                        visita_nocturna = Convert.ToInt32(visita_nocturas * 100);
                        recargo_final = Convert.ToDecimal(celda_recargo.Valor);
                        total = Convert.ToDecimal(celda_total.Valor);
                        

                        short id_transportadora = Convert.ToInt16(celda_transportadora.Valor);


                        EmpresaTransporte transportadora = new EmpresaTransporte(id: (byte)id_transportadora);

                        PuntoAtencion carga = p;
                        carga.FechaPlanilla = fecha_planilla;
                        carga.IDSites = id_punto;
                        carga.IDPedido = id_pedido;
                        carga.EntregaRecibo = tipo;
                        carga.Manifiesto = planilla;
                        carga.MontoPlanilla = monto;
                        carga.MontoExcedente = monto_excdente;
                        carga.TipoCambio = tipo_cambio;
                        carga.TarifaRegular = tarifa_niquel;
                        carga.Recargo = recargo_final;
                        carga.VisitaCompartida = visita_compartida;
                        carga.VisitaNocturna = visita_nocturna;
                        carga.TotalCobrar = total;
                        carga.Transportadora = transportadora;
                        carga.TipoPuntodeAtencion = p.TipoPuntodeAtencion;

                        if (carga.VisitaCompartida)
                            carga.TotalCobrar = carga.TotalCobrar / 2;

                        decimal auxiliar = (carga.TotalCobrar * visita_nocturna) / 100;

                         carga.TotalCobrar = carga.TotalCobrar + auxiliar;

                        _cargas.Add(carga);


                    }


                    celda_fecha = archivo.seleccionarCelda(celda_fecha.Fila + 1, celda_fecha.Columna);
                    celda_id_bac = archivo.seleccionarCelda(celda_id_bac.Fila + 1, celda_id_bac.Columna);
                    celda_id_pedido = archivo.seleccionarCelda(celda_id_pedido.Fila + 1, celda_id_pedido.Columna);
                    celda_tipo_cliente = archivo.seleccionarCelda(celda_tipo_cliente.Fila + 1, celda_tipo_cliente.Columna);
                    celda_tipo_servicio = archivo.seleccionarCelda(celda_tipo_servicio.Fila + 1, celda_tipo_servicio.Columna);
                    celda_manifiesto = archivo.seleccionarCelda(celda_manifiesto.Fila + 1, celda_manifiesto.Columna);
                    celda_monto = archivo.seleccionarCelda(celda_monto.Fila + 1, celda_monto.Columna);
                    celda_monto_excedente = archivo.seleccionarCelda(celda_monto_excedente.Fila + 1, celda_monto_excedente.Columna);
                    celda_tipo_cambio = archivo.seleccionarCelda(celda_tipo_cambio.Fila + 1, celda_tipo_cambio.Columna);
                    celda_tarifa = archivo.seleccionarCelda(celda_tarifa.Fila + 1, celda_tarifa.Columna);
                    celda_visita_compartida = archivo.seleccionarCelda(celda_visita_compartida.Fila + 1, celda_visita_compartida.Columna);
                    celda_visita_nocturna = archivo.seleccionarCelda(celda_visita_nocturna.Fila + 1, celda_visita_nocturna.Columna);
                    celda_recargo = archivo.seleccionarCelda(celda_recargo.Fila + 1, celda_recargo.Columna);
                    celda_total = archivo.seleccionarCelda(celda_total.Fila + 1, celda_total.Columna);



                }
            }
            catch (Exception ex)
            {
                int i = 0;
            }

            dgvCargas.DataSource = _cargas;

        }



      
       

        #endregion Métodos Privados


        
    }
}
