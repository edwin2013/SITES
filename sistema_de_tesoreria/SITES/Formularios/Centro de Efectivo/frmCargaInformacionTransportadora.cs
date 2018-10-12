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

namespace GUILayer.Formularios.Centro_de_Efectivo
{
    public partial class frmCargaInformacionTransportadora : Form
    {

        #region Atributos

        private string _archivo = string.Empty;
        private List<int> _filas_incorrectas = new List<int>();
        Colaborador _usuario = new Colaborador();
        private BindingList<ProcesamientoBajoVolumenDeposito> _depositos = new BindingList<ProcesamientoBajoVolumenDeposito>();
        private BindingList<InconsistenciaDeposito> _inconsistencias = new BindingList<InconsistenciaDeposito>();


        #endregion Atributos

        #region Constructor
        public frmCargaInformacionTransportadora(Colaborador usuario)
        {
            _usuario = usuario;
            InitializeComponent();
        }

        #endregion Constructor

        #region Eventos
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            try
            {

                if (ofdDepositos.ShowDialog() == DialogResult.OK)
                {
                    _archivo = ofdDepositos.FileName;

                    this.generarDepositos();

                    btnAgregarDepositos.Enabled = _depositos.Count > 0 && _filas_incorrectas.Count == 0;
                }
                else
                {
                    _archivo = string.Empty;

                    _depositos.Clear();

                    btnAgregarDepositos.Enabled = false;
                }

            }
            catch (Exception)
            {
                Excepcion.mostrarMensaje("ErrorCargasGeneracionFormatoArchivo");
            }

            txtArchivo.Text = _archivo;
        }

        private void generarDepositos()
        {

            DocumentoExcel archivo = null;

            try
            {
                _filas_incorrectas.Clear();

                _depositos.Clear();

                archivo = new DocumentoExcel(_archivo, false);

                archivo.seleccionarHoja(1);

                        Celda celda_PolizaMadre = archivo.seleccionarCelda("F1");
                        Celda celda_PolizaHija = archivo.seleccionarCelda("A6");
                        Celda celda_Cedula = archivo.seleccionarCelda("B6");
                        Celda celda_Nombre = archivo.seleccionarCelda("C6");
                        Celda celda_Finca = archivo.seleccionarCelda("D6");
                        Celda celda_Ubicacion = archivo.seleccionarCelda("E6");
                        Celda celda_Monto = archivo.seleccionarCelda("F6");
                        Celda celda_Cuota = archivo.seleccionarCelda("G6");
                        Celda celda_Impuesto = archivo.seleccionarCelda("H6");
                        Celda celda_CuotaImpuesto = archivo.seleccionarCelda("I6");
                        Celda celda_Comision = archivo.seleccionarCelda("J6");
                        Celda celda_FechaVencimiento = archivo.seleccionarCelda("K6");
                        Celda celda_Cobertura = archivo.seleccionarCelda("L6");

                        //this.generarFacturasDatos(archivo, codigo, celda_PolizaMadre, celda_PolizaHija, celda_Cedula, celda_Nombre, celda_Finca
                        //    , celda_Ubicacion, celda_Monto, celda_Cuota, celda_Impuesto, celda_CuotaImpuesto, celda_Comision
                        //    , celda_FechaVencimiento, celda_Cobertura);
                

                    archivo.cerrar();
                
                dgvDepositos.DataSource = _depositos;

                archivo.mostrar();
                archivo.cerrar();

                // Dar formato a las cargas

                //foreach (DataGridViewRow fila in dgvDepositos.Rows)
                    //this.validarCarga(fila);
            }
            catch (Exception ex)
            {
                archivo.mostrar();
                archivo.cerrar();

                throw ex;
            }

        }

