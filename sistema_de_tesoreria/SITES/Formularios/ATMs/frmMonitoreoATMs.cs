//
//  @ Project : 
//  @ File Name : frmMonitoreoATMs.cs
//  @ Date : 20/02/2013
//  @ Author : Erick Chavarría 
//

using System;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Windows.Forms;

using CommonObjects;
using BussinessLayer;
using LibreriaMensajes;
namespace GUILayer
{
    public partial class frmMonitoreoATMs : Form
    {

        #region Atributos

        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;

        #endregion Atributos

        #region Constructor

        public frmMonitoreoATMs()
        {
            InitializeComponent();
        }

        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de salir.
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
                dgvMonitoreo.DataSource = _coordinacion.obtenerDatosMonitoreoATMs();
                dgvMonitoreo.AutoResizeColumns();

                foreach (DataGridViewColumn columna in dgvMonitoreo.Columns)
                    if (columna.ValueType == typeof(decimal))
                        columna.DefaultCellStyle.Format = "N2";
                
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        #endregion Eventos

    }

}
