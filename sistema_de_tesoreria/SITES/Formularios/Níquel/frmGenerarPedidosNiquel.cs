using BussinessLayer;
using CommonObjects;
using CommonObjects.Clases;
using GUILayer.Formularios.Facturacion;
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

namespace GUILayer.Formularios.Níquel
{
    public partial class frmGenerarPedidosNiquel : Form
    {
        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;

        private BindingList<PedidoNiquel> _cargas = new BindingList<PedidoNiquel>();
        private Dictionary<int, Denominacion> _denominaciones = new Dictionary<int, Denominacion>();

        private Colaborador _colaborador = null;

        private string _archivo = string.Empty;

        private List<int> _filas_incorrectas = new List<int>();

        #endregion Atributos

        #region Contructor

        public frmGenerarPedidosNiquel(Colaborador colaborador)
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
                _coordinacion.importarPedidoNiquel(_cargas);
                DateTime Fecha = new DateTime(2014, 02, 10);

              


                Mensaje.mostrarMensaje("MensajeCargasATMsConfirmacionGeneracion");

                dgvCargas.DataSource = null;

                btnAceptar.Enabled = false;
                btnRevisar.Enabled = false;
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
            btnRevisar.Enabled = dgvCargas.SelectedCells.Count > 0;
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
            PedidoNiquel carga = (PedidoNiquel)fila.DataBoundItem;
            frmModificacionPedidoNiquel formulario = new frmModificacionPedidoNiquel(carga, _colaborador, true);

            formulario.ShowDialog(this);

            this.validarCarga(fila);

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
                _denominaciones.Clear();

                archivo = new DocumentoExcel(_archivo, false);

                archivo.seleccionarHoja(1);

                Celda celda_fecha = archivo.seleccionarCelda(mtbCeldaFecha.Text);

                Celda celda_a = archivo.seleccionarCelda(mtbPrimeraDenColones.Text);
                Celda celda_b = archivo.seleccionarCelda(mtbSegundaDenColones.Text);
                Celda celda_atm_a = archivo.seleccionarCelda(mtbCeldaClienteA.Text);
                Celda celda_atm_transportadora = archivo.seleccionarCelda(mtbCeldaTransportadora.Text);

                Celda celda_c = archivo.seleccionarCelda(mtbPrimeraDenDolaresA.Text);
                Celda celda_d = archivo.seleccionarCelda(mtbSegundaDenDolares.Text);

                
                


                DateTime fecha = DateTime.Parse(celda_fecha.Texto);

                this.generarCargasMoneda(archivo, Monedas.Colones, fecha, celda_a, celda_b, celda_atm_a, celda_atm_transportadora);
                this.generarCargasMoneda(archivo, Monedas.Dolares, fecha, celda_c, celda_d, celda_atm_a, celda_atm_transportadora);
                //this.generarCargasMoneda(archivo, Monedas.Euros, fecha, celda_e, celda_f, celda_atm_a);

                dgvCargas.DataSource = _cargas;

                archivo.mostrar();
                archivo.cerrar();

                // Dar formato a las cargas

