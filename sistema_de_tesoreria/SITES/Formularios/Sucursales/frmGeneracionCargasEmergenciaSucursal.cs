using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Serialization;
using BussinessLayer;
using CommonObjects;
using LibreriaMensajes;
using LibreriaReportesOffice;
using CommonObjects.Clases;
using System.Text.RegularExpressions;

namespace GUILayer.Formularios.Blindados
{
    public partial class frmGeneracionCargasEmergenciaSucursal : Form
    {
        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;

        private BindingList<CargaSucursal> _cargas = new BindingList<CargaSucursal>();
        private Dictionary<int, Denominacion> _denominaciones = new Dictionary<int, Denominacion>();

        private Colaborador _colaborador = null;

        private string _archivo = string.Empty;

        private List<int> _filas_incorrectas = new List<int>();

        #endregion Atributos

        #region Contructor

        public frmGeneracionCargasEmergenciaSucursal(Colaborador colaborador)
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
                    btnRevisar.Enabled = _cargas.Count > 0 && _filas_incorrectas.Count == 0;
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
                foreach (CargaSucursal carga in _cargas)
                {
                    CargaSucursal copia = carga;
                    _coordinacion.importarCargasSucursales(ref copia, _colaborador);
                }

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
            CargaSucursal carga = (CargaSucursal)fila.DataBoundItem;
            frmModificacionCargaSucursal formulario = new frmModificacionCargaSucursal(carga, _colaborador, false);

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

                Celda celda_a = archivo.seleccionarCelda(mtbPrimeraCelda.Text);
                Celda celda_b = archivo.seleccionarCelda(mtbSegundaCelda.Text);
                Celda celda_atm_a = archivo.seleccionarCelda(mtbCeldaATMA.Text);

                Celda celda_c = archivo.seleccionarCelda(mtbTerceraCelda.Text);
                Celda celda_d = archivo.seleccionarCelda(mtbCuartaCelda.Text);
                Celda celda_atm_b = archivo.seleccionarCelda(mtbCeldaATMB.Text);
                //Celda celda_ruta = archivo.seleccionarCelda(mtbCeldaRuta.Text);

                DateTime fecha = DateTime.Parse(celda_fecha.Texto);

                this.generarCargasMoneda(archivo, Monedas.Colones, fecha, celda_a, celda_b, celda_atm_a,celda_c,celda_d,celda_atm_b, Monedas.Dolares);
               // this.generarCargasMoneda(archivo, Monedas.Dolares, fecha, celda_c, celda_d, celda_atm_b);
  
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
          
        }

        /// <summary>
        /// Generar las cargas para una moneda específica.
        /// </summary>
        private void generarCargasMoneda(DocumentoExcel archivo, Monedas moneda, DateTime fecha,
                                         Celda celda_a, Celda celda_b, Celda celda_atm,Celda celda_c, Celda celda_d,Celda celda_atm_b, Monedas moneda_dolares)
        {
            // Leer las denominaciones

            this.identificarDenominaciones(archivo, celda_a, celda_b, moneda);
            this.identificarDenominaciones(archivo, celda_c, celda_d, moneda_dolares);
            

            while (!celda_atm.Valor.Equals(string.Empty))
            {
               // short numero_atm = short.Parse(celda_atm.Valor.Substring(0, 3));
                //byte? ruta = Convert.ToByte(celda_ruta.Texto);

                Sucursal sucursal = new Sucursal();
                byte? emergencia = null;
                if (celda_atm.Valor.StartsWith("E"))
                {
                    emergencia = byte.Parse(celda_atm.Valor.TrimStart('E'));
                }
                else
                {
                    sucursal = new Sucursal(codigo: 999);

                    _mantenimiento.obtenerDatosSucursal(ref sucursal);
                }

                CargaSucursal carga = this.buscarCarga(sucursal, fecha, emergencia);
                this.ObtenerDatosDolares(celda_atm_b,celda_c, celda_d, moneda_dolares, ref carga,archivo);
                for (int columna = celda_a.Columna; columna <= celda_b.Columna; columna++)
                {
                    Celda celda_monto = archivo.seleccionarCelda(celda_atm.Fila, columna);

                    this.asignarCartuchos(celda_monto, ref carga);
                }

                celda_atm = archivo.seleccionarCelda(celda_atm.Fila + 1, celda_atm.Columna);
                celda_atm_b = archivo.seleccionarCelda(celda_atm_b.Fila + 1, celda_atm_b.Columna);
            }


            
        }


        private void ObtenerDatosDolares(Celda celda_atm,Celda a, Celda b, Monedas moneda, ref CargaSucursal carga,DocumentoExcel archivo)
        {


            for (int columna = a.Columna; columna <= b.Columna; columna++)
            {
                Celda celda_monto = archivo.seleccionarCelda(celda_atm.Fila, columna);

                this.asignarCartuchos(celda_monto, ref carga);
            }
        }

        /// <summary>
        /// Buscar si ya se registro la carga para un ATM.
        /// </summary>
        private CargaSucursal buscarCarga(Sucursal sucursal, DateTime fecha, byte? emergencia)
        {

            //foreach (CargaSucursal carga in _cargas)
            //    if (carga.Sucursal.Codigo == sucursal.Codigo)
            //        return carga;

            CargaSucursal nueva = new CargaSucursal(sucursal, transportadora: sucursal.Empresa, fecha_asignada: fecha, cajero: _colaborador, emergencia: emergencia);
            nueva.EstadoAprobadas = EstadoAprobacionCargas.Aprobada;
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
        private void asignarCartuchos(Celda celda_monto, ref CargaSucursal carga)
        {
            decimal monto = 0;

            if ((decimal.TryParse(celda_monto.Valor, out monto) && monto > 0))
            {
                Denominacion denominacion = _denominaciones[celda_monto.Columna];

                short cantidad_total = (short)Math.Ceiling(monto / denominacion.Valor);
                double numero_cartuchos = (double)cantidad_total / (double)denominacion.Formulas_maximas;
                int cantidad_cartuchos = (int)Math.Ceiling(numero_cartuchos);
                short cantidad_cartucho = (short)(cantidad_total / cantidad_cartuchos);

                cantidad_cartucho = (short)(100 * (int)Math.Ceiling((decimal)(cantidad_cartucho / 100)));

                //for (int contador = 0; contador < cantidad_cartuchos; contador++)
                //{
                    CartuchoCargaSucursal cartucho = new CartuchoCargaSucursal(movimiento: carga, cantidad_asignada: cantidad_total,
                                                                     denominacion: denominacion);
                    carga.agregarCartucho(cartucho);
                //}

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
