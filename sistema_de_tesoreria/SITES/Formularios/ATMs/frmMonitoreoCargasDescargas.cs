//
//  @ Project : 
//  @ File Name : frmMonitoreoCargasDescargas.cs
//  @ Date : 08/03/2013
//  @ Author : Erick Chavarría 
//

using System;
using System.Windows.Forms;

using BussinessLayer;
using LibreriaMensajes;

namespace GUILayer
{

    public partial class frmMonitoreoCargasDescargas : Form
    {

        #region Atributos

        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;

        #endregion Atributos

        #region Constructor

        public frmMonitoreoCargasDescargas()
        {
            InitializeComponent();
        }

        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de actualizar.
        /// </summary>
        private void btnActualizar_Click(object sender, EventArgs e)
        {

            try
            {
                DateTime fecha = dtpFecha.Value;

                dgvCargasDescargas.DataSource = _coordinacion.obtenerDatosMonitoreoCargasDescargas(fecha);
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
