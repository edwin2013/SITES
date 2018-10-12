using BussinessLayer;
using CommonObjects.Clases;
using LibreriaMensajes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GUILayer.Formularios.Facturacion
{
    public partial class frmModificacionInconsistencia : Form
    {
        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;

        private PuntoAtencion _tarifa = null;

        #endregion Atributos

        #region Constructor

        public frmModificacionInconsistencia()
        {
            InitializeComponent();

            cboInconsistencia.ListaMostrada = _mantenimiento.listarInconsistenciaFacturacion();
        }

        public frmModificacionInconsistencia(ref PuntoAtencion tarifa)
        {
            InitializeComponent();

            _tarifa = tarifa;

            cboInconsistencia.ListaMostrada = _mantenimiento.listarInconsistenciaFacturacion();
        }
       
        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de guardar.
        /// </summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Verificar que se hayan seleccionado los datos

            if (cboInconsistencia.Text.Equals(string.Empty))
            {
                Excepcion.mostrarMensaje("ErrorCamaraDatosRegistro");
                return;
            }

            try
            {
                frmBandejaInconsistenciasFacturacion padre = (frmBandejaInconsistenciasFacturacion)this.Owner;

                InconsistenciaFacturacion identificador = (InconsistenciaFacturacion)cboInconsistencia.SelectedItem;
               

                // Verificar si la camará ya está registrada

              
                    // Actualizar los datos de la cámara

                //_tarifa.Inconsistencia = identificador;

                    //padre.actualizarLista();
                    Mensaje.mostrarMensaje("MensajeCamaraConfirmacionActualizacion");
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
