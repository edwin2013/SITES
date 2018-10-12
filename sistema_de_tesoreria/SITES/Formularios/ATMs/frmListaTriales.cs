//
//  @ Project : 
//  @ File Name : frmListaTriales.cs
//  @ Date : 16/02/2013
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

    public partial class frmListaTriales : Form
    {

        #region Atributos

        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;

        #endregion Atributos

        #region Constructor

        public frmListaTriales()
        {
            InitializeComponent();

            dgvTriales.AutoGenerateColumns = false;
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
                bool full = chkATMsFull.Checked;

                dgvTriales.DataSource = _coordinacion.listarTrialesDescargasATMs(fecha, full);
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
