//
//  @ Project : 
//  @ File Name : frmImportacionCargas.cs
//  @ Date : 14/05/2012
//  @ Author : Erick Chavarría 
//

using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using CommonObjects;
using BussinessLayer;
using LibreriaReportesOffice;
using LibreriaMensajes;

namespace GUILayer
{

    public partial class frmImportacionCargas : Form
    {

        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;

        private BindingList<CargaATM> _cargas = new BindingList<CargaATM>();
        private Dictionary<int, Denominacion> _denominaciones = new Dictionary<int, Denominacion>();

        private Colaborador _coordinador = null;

        private string _archivo = string.Empty;
        private bool _datos_correctos = true;

        #endregion Atributos

        #region Contructor

        public frmImportacionCargas(Colaborador coordinador)
        {
            InitializeComponent();

            _coordinador = coordinador;

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

                if (ofdArchivoCargas.ShowDialog() == DialogResult.OK)
                {
                    _archivo = ofdArchivoCargas.FileName;

                    this.leerCargas();

                    btnAceptar.Enabled = _cargas.Count > 0 && _datos_correctos;
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
                Excepcion.mostrarMensaje("ErrorCargasImportacionFormatoArchivo");
            }

            txtArchivo.Text = _archivo;
        }

        /// <summary>
        /// Clic en el botón de revisar.
        /// </summary>
        private void btnRevisar_Click(object sender, EventArgs e)
        {
            CargaATM carga = (CargaATM)dgvCargas.SelectedCells[0].OwningRow.DataBoundItem;
            frmModificacionCarga formulario = new frmModificacionCarga(carga, _coordinador, true);

            formulario.ShowDialog(this);
        }

