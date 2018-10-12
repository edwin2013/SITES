using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonObjects.Clases;
using CommonObjects;
using LibreriaMensajes;
using BussinessLayer;

namespace GUILayer.Formularios.Blindados
{
    public partial class frmCargaTripulacion : Form
    {
        #region Atributos

        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;

        #endregion Atributos

        #region Constructor

        public frmCargaTripulacion(PedidoBancos carga, Colaborador colaborador, bool solo_lectura)
        {
            InitializeComponent();

            dgvTripulaciones.AutoGenerateColumns = false;

            carga.ListaTripulacion.Clear();
            dgvTripulaciones.DataSource = carga.ListaTripulacion;
            dgvTripulaciones.ReadOnly = solo_lectura;
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

      
        #endregion Eventos

    }
}
