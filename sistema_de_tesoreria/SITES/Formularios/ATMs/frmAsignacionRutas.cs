//
//  @ Project : 
//  @ File Name : frmRegistroCarga.cs
//  @ Date : 21/06/2011
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

    public partial class frmAsignacionRutas : Form
    {

        #region Atributos

        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;

        private BindingList<CargaATM> _cargas = null;

        #endregion Atributos

        #region Constructor

        public frmAsignacionRutas(BindingList<CargaATM> cargas)
        {
            InitializeComponent();

            _cargas = cargas;

            lsATMs.DataSource = _cargas;

           
        }

        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de guardat.
        /// </summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {

            try
            {
                byte ruta = (byte)nudRuta.Value;

                foreach (CargaATM carga in _cargas)
                {
                    carga.Ruta = ruta;

                    _coordinacion.actualizarCargaATMRuta(carga);
                }

                this.Close();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de modificar ATM.
        /// </summary>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion Eventos

    }

}
