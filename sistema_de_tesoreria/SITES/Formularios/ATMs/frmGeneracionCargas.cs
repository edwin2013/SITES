//
//  @ Project : 
//  @ File Name : frmGeneracionCargas.cs
//  @ Date : 13/11/2012
//  @ Author : Erick Chavarría 
//

using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Text.RegularExpressions;

using CommonObjects;
using BussinessLayer;
using LibreriaReportesOffice;
using LibreriaMensajes;

namespace GUILayer
{

    public partial class frmGeneracionCargas : Form
    {

        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;

        private BindingList<CargaATM> _cargas = new BindingList<CargaATM>();
        private Dictionary<int, Denominacion> _denominaciones = new Dictionary<int, Denominacion>();

        private Colaborador _colaborador = null;

        private string _archivo = string.Empty;

        private List<int> _filas_incorrectas = new List<int>();

        #endregion Atributos

        #region Contructor

        public frmGeneracionCargas(Colaborador colaborador)
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
                _coordinacion.importarCargasATMs(_cargas);
                DateTime Fecha = new DateTime(2014, 02, 10);

                CargaATM C = new CargaATM();
                C = _cargas[0];
                BindingList<CargaATM> _atminfo = _coordinacion.listarCargasATMsEspeciales(null, null, C.Fecha_asignada, null, null);
                
               

                _coordinacion.guardarDatosATMINFO(_atminfo, "I");

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
            CargaATM carga = (CargaATM)fila.DataBoundItem;
            frmModificacionCarga formulario = new frmModificacionCarga(carga, _colaborador, false);

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

                DateTime fecha = DateTime.Parse(celda_fecha.Texto);

                this.generarCargasMoneda(archivo, Monedas.Colones, fecha, celda_a, celda_b, celda_atm_a);
                this.generarCargasMoneda(archivo, Monedas.Dolares, fecha, celda_c, celda_d, celda_atm_b);

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
            CargaATM carga = (CargaATM)fila.DataBoundItem;
            ATM atm = carga.ATM;

            _filas_incorrectas.Remove(fila.Index);

            fila.Cells[CantidadColones.Index].Style.BackColor = SystemColors.Window;

            foreach (CartuchoCargaATM cartucho in carga.Cartuchos_Colones)
            {
                Denominacion denominacion = cartucho.Denominacion;

                if (denominacion.ID_Invalido || !denominacion.Carga_atm)
                    this.mostrarError(MontoColones, fila, pbErrorDenominacion.BackColor);
                else if (cartucho.Cantidad_asignada < denominacion.Formulas_minimas)
                    this.mostrarError(CantidadColones, fila, pbErrorMínimoFormulas.BackColor);

             }

            fila.Cells[CantidadDolares.Index].Style.BackColor = SystemColors.Window;

            foreach (CartuchoCargaATM cartucho in carga.Cartuchos_Dolares)
            {
                Denominacion denominacion = cartucho.Denominacion;

                if (denominacion.ID_Invalido || !denominacion.Carga_atm)
                    this.mostrarError(MontoDolares, fila, pbErrorDenominacion.BackColor);
                else if (cartucho.Cantidad_asignada < denominacion.Formulas_minimas)
                    this.mostrarError(CantidadDolares, fila, pbErrorMínimoFormulas.BackColor);

            }

            if (atm.ID_Invalido)
                this.mostrarError(ATM, fila, pbATMDesconocido.BackColor);
            else if (carga.Cartuchos.Count > atm.Cartuchos)
                this.mostrarError(CantidadCartuchos, fila, pbErrorCantidadCartuchos.BackColor);

            if (carga.Cantidad_denominaciones > 4)
                this.mostrarError(Denominaciones, fila, pbErrorCantidadDenominaciones.BackColor);

            fila.Cells[Tipo.Index].Value = carga.Tipo;
            fila.Cells[CantidadCartuchos.Index].Value = carga.Cartuchos.Count;
        }

        /// <summary>
        /// Generar las cargas para una moneda específica.
        /// </summary>
        private void generarCargasMoneda(DocumentoExcel archivo, Monedas moneda, DateTime fecha,
                                         Celda celda_a, Celda celda_b, Celda celda_atm)
        {
            // Leer las denominaciones

            this.identificarDenominaciones(archivo, celda_a, celda_b, moneda);

            while (!celda_atm.Valor.Equals(string.Empty))
            {
                short numero_atm = short.Parse(celda_atm.Valor.Substring(0, 3));

                ATM atm = new ATM(numero: numero_atm);

                _mantenimiento.obtenerDatosATM(ref atm);

                CargaATM carga = this.buscarCarga(atm, fecha);

                for (int columna = celda_a.Columna; columna <= celda_b.Columna; columna++)
                {
                    Celda celda_monto = archivo.seleccionarCelda(celda_atm.Fila, columna);

                    this.asignarCartuchos(celda_monto, ref carga);
                }

                celda_atm = archivo.seleccionarCelda(celda_atm.Fila + 1, celda_atm.Columna);
            }

        }

        /// <summary>
        /// Buscar si ya se registro la carga para un ATM.
        /// </summary>
        private CargaATM buscarCarga(ATM atm, DateTime fecha)
        {

            foreach (CargaATM carga in _cargas)
                if (carga.ATM.Numero == atm.Numero)
                    return carga;

            CargaATM nueva = new CargaATM(atm, transportadora: atm.Empresa_encargada, fecha_asignada: fecha,
                                          tipo: atm.Tipo, externa: atm.Externo, atm_full: atm.Full,
                                          cartucho_rechazo: atm.Cartucho_rechazo, ena: atm.ENA);

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
        private void asignarCartuchos(Celda celda_monto, ref CargaATM carga)
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

                for (int contador = 0; contador < cantidad_cartuchos; contador++)
                {
                    CartuchoCargaATM cartucho = new CartuchoCargaATM(movimiento: carga, cantidad_asignada: cantidad_cartucho,
                                                                     denominacion: denominacion);

                    carga.agregarCartucho(cartucho);
                }

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