        /// <summary>
        /// Clic en el botón de aceptar.
        /// </summary>
        private void btnAceptar_Click(object sender, EventArgs e)
        {

            try
            {
                _coordinacion.importarCargasATMs(_cargas);

                Mensaje.mostrarMensaje("MensajeCargasATMsConfirmacionImportacion");

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
        /// Doble clic en panel del color del estado para una carga con un ATM no registrado.
        /// </summary>
        private void pbATMDesconocido_DoubleClick(object sender, EventArgs e)
        {
            cdColor.Color = pbATMDesconocido.BackColor;

            if (cdColor.ShowDialog() == DialogResult.OK)
            {
                pbATMDesconocido.BackColor = cdColor.Color;
                Properties.Settings.Default.Save();
            }

        }

        /// <summary>
        /// Doble clic en panel del color del estado para una carga con un tipo de cartucho erróneo.
        /// </summary>
        private void pbTipoCargaErronea_DoubleClick(object sender, EventArgs e)
        {
            cdColor.Color = pbTipoCargaErronea.BackColor;

            if (cdColor.ShowDialog() == DialogResult.OK)
            {
                pbTipoCargaErronea.BackColor = cdColor.Color;
                Properties.Settings.Default.Save();
            }

        }

        /// <summary>
        /// Doble clic en panel del color del estado para una carga con un cartucho con una cantidad no permitida de billetes.
        /// </summary>
        private void pbErrorCantidadCarga_DoubleClick(object sender, EventArgs e)
        {
            cdColor.Color = pbErrorCantidadCarga.BackColor;

            if (cdColor.ShowDialog() == DialogResult.OK)
            {
                pbErrorCantidadCarga.BackColor = cdColor.Color;
                Properties.Settings.Default.Save();
            }

        }

        /// <summary>
        /// Doble clic en panel del color del estado para una carga con un cartucho con una denominación desconocida.
        /// </summary>
        private void pbErrorDenominacionCarga_DoubleClick(object sender, EventArgs e)
        {
            cdColor.Color = pbErrorDenominacionCarga.BackColor;

            if (cdColor.ShowDialog() == DialogResult.OK)
            {
                pbErrorDenominacionCarga.BackColor = cdColor.Color;
                Properties.Settings.Default.Save();
            }

        }

        #endregion Eventos

        #region Métodos Privados

        /// <summary>
        /// Mostrar el error en los datos de una carga.
        /// </summary>
        private void mostrarError(DataGridViewColumn columna, DataGridViewRow fila, Color color, bool datos_correctos)
        {
            fila.Cells[columna.Index].Style.BackColor = color;
            _datos_correctos = _datos_correctos && datos_correctos;
        }

        /// <summary>
        /// Leer las cargas del archivo.
        /// </summary>
        private void leerCargas()
        {
            DocumentoExcel archivo = null;

            try
            {
                _datos_correctos = true;

                _cargas.Clear();
                _denominaciones.Clear();

                archivo = new DocumentoExcel(_archivo, false);

                archivo.seleccionarHoja(1);

                // Leer las denominaciones

                Celda celda_a = archivo.seleccionarCelda(mtbPrimeraCelda.Text);
                Celda celda_b = archivo.seleccionarCelda(mtbSegundaCelda.Text);

                this.identificarDenominaciones(archivo, celda_a, celda_b);

                // Leer la fecha y la primera celda de los número de ATM

                Celda celda_atm = archivo.seleccionarCelda(mtbCeldaATM.Text);
                Celda celda_tipo_atm = archivo.seleccionarCelda(mtbCeldaTipoATM.Text);
                Celda celda_fecha = archivo.seleccionarCelda(mtbCeldaFecha.Text);

                DateTime fecha = DateTime.Parse(celda_fecha.Texto);

                while (!celda_atm.Valor.Equals(string.Empty))
                {
                    ATM atm = null;
                    byte? emergencia = null;

                    string tipo_cartucho = celda_tipo_atm.Valor.ToLower();
                    string numero_atm = celda_atm.Valor.ToLower();

                    EmpresaTransporte transportadora = null;

                    bool externa = false;
                    bool atm_full = false;
                    bool cartucho_rechazo = true;
                    bool ena = false;

                    if (numero_atm.StartsWith("e"))
                    {
                        emergencia = byte.Parse(numero_atm.TrimStart('e'));

                        if(emergencia >= 15)
                        {
                            atm_full = true;
                            ena = true;
                        }
                    }
                    else
                    {
                        short numero = short.Parse(celda_atm.Valor);

                        atm = new ATM(numero: numero);

                        _mantenimiento.obtenerDatosATM(ref atm);

                        transportadora = atm.Empresa_encargada;
                        externa = atm.Externo;
                        atm_full = atm.Full;
                        cartucho_rechazo = atm.Cartucho_rechazo;
                        ena = atm.ENA;
                    }

                    TiposCartucho tipo;

                    switch (tipo_cartucho)
                    {
                        case "opteva": tipo = TiposCartucho.Opteva; break;
                        case "diebold": case "ix": tipo = TiposCartucho.Diebold; break;
                        default: tipo = TiposCartucho.Indefinido; break; 
                    }

                    CargaATM nueva = new CargaATM(atm: atm, emergencia: emergencia, transportadora: transportadora,
                                                  fecha_asignada: fecha, tipo: tipo, externa: externa, atm_full: atm_full,
                                                  cartucho_rechazo: cartucho_rechazo, ena: ena);

                    for (int columna = celda_a.Columna; columna <= celda_b.Columna; columna++)
                    {
                        Celda celda_monto = archivo.seleccionarCelda(celda_atm.Fila, columna);

                        this.leerMonto(celda_monto, ref nueva);
                    }

                    _cargas.Add(nueva);

                    celda_atm = archivo.seleccionarCelda(celda_atm.Fila + 1, celda_atm.Columna);
                    celda_tipo_atm = archivo.seleccionarCelda(celda_atm.Fila, celda_tipo_atm.Columna);
                }

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

            foreach (CartuchoCargaATM cartucho in carga.Cartuchos_Colones)
            {
                Denominacion denominacion = cartucho.Denominacion;

                if (denominacion.ID_Invalido || !denominacion.Carga_atm)
                    this.mostrarError(MontoColones, fila, pbErrorDenominacionCarga.BackColor, false);
                else if (cartucho.Cantidad_asignada < denominacion.Formulas_minimas ||
                         cartucho.Cantidad_asignada > denominacion.Formulas_maximas)
                    this.mostrarError(CantidadColones, fila, pbErrorCantidadCarga.BackColor, false);

            }

            fila.Cells[CantidadDolares.Index].Style.BackColor = SystemColors.Window;

            foreach (CartuchoCargaATM cartucho in carga.Cartuchos_Dolares)
            {
                Denominacion denominacion = cartucho.Denominacion;

                if (denominacion.ID_Invalido || !denominacion.Carga_atm)
                    this.mostrarError(MontoDolares, fila, pbErrorDenominacionCarga.BackColor, false);
                else if (cartucho.Cantidad_asignada < denominacion.Formulas_minimas ||
                         cartucho.Cantidad_asignada > denominacion.Formulas_maximas)
                    this.mostrarError(CantidadDolares, fila, pbErrorCantidadCarga.BackColor, false);

            }

            if (atm != null)
            {
                if (atm.ID_Invalido)
                    this.mostrarError(ATM, fila, pbATMDesconocido.BackColor, false);
                else if (carga.Cartuchos.Count > atm.Cartuchos)
                    this.mostrarError(CantidadCartuchos, fila, pbErrorCantidadCartuchos.BackColor, false);

                if (carga.Tipo != atm.Tipo)
                    this.mostrarError(Tipo, fila, pbTipoCargaErronea.BackColor, true);
            }

            if (carga.Tipo == TiposCartucho.Indefinido)
                this.mostrarError(Tipo, fila, pbTipoCargaErronea.BackColor, false);

            fila.Cells[ATM.Index].Value = carga.ToString();
            fila.Cells[Tipo.Index].Value = Enum.GetName(typeof(TiposCartucho), carga.Tipo);
            fila.Cells[CantidadCartuchos.Index].Value = carga.Cartuchos.Count;
        }

        /// <summary>
        /// Leer el monto solicitado para un cartucho.
        /// </summary>
        private void leerMonto(Celda celda_monto, ref CargaATM carga)
        {
            decimal total = 0;

            if ((decimal.TryParse(celda_monto.Valor, out total) && total > 0))
            {
                Denominacion denominacion = _denominaciones[celda_monto.Columna];
                short cantidad = (short)(total / denominacion.Valor);
                CartuchoCargaATM cartucho = new CartuchoCargaATM(movimiento: carga, cantidad_asignada: cantidad, denominacion: denominacion);

                carga.agregarCartucho(cartucho);
            }

        }

        /// <summary>
        /// Identificar las denominaciones solicitadas.
        /// </summary>
        private void identificarDenominaciones(DocumentoExcel documento, Celda celda_a, Celda celda_b)
        {

            for (int columna = celda_a.Columna; columna <= celda_b.Columna; columna++)
            {
                Celda celda_denominacion = documento.seleccionarCelda(celda_a.Fila, columna);
                decimal valor = decimal.Parse(celda_denominacion.Valor);
                Monedas moneda = celda_denominacion.Texto.StartsWith("$") ?
                    Monedas.Dolares : Monedas.Colones;
                Denominacion denominacion = new Denominacion(valor: valor, moneda: moneda);

                _mantenimiento.verificarDenominacion(ref denominacion);

                _denominaciones.Add(columna, denominacion);
            }

        }

        #endregion Métodos Privados

    }

}