        private void generarDepositos(DocumentoExcel archivo, string codigo, Celda celda_PolizaMadre, Celda celda_PolizaHija, Celda celda_Cedula, Celda celda_Nombre,
          Celda celda_Finca, Celda celda_Ubicacion, Celda celda_Monto, Celda celda_Cuota, Celda celda_Impuesto, Celda celda_CuotaImpuesto,
          Celda celda_Comision, Celda celda_FechaVencimiento, Celda celda_Cobertura)
        {
            try
            {
              
                while (!(celda_PolizaHija.Valor.Equals(string.Empty)) & (celda_PolizaHija.Texto.Replace("-", "").Length > 0))
                {
                    Deposito factura = null;
                    string cedula = celda_Cedula.Valor;
                    string nombre = celda_Nombre.Valor;
                    string finca = celda_Finca.Valor;
                    string ubicacion = celda_Ubicacion.Valor;
                    decimal monto;
                    if (celda_Monto.Valor == "" || celda_Monto.Valor == "-")
                    { monto = 0; }
                    else
                    { monto = decimal.Parse(celda_Monto.Valor); }

                    decimal cuota;
                    if (celda_Cuota.Valor == "" || celda_Cuota.Valor == "-")
                    { cuota = 0; }
                    else
                    { cuota = decimal.Parse(celda_Cuota.Valor); }

                    decimal impuesto;
                    if (celda_Impuesto.Valor == "" || celda_Impuesto.Valor == "-")
                    { impuesto = 0; }
                    else
                    { impuesto = decimal.Parse(celda_Impuesto.Valor); }

                    decimal cuotaimpuesto;
                    if (celda_CuotaImpuesto.Valor == "" || celda_CuotaImpuesto.Valor == "-")
                    { cuotaimpuesto = 0; }
                    else
                    { cuotaimpuesto = decimal.Parse(celda_CuotaImpuesto.Valor); }

                    decimal comision;
                    if (celda_Comision.Valor == "" || celda_Comision.Valor == "-")
                    { comision = 0; }
                    else
                    { comision = decimal.Parse(celda_Comision.Valor); }

                    string fechaV = celda_FechaVencimiento.Texto;
                    DateTime fechaVencimiento = DateTime.Parse(fechaV);

                    string cobertura = celda_Cobertura.Valor;

                    //factura = new FacturaINS(id: 0, polizaMadre: polizaConvertida, poliza: polizaHija, cedula: cedula, nombre: nombre,
                    //finca: finca, ubicacion: ubicacion, monto: monto, cuota: cuota, impuesto: impuesto, cuotaimpuesto: cuotaimpuesto,
                    //comision: comision, fechavencimiento: fechaVencimiento, cobertura: cobertura, tipo: tipo);

                    //_mantenimiento.agregarFacturaINS(ref factura);

                    //_facturas.Add(factura);

                    //celda_PolizaMadre = archivo.seleccionarCelda(celda_PolizaMadre.Fila, celda_PolizaMadre.Columna);
                    //celda_PolizaHija = archivo.seleccionarCelda(celda_PolizaHija.Fila + 1, celda_PolizaHija.Columna);
                    //celda_Cedula = archivo.seleccionarCelda(celda_Cedula.Fila + 1, celda_Cedula.Columna);
                    //celda_Nombre = archivo.seleccionarCelda(celda_Nombre.Fila + 1, celda_Nombre.Columna);
                    //celda_Finca = archivo.seleccionarCelda(celda_Finca.Fila + 1, celda_Finca.Columna);
                    //celda_Ubicacion = archivo.seleccionarCelda(celda_Ubicacion.Fila + 1, celda_Ubicacion.Columna);
                    //celda_Monto = archivo.seleccionarCelda(celda_Monto.Fila + 1, celda_Monto.Columna);
                    //celda_Cuota = archivo.seleccionarCelda(celda_Cuota.Fila + 1, celda_Cuota.Columna);
                    //celda_Impuesto = archivo.seleccionarCelda(celda_Impuesto.Fila + 1, celda_Impuesto.Columna);
                    //celda_CuotaImpuesto = archivo.seleccionarCelda(celda_CuotaImpuesto.Fila + 1, celda_CuotaImpuesto.Columna);
                    //celda_Comision = archivo.seleccionarCelda(celda_Comision.Fila + 1, celda_Comision.Columna);
                    //celda_FechaVencimiento = archivo.seleccionarCelda(celda_FechaVencimiento.Fila + 1, celda_FechaVencimiento.Columna);
                    //celda_Cobertura = archivo.seleccionarCelda(celda_Cobertura.Fila + 1, celda_Cobertura.Columna);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void generarInconsistencias()
        {
            DocumentoExcel archivo = null;

            try
            {
                _filas_incorrectas.Clear();

                _inconsistencias.Clear();

                archivo = new DocumentoExcel(_archivo, false);

                archivo.seleccionarHoja(1);

                //Celda celda_fecha = archivo.seleccionarCelda(mtbCeldaFecha.Text);

                //Celda celda_a = archivo.seleccionarCelda(mtbPrimeraCelda.Text);
                //Celda celda_b = archivo.seleccionarCelda(mtbSegundaCelda.Text);
                //Celda celda_atm_a = archivo.seleccionarCelda(mtbCeldaATMA.Text);

                //Celda celda_c = archivo.seleccionarCelda(mtbTerceraCelda.Text);
                //Celda celda_d = archivo.seleccionarCelda(mtbCuartaCelda.Text);
                //Celda celda_atm_b = archivo.seleccionarCelda(mtbCeldaATMB.Text);

                //DateTime fecha = DateTime.Parse(celda_fecha.Texto);

                //this.generarCargasMoneda(archivo, Monedas.Colones, fecha, celda_a, celda_b, celda_atm_a);
                //this.generarCargasMoneda(archivo, Monedas.Dolares, fecha, celda_c, celda_d, celda_atm_b);

                dgvInconsistencias.DataSource = _inconsistencias;

                archivo.mostrar();
                archivo.cerrar();

                // Dar formato a las cargas

                //foreach (DataGridViewRow fila in dgvCargas.Rows)
                    //this.validarCarga(fila);
            }
            catch (Exception ex)
            {
                archivo.mostrar();
                archivo.cerrar();

                throw ex;
            }

        }
        
        #endregion Eventos

    }
}
