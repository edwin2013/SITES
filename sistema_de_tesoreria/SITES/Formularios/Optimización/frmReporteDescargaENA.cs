using BussinessLayer;
using LibreriaMensajes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GUILayer.Formularios.Optimización
{
    public partial class frmReporteDescargaENA : Form
    {

        #region Atributos

        CoordinacionBL _coordinacion = CoordinacionBL.Instancia;

        #endregion Atributos

        #region Constructor
        public frmReporteDescargaENA()
        {
            InitializeComponent();
        }

        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el botón salir
        /// </summary>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /// <summary>
        /// Clic en el botón de actualizar. 
        /// </summary>
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                int cantidad = (int)nudFormulas.Value;
                _coordinacion.descargasENA(cantidad);

                Mensaje.mostrarMensaje("MensajeActualizacionDescargasPapel");
            }
            catch(Excepcion ex)
            {

                Excepcion.mostrarMensaje("ErrorDatosConexion");
            }
        }

        #endregion Eventos
    }
}
