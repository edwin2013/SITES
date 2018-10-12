using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BussinessLayer;
using LibreriaMensajes;
using CommonObjects;
using CommonObjects.Clases;

namespace GUILayer.Formularios.Blindados
{
    public partial class frmAsignarRuta : Form
    {
        #region Atributos

        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;

        private BindingList<CargaATM> _cargas_ATMs = null;
        private BindingList<CargaATM> _cargas_Sucursales = null;

        #endregion Atributos

        #region Constructor

        public frmAsignarRuta(BindingList<CargaATM> cargas)
        {
            InitializeComponent();

            _cargas_ATMs = cargas;

            lsATMs.DataSource = _cargas_ATMs;

             foreach (CargaATM carga in _cargas_ATMs)
            {
                this.nudRuta.Value = Convert.ToDecimal(carga.Ruta);
                this.dtpHora.Value = carga.Hora_Llegada;
            }
        }


        public frmAsignarRuta(BindingList<CargaSucursal> cargas)
        {
            InitializeComponent();

            //_cargas_Sucursales = cargas;

            //lsATMs.DataSource = _cargas_Sucursales;
        }
        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de guardar.
        /// </summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {

            try
            {
                byte ruta = (byte)nudRuta.Value;
                DateTime hora = dtpHora.Value;
       
                foreach (CargaATM carga in _cargas_ATMs)
                {
                    carga.Ruta = ruta;
                    carga.Hora_Llegada = hora;

                    _coordinacion.actualizarCargaATMRutaHora(carga);
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
