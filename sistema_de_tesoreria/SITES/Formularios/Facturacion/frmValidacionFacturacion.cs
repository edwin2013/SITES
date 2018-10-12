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
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GUILayer.Formularios.Facturacion
{
    public partial class frmValidacionFacturacion : Form
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

        public frmValidacionFacturacion(Colaborador colaborador)
        {
            InitializeComponent();

            _colaborador = colaborador;

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
                _coordinacion.importarPuntosAtencionFacturacion(_cargas);
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

        #endregion Eventos

        #region Métodos Privados

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

                Celda celda_a = archivo.seleccionarCelda(mtbIDBac.Text);
                Celda celda_b = archivo.seleccionarCelda(mtbTipoPunto.Text);
                Celda celda_atm_a = archivo.seleccionarCelda(mtbManifiesto.Text);

                Celda celda_c = archivo.seleccionarCelda(mtbCeldaTarifa.Text);
                Celda celda_d = archivo.seleccionarCelda(mtbCeldaRecargo.Text);
                //Celda celda_atm_b = archivo.seleccionarCelda(mtbCeldaATMB.Text);

                Celda celda_monto_planilla = archivo.seleccionarCelda(mtbCeldaMontoPlanilla.Text);
                Celda celda_tula = archivo.seleccionarCelda(mtbCeldaTula.Text);
                Celda celda_total = archivo.seleccionarCelda(mtbTotal.Text);
                Celda celda_transportadora = archivo.seleccionarCelda(mtbTransportadora.Text);
                Celda celda_visita_nocturna = archivo.seleccionarCelda(mtbVisitaNocturna.Text);
        

                DateTime fecha = DateTime.Parse(celda_fecha.Texto);


                this.generarCargasMoneda(archivo, Monedas.Colones, celda_fecha, celda_a, celda_b, celda_atm_a, celda_c, celda_d, celda_monto_planilla, celda_tula, celda_total, celda_transportadora,
                    celda_visita_nocturna);


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
        private void generarCargasMoneda(DocumentoExcel archivo, Monedas moneda, Celda celda_fecha,
                                         Celda id_bac, Celda celda_tipopunto, Celda celda_manifiesto, Celda tarifa, Celda Recargo, Celda celda_monto_planilla, Celda celda_tula, Celda celda_total, Celda celda_transportadora,
            Celda visita_nocturna)
        {

            try
            {

                // Leer las denominaciones

                string textito = "";
                decimal tarifas = 0;
                decimal tarifas_feriado = 0;
                decimal recargo = 0;
                decimal monto_planilla = 0;
                decimal total_cobrar = 0;
                while (!id_bac.Valor.Equals(string.Empty))
                {
                    int numero_atm = int.Parse(id_bac.Valor);
                    PuntoAtencion p = new PuntoAtencion();
                    p.TipoPuntodeAtencion = 0;

                    if (celda_tipopunto.Valor.Equals("CLIENTE"))
                    {
                        p.TipoPuntodeAtencion = TipoPuntoAtencion.Cliente;
                    }
                    if (celda_tipopunto.Valor.Equals("CE") || celda_tipopunto.Valor.Equals("SUCURSAL"))
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

                        string manifiesto = celda_manifiesto.Valor;
                        string tula = celda_tula.Valor;
                        tarifas = Convert.ToDecimal(tarifa.Valor);
                        tarifas_feriado = Convert.ToDecimal(tarifa.Valor);
                        recargo = Convert.ToDecimal(Recargo.Valor);
                        monto_planilla = Convert.ToDecimal(celda_monto_planilla.Valor);
                        total_cobrar = Convert.ToDecimal(celda_total.Valor);
                        short id_transportadora = Convert.ToInt16(celda_transportadora.Valor);


                        EmpresaTransporte transportadora = new EmpresaTransporte(id: (byte)id_transportadora);

                        PuntoAtencion carga = p;
                        carga.FechaPlanilla = fecha_planilla;
                        carga.TarifaRegular = tarifas;
                        carga.Recargo = recargo;
                        carga.Manifiesto = manifiesto;
                        carga.IDSites = Convert.ToInt32(id_bac.Valor);
                        carga.Tula = tula;
                        carga.MontoPlanilla = monto_planilla;
                        carga.TotalCobrar = total_cobrar;
                        carga.Transportadora = transportadora;
                        carga.TipoPuntodeAtencion = p.TipoPuntodeAtencion;



                        _cargas.Add(carga);


                       

                    }


                    id_bac = archivo.seleccionarCelda(id_bac.Fila + 1, id_bac.Columna);
                    celda_tipopunto = archivo.seleccionarCelda(celda_tipopunto.Fila + 1, celda_tipopunto.Columna);
                    celda_manifiesto = archivo.seleccionarCelda(celda_manifiesto.Fila + 1, celda_manifiesto.Columna);
                    tarifa = archivo.seleccionarCelda(tarifa.Fila + 1, tarifa.Columna);
                    Recargo = archivo.seleccionarCelda(Recargo.Fila + 1, Recargo.Columna);
                    celda_fecha = archivo.seleccionarCelda(celda_fecha.Fila + 1, celda_fecha.Columna);
                    celda_tula = archivo.seleccionarCelda(celda_tula.Fila + 1, celda_tula.Columna);
                    celda_monto_planilla = archivo.seleccionarCelda(celda_monto_planilla.Fila + 1, celda_monto_planilla.Columna);
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
