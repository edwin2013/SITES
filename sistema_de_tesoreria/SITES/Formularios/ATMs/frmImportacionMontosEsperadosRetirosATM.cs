//
//  @ Project : 
//  @ File Name : frmImportacionMontosEsperadosRetirosATM.cs
//  @ Date : 08/02/2013
//  @ Author : Erick Chavarría 
//

using System;
using System.ComponentModel;
using System.Windows.Forms;

using CommonObjects;
using BussinessLayer;
using LibreriaReportesOffice;
using LibreriaMensajes;

namespace GUILayer
{

    public partial class frmImportacionMontosEsperadosRetirosATM : Form
    {

        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;

        private BindingList<MontosRetirosATM> _montos = new BindingList<MontosRetirosATM>();

        private string _archivo = string.Empty;

        #endregion Atributos

        #region Contructor

        public frmImportacionMontosEsperadosRetirosATM()
        {
            InitializeComponent();
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

                if (ofdMontosRetirosCargas.ShowDialog() == DialogResult.OK)
                {
                    _archivo = ofdMontosRetirosCargas.FileName;

                    this.leerMontos();

                    btnAceptar.Enabled = _montos.Count > 0;
                }
                else
                {
                    _archivo = string.Empty;

                    _montos.Clear();

                    btnAceptar.Enabled = false;
                }

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
            catch (Exception)
            {
                Excepcion.mostrarMensaje("ErrorImportacionMontosRetirosFormatoArchivo");
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
                _coordinacion.importarMontosEsperadosRetiros(_montos);

                Mensaje.mostrarMensaje("MensajeMontosRetirosATMsConfirmacionImportacion");

                this.Close();
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

        #endregion Eventos

        #region Métodos Privados


        /// <summary>
        /// Leer los montos esperados del archivo.
        /// </summary>
        private void leerMontos()
        {
            DocumentoExcel archivo = null;

            try
            {
                _montos.Clear();

                archivo = new DocumentoExcel(_archivo, false);

                archivo.seleccionarHoja(1);

                Celda celda_atm = archivo.seleccionarCelda("A2");
                Celda celda_moneda = archivo.seleccionarCelda("B2");

                Celda celda_lunes = archivo.seleccionarCelda("C2");
                Celda celda_martes = archivo.seleccionarCelda("D2");
                Celda celda_miercoles = archivo.seleccionarCelda("E2");
                Celda celda_jueves = archivo.seleccionarCelda("F2");
                Celda celda_viernes = archivo.seleccionarCelda("G2");
                Celda celda_sabado = archivo.seleccionarCelda("H2");
                Celda celda_domingo = archivo.seleccionarCelda("I2");

                Celda celda_lunes_quincena = archivo.seleccionarCelda("J2");
                Celda celda_martes_quincena = archivo.seleccionarCelda("K2");
                Celda celda_miercoles_quincena = archivo.seleccionarCelda("L2");
                Celda celda_jueves_quincena = archivo.seleccionarCelda("M2");
                Celda celda_viernes_quincena = archivo.seleccionarCelda("N2");
                Celda celda_sabado_quincena = archivo.seleccionarCelda("O2");
                Celda celda_domingo_quincena = archivo.seleccionarCelda("P2");

                while (!celda_atm.Valor.Equals(string.Empty))
                {
                    short numero_atm = short.Parse(celda_atm.Valor);

                    ATM atm = new ATM(numero: numero_atm);

                    _mantenimiento.obtenerDatosATM(ref atm);

                    if (atm.ID_Valido)
                    {
                        Monedas moneda = (Monedas)0;

                        decimal retiro_lunes = decimal.Parse(celda_lunes.Valor);
                        decimal retiro_martes = decimal.Parse(celda_martes.Valor);
                        decimal retiro_miercoles = decimal.Parse(celda_miercoles.Valor);
                        decimal retiro_jueves = decimal.Parse(celda_jueves.Valor);
                        decimal retiro_viernes = decimal.Parse(celda_viernes.Valor);
                        decimal retiro_sabado = decimal.Parse(celda_sabado.Valor);
                        decimal retiro_domingo = decimal.Parse(celda_domingo.Valor);

                        decimal retiro_lunes_quincena = decimal.Parse(celda_lunes_quincena.Valor);
                        decimal retiro_martes_quincena = decimal.Parse(celda_martes_quincena.Valor);
                        decimal retiro_miercoles_quincena = decimal.Parse(celda_miercoles_quincena.Valor);
                        decimal retiro_jueves_quincena = decimal.Parse(celda_jueves_quincena.Valor);
                        decimal retiro_viernes_quincena = decimal.Parse(celda_viernes_quincena.Valor);
                        decimal retiro_sabado_quincena = decimal.Parse(celda_sabado_quincena.Valor);
                        decimal retiro_domingo_quincena = decimal.Parse(celda_domingo_quincena.Valor);

                        MontosRetirosATM monto = new MontosRetirosATM(atm, moneda, retiro_lunes: retiro_lunes, retiro_martes: retiro_martes,
                                                                      retiro_miercoles: retiro_miercoles, retiro_jueves: retiro_jueves,
                                                                      retiro_viernes: retiro_viernes, retiro_sabado: retiro_sabado,
                                                                      retiro_domingo: retiro_domingo, retiro_lunes_quincena: retiro_lunes_quincena,
                                                                      retiro_martes_quincena: retiro_martes_quincena,
                                                                      retiro_miercoles_quincena: retiro_miercoles_quincena,
                                                                      retiro_jueves_quincena: retiro_jueves_quincena,
                                                                      retiro_viernes_quincena: retiro_viernes_quincena,
                                                                      retiro_sabado_quincena: retiro_sabado_quincena,
                                                                      retiro_domingo_quincena: retiro_domingo_quincena);

                        _montos.Add(monto);
                    }

                    celda_atm = archivo.seleccionarCelda(celda_atm.Fila + 1, celda_atm.Columna);
                    celda_moneda = archivo.seleccionarCelda(celda_atm.Fila, celda_moneda.Columna);

                    celda_lunes = archivo.seleccionarCelda(celda_atm.Fila, celda_lunes.Columna);
                    celda_martes = archivo.seleccionarCelda(celda_atm.Fila, celda_martes.Columna);
                    celda_miercoles = archivo.seleccionarCelda(celda_atm.Fila, celda_miercoles.Columna);
                    celda_jueves = archivo.seleccionarCelda(celda_atm.Fila, celda_jueves.Columna);
                    celda_viernes = archivo.seleccionarCelda(celda_atm.Fila, celda_viernes.Columna);
                    celda_sabado = archivo.seleccionarCelda(celda_atm.Fila, celda_sabado.Columna);
                    celda_domingo = archivo.seleccionarCelda(celda_atm.Fila, celda_domingo.Columna);

                    celda_lunes_quincena = archivo.seleccionarCelda(celda_atm.Fila, celda_lunes_quincena.Columna);
                    celda_martes_quincena = archivo.seleccionarCelda(celda_atm.Fila, celda_martes_quincena.Columna);
                    celda_miercoles_quincena = archivo.seleccionarCelda(celda_atm.Fila, celda_miercoles_quincena.Columna);
                    celda_jueves_quincena = archivo.seleccionarCelda(celda_atm.Fila, celda_jueves_quincena.Columna);
                    celda_viernes_quincena = archivo.seleccionarCelda(celda_atm.Fila, celda_viernes_quincena.Columna);
                    celda_sabado_quincena = archivo.seleccionarCelda(celda_atm.Fila, celda_sabado_quincena.Columna);
                    celda_domingo_quincena = archivo.seleccionarCelda(celda_atm.Fila, celda_domingo_quincena.Columna);
                }

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

        #endregion Métodos Privados

    }

}