                foreach (DataGridViewRow fila in dgvCargas.Rows)
                    this.validarCarga(fila);
            }
            catch (Exception ex)
            {
                archivo.mostrar();
                archivo.cerrar();

                throw ex;
            }

        }

        /// <summary>
        /// Validar una carga.
        /// </summary>
        private void validarCarga(DataGridViewRow fila)
        {
            PedidoNiquel carga = (PedidoNiquel)fila.DataBoundItem;
            PuntoVenta cliente = carga.PuntoVenta;

            _filas_incorrectas.Remove(fila.Index);

          
        }

        /// <summary>
        /// Generar las cargas para una moneda específica.
        /// </summary>
        private void generarCargasMoneda(DocumentoExcel archivo, Monedas moneda, DateTime fecha,
                                         Celda celda_a, Celda celda_b, Celda celda_atm, Celda celda_transportadora)
        {
            // Leer las denominaciones

            this.identificarDenominaciones(archivo, celda_a, celda_b, moneda);

            while (!celda_atm.Valor.Equals(string.Empty))
            {
                short numero_atm = short.Parse(celda_atm.Valor.Substring(0, 4));


                byte numero_transportadora = byte.Parse(celda_transportadora.Valor.Substring(0, 2));

                PuntoVenta cliente = new PuntoVenta(numero_atm);

                EmpresaTransporte empresa = new EmpresaTransporte(id: numero_transportadora);

                _mantenimiento.obtenerDatosPuntoVenta(ref cliente);

                _mantenimiento.obtenerDatosEmpresa(ref empresa);

                PedidoNiquel carga = this.buscarCarga(cliente, fecha, empresa);

                for (int columna = celda_a.Columna; columna <= celda_b.Columna; columna++)
                {
                    Celda celda_monto = archivo.seleccionarCelda(celda_atm.Fila, columna);

                    this.asignarCartuchos(celda_monto, ref carga);
                }

                celda_atm = archivo.seleccionarCelda(celda_atm.Fila + 1, celda_atm.Columna);
                celda_a = archivo.seleccionarCelda(celda_a.Fila + 1, celda_a.Columna);
                celda_b = archivo.seleccionarCelda(celda_b.Fila + 1, celda_b.Columna);
                celda_transportadora = archivo.seleccionarCelda(celda_transportadora.Fila + 1, celda_transportadora.Columna);
            }

        }

        /// <summary>
        /// Buscar si ya se registro la carga para un PuntoVenta.
        /// </summary>
        private PedidoNiquel buscarCarga(PuntoVenta cliente, DateTime fecha, EmpresaTransporte empresa)
        {

            foreach (PedidoNiquel carga in _cargas)
                if (carga.PuntoVenta.Id == cliente.Id)
                    return carga;

            PedidoNiquel nueva = new PedidoNiquel(cliente, transportadora: empresa, fecha_asignada: fecha);


            _cargas.Add(nueva);

            return nueva;
        }

        /// <summary>
        /// Identificar las denominaciones solicitadas.
        /// </summary>
        private void identificarDenominaciones(DocumentoExcel documento, Celda celda_a, Celda celda_b, Monedas moneda)
        {
            Regex regex = new Regex(@"\D");

            for (int columna = celda_a.Columna; columna <= celda_b.Columna; columna++)
            {
                Celda celda = documento.seleccionarCelda(celda_a.Fila, columna);

                if (celda.Valor.Equals(string.Empty)) return;

                decimal valor = decimal.Parse(regex.Replace(celda.Valor, ""));

                Denominacion denominacion = new Denominacion(valor: valor, moneda: moneda);

                _mantenimiento.verificarDenominacion(ref denominacion);

                _denominaciones.Add(columna, denominacion);
            }

        }

        /// <summary>
        /// Asignar los cartuchos de una carga y determinar si el monto erra correcto.
        /// </summary>
        private void asignarCartuchos(Celda celda_monto, ref PedidoNiquel carga)
        {
            decimal monto = 0;

            if ((decimal.TryParse(celda_monto.Valor, out monto) && monto > 0))
            {
                Denominacion denominacion = _denominaciones[celda_monto.Columna];

                double cantidad_total = (double)Math.Ceiling(monto / denominacion.Valor);

                double cantidad_cartucho = (double)(monto / denominacion.Valor);

                //cantidad_cartucho = (short)(100 * (int)Math.Ceiling((decimal)(cantidad_cartucho / 100)));

                    CartuchosNiquel cartucho = new CartuchosNiquel(movimiento: carga, cantidad_asignada: cantidad_cartucho,
                                                                     denominacion: denominacion);

                    carga.agregarCartucho(cartucho);
                

                switch (denominacion.Moneda)
                {
                    case Monedas.Colones: carga.Monto_pedido_colones += monto; break;
                    case Monedas.Dolares: carga.Monto_pedido_dolares += monto; break;
                }

            }

        }

        #endregion Métodos Privados

    }
}
