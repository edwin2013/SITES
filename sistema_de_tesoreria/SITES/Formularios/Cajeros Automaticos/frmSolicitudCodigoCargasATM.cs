using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonObjects;
using BussinessLayer;
using LibreriaMensajes;

namespace GUILayer.Formularios.Cajeros_Automaticos
{
    public partial class frmSolicitudCodigoCargasATM : Form
    {
       #region Atributos

        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;

        private CargaATM _carga = null;

        #endregion Atributos

        #region Constructor

        public frmSolicitudCodigoCargasATM()
        {
            InitializeComponent();
        }

        public frmSolicitudCodigoCargasATM(CargaATM carga, Colaborador colaborador)
        {
            InitializeComponent();

            _carga = carga;
            lblATM.Text = carga.ATM.Numero.ToString() +"-"+ carga.ATM.Codigo;
            txtCodigoApertura.Text = carga.CodigoApertura;
            txtCodigoCiere.Text = carga.CodigoCierre;

        }
       
        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de guardar.
        /// </summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Verificar que se hayan seleccionado los datos

            if (txtCodigoApertura.Text.Equals(string.Empty))
            {
                Excepcion.mostrarMensaje("ErrorCargaATMDatosRegistro");
                return;
            }

            try
            {
                frmListaCargasATMCajerosAutomaticos padre = (frmListaCargasATMCajerosAutomaticos)this.Owner;

                string codigo_apertura = txtCodigoApertura.Text;
                string codigo_cierre = txtCodigoCiere.Text;

                    // Actualizar los datos de la cámara

                _carga.CodigoApertura = codigo_apertura;
                _carga.CodigoCierre = codigo_cierre;
                    _coordinacion.actualizarCodigosCajerosCargaATM(_carga);


                    //padre.actualizarLista();
                    Mensaje.mostrarMensaje("MensajeCargaATMConfirmacionActualizacion");
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

       
    }
}
