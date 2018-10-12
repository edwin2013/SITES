//
//  @ Project : 
//  @ File Name : frmImportacionTrialesDescargas.cs
//  @ Date : 15/02/2013
//  @ Author : Erick Chavarría 
//

using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using CommonObjects;
using BussinessLayer;
using LibreriaAccesoDatos;
using LibreriaMensajes;

namespace GUILayer
{

    public partial class frmImportacionTrialesDescargas : Form
    {

        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;
        private ManejadorArchivosTexto _lector = ManejadorArchivosTexto.Instancia;

        private BindingList<TrialDescargaATM> _triales = new BindingList<TrialDescargaATM>();

        private string _archivo = string.Empty;

        #endregion Atributos

        #region Contructor

        public frmImportacionTrialesDescargas()
        {
            InitializeComponent();

            dgvTriales.AutoGenerateColumns = false;
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

                if (ofdArchivoTriales.ShowDialog() == DialogResult.OK)
                {
                    _archivo = ofdArchivoTriales.FileName;

                    this.leerTriales();

                    btnAceptar.Enabled = _triales.Count > 0;
                }
                else
                {
                    _archivo = string.Empty;

                    _triales.Clear();

                    btnAceptar.Enabled = false;
                }

            }
            catch (Exception)
            {
                Excepcion.mostrarMensaje("ErrorTrialesImportacionFormatoArchivo");
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
                _coordinacion.importarTrialesDescargasATMs(_triales);

                Mensaje.mostrarMensaje("MensajeTrialesDescargasATMsConfirmacionImportacion");

                dgvTriales.DataSource = null;

                btnAceptar.Enabled = false;
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
        /// Leer los triales del archivo.
        /// </summary>
        private void leerTriales()
        {

            try
            {
                bool full = chkFull.Checked;

                _triales.Clear();

                string archivo = _lector.leerArchivo(_archivo);

                string[] lineas = archivo.Split('\n');

                string valor_fecha = Regex.Replace(lineas[2], "[^0-9/]", "").Remove(10);

                DateTime fecha = DateTime.Parse(valor_fecha);

                foreach (string linea in lineas)
                {
                    char[] separadores = {' '};

                    if (Regex.IsMatch(linea, @"^[0-9,. ]+$"))
                    {
                        string valor_atm = linea.Substring(0 ,12);
                        string valor_monto_colones = Regex.Replace(linea.Substring(65, 15), "[^0-9]", "");
                        string valor_monto_dolares = Regex.Replace(linea.Substring(140, 15), "[^0-9]", "");

                        short numero_atm;

                        if (short.TryParse(valor_atm, out numero_atm))
                        {
                            ATM atm = new ATM(numero: numero_atm);

                            if (_mantenimiento.obtenerDatosATM(ref atm))
                            {
                                decimal monto_colones;
                                decimal monto_dolares;

                                if (decimal.TryParse(valor_monto_colones, out monto_colones) &&
                                    decimal.TryParse(valor_monto_dolares, out monto_dolares))
                                {

                                    TrialDescargaATM trial = new TrialDescargaATM(atm, fecha, monto_colones, monto_dolares, full);

                                    _triales.Add(trial);
                                }

                            }

                        }

                    }

                }

                dgvTriales.DataSource = _triales;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion Métodos Privados

    }

}
