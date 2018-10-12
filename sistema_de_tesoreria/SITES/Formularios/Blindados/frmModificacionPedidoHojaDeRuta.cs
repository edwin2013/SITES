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
    public partial class frmModificacionPedidoHojaDeRuta : Form
    {

        #region Atributos

        private Carga _carga = null;
        private Colaborador _colaborador = null;
        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;

        #endregion Atributos

        #region Constructor

        public frmModificacionPedidoHojaDeRuta(Carga carga, Colaborador usuario)
        {
            _carga = carga;


            if (carga.HoraEntregaBoveda != null)
                dtpHoraLlegada.Value = carga.HoraEntregaBoveda.Value;

            if (carga.HoraRecibidoBoveda != null)
                dtpHoraSalida.Value = carga.HoraRecibidoBoveda.Value;

            if (carga.HoraInicioAtencionPunto != null)
                dtpHoraInicioPunto.Value = carga.HoraInicioAtencionPunto.Value;

            if (carga.HoraFinalAtencionPunto != null)
                dtpHoraFinalPunto.Value = carga.HoraFinalAtencionPunto.Value;



            _colaborador = usuario;
            InitializeComponent();
            cargarDatos();
        }

        public frmModificacionPedidoHojaDeRuta()
        {
            InitializeComponent();
        }

        #endregion Constructor

        #region Metodos Privados

        /// <summary>
        /// Carga los datos de una carga respectiva
        /// </summary>
        private void cargarDatos()
        {
            dtpHoraLlegada.Value  = _carga.HoraEntregaBoveda ?? DateTime.Now;
            dtpHoraSalida.Value = _carga.HoraRecibidoBoveda ?? DateTime.Now;
            dtpHoraInicioPunto.Value = _carga.HoraInicioAtencionPunto ?? DateTime.Now;
            dtpHoraFinalPunto.Value = _carga.HoraFinalAtencionPunto ?? DateTime.Now;
        }

        #endregion Metodos Privados

        #region Eventos

        /// <summary>
        /// Clic en el boton de modificar
        /// </summary>
        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime horasalidahangar = dtpHoraSalida.Value;
                DateTime horallegadahangar = dtpHoraLlegada.Value;
                DateTime horainiciopunto = dtpHoraInicioPunto.Value;
                DateTime horafinalpunto = dtpHoraFinalPunto.Value;

                _carga.HoraEntregaBoveda = horasalidahangar;
                _carga.HoraRecibidoBoveda = horallegadahangar;
                _carga.HoraInicioAtencionPunto = horainiciopunto;
                _carga.HoraFinalAtencionPunto = horafinalpunto;
                _carga.Observaciones = txtObservaciones.Text;

                _carga.HandHeld = rbHandHeld.Checked;
                _carga.Manual = rbManual.Checked;


                if (_carga.TipoCargas == TipoCargas.ATM)
                    _coordinacion.actualizarHorasHojaRuta(_carga);




            }
            catch (Excepcion ex)
            {
 
            }
        }

        #endregion Eventos
    }
}
