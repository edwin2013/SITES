//
//  @ Project : 
//  @ File Name : frmModificacionCargaEmergenciaFull.cs
//  @ Date : 01/03/2013
//  @ Author : Erick Chavarría 
//

using System;
using System.ComponentModel;
using System.Windows.Forms;

using CommonObjects;
using BussinessLayer;
using LibreriaMensajes;

namespace GUILayer
{

    public partial class frmModificacionCargaEmergenciaFull : Form
    {

        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;

        private CargaEmergenciaATMFull _carga = null;
        private ManifiestoATMFull _manifiesto = null;

        #endregion Atributos

        #region Constructor

        public frmModificacionCargaEmergenciaFull()
        {
            InitializeComponent();

            try
            {
                cboATM.ListaMostrada = _mantenimiento.listarATMs();
            }
            catch (Excepcion ex)
            {
                this.Close();
                throw ex;
            }

        }

        public frmModificacionCargaEmergenciaFull(CargaEmergenciaATMFull carga)
        {
            InitializeComponent();

            _carga = carga;

            this.seleccionarManifiesto(_carga.Manifiesto);

            try
            {
                cboATM.ListaMostrada = _mantenimiento.listarATMs();

                dtpFechaEnvio.Value = _carga.Fecha_envio;
                chkENA.Checked = _carga.ENA;

                if (_carga.Fecha_carga != null)
                {
                    chkCargado.Checked = true;

                    dtpFechaCarga.Value = (DateTime)_carga.Fecha_carga;
                    cboATM.Text = _carga.ATM.ToString();
                }

            }
            catch (Excepcion ex)
            {
                this.Close();
                throw ex;
            }

        }

        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de seleccionar el manifiesto.
        /// </summary>
        private void btnSeleccionarManifiestosCarga_Click(object sender, EventArgs e)
        {
            DateTime fecha = dtpFechaCarga.Value;
            bool ena = chkENA.Checked;
            frmIngresoManifiestoATMsFull formulario = new frmIngresoManifiestoATMsFull(_manifiesto, ena, fecha);

            formulario.ShowDialog(this);
        }

        /// <summary>
        /// Clic en el botón de guardar.
        /// </summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Verificar que se hayan seleccionado los datos

            if ((chkCargado.Checked && cboATM.SelectedItem == null) || _manifiesto == null)
            {
                Excepcion.mostrarMensaje("ErrorCargaEmergenciaATMFullDatosRegistro");
                return;
            }

            try
            {
                frmListaCargasEmergenciaFull padre = (frmListaCargasEmergenciaFull)this.Owner;

                // Datos de Envío

                DateTime fecha_envio = dtpFechaEnvio.Value;
                bool ena = chkENA.Checked;

                // Datos de Carga

                DateTime? fecha_carga = null;
                ATM atm = null;

                if (chkCargado.Checked)
                {
                    fecha_carga = dtpFechaCarga.Value;
                    atm = (ATM)cboATM.SelectedItem;
                }

                // Verificar si la carga de emergencia del ATM Full ya está registrada

                if (_carga == null)
                {
                    // Agregar los datos de la carga de emergencia del ATM Full

                    if (Mensaje.mostrarMensajeConfirmacion("MensajeCargaEmergenciaATMFullRegistro") == DialogResult.Yes)
                    {
                        CargaEmergenciaATMFull nueva = new CargaEmergenciaATMFull(fecha_envio, _manifiesto, ena, atm: atm,
                                                                                  fecha_carga: fecha_carga);

                        _coordinacion.agregarCargaEmergenciaATMFull(ref nueva);

                        padre.agregarCargaEmergenciaATM(nueva);
                        Mensaje.mostrarMensaje("MensajeCargaEmergenciaATMFullConfirmacionRegistro");
                        this.Close();
                    }

                }
                else
                {
                    // Actualizar los datos de la carga de emergencia

                    CargaEmergenciaATMFull copia = new CargaEmergenciaATMFull(fecha_envio, _manifiesto, ena, id: _carga.ID,
                                                                              atm: atm, fecha_carga: fecha_carga);

                    _coordinacion.actualizarCargaEmergenciaATMFull(copia);

                    copia.ATM = atm;
                    copia.Fecha_envio = fecha_envio;
                    copia.Fecha_carga = fecha_carga;
                    copia.Manifiesto = _manifiesto;
                    copia.ENA = ena;

                    padre.actualizarLista();
                    Mensaje.mostrarMensaje("MensajeCargaEmergenciaATMFullConfirmacionActualizacion");
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
        /// Se marca o desmarca la opción de asignar la carga de emergencia como cargada.
        /// </summary>
        private void chkCargado_CheckedChanged(object sender, EventArgs e)
        {
            gbDatosCarga.Enabled = chkCargado.Checked;
        }

        #endregion Eventos

        #region Métodos Públicos

        /// <summary>
        /// Mostrar los datos del manifiesto seleccionado.
        /// </summary>
        public void seleccionarManifiesto(ManifiestoATMFull manifiesto)
        {
            _manifiesto = manifiesto;

            txtManifiesto.Text = manifiesto.Codigo;
            txtMarchamo.Text = manifiesto.Marchamo;
        }

        #endregion Métodos Públicos


    }

}
