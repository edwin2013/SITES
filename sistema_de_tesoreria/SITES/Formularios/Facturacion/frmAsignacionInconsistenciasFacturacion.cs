using BussinessLayer;
using CommonObjects;
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
    public partial class frmAsignacionInconsistenciasFacturacion : Form
    {
        #region Atributos

        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;
        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;

        private PuntoAtencion _canal = null;
        private Colaborador _usuario = null;

        #endregion Atributos

        #region Constructor

        public frmAsignacionInconsistenciasFacturacion()
        {
            InitializeComponent();

            cboInconsistencia.ListaMostrada = _mantenimiento.listarInconsistenciaFacturacion();
        }

        public frmAsignacionInconsistenciasFacturacion(ref PuntoAtencion canal, Colaborador c)
        {
            InitializeComponent();
            cboInconsistencia.ListaMostrada = _mantenimiento.listarInconsistenciaFacturacion();
            _canal = canal;
            _usuario = c;

            txtPuntoVenta.Text = _canal.Nombre;
            txtTransportadora.Text = _canal.Transportadora.ToString();
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
                Excepcion.mostrarMensaje("ErrorCanalDatosRegistro");
                return;
            }

            try
            {
                InconsistenciaFacturacion inc = (InconsistenciaFacturacion)cboInconsistencia.SelectedItem;
                string observaciones = txtObservaciones.Text;
                EstadosInconsistencias estadito = EstadosInconsistencias.Verificada;

               

                frmBandejaInconsistenciasFacturacion padre = (frmBandejaInconsistenciasFacturacion)this.Owner;

                // Verificar si el canal ya está registrado

                if (_canal != null)
                {
                    // Agregar los datos del canal

                    if (Mensaje.mostrarMensajeConfirmacion("MensajeInsercionInconsistenciaFacturacion") == DialogResult.Yes)
                    {
                        RegistroInconsistenciaFacturacion nuevo = new RegistroInconsistenciaFacturacion(usuarioregistro:_usuario, inc: inc, est: estadito, observaciones: observaciones, p: _canal);

                        _coordinacion.agregarRegistroInconsistenciaFacturacion(ref nuevo);


                        Mensaje.mostrarMensaje("MensajeConfirmacionInsercionInconsistenciaFacturacion");
                        this.Close();
                    }

                }
                
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


        /// <summary>
        /// Descarta una inconsistencia
        /// </summary>
        private void btnDescartar_Click(object sender, EventArgs e)
        {
            if (cboInconsistencia.Text.Equals(string.Empty))
            {
                Excepcion.mostrarMensaje("ErrorCanalDatosRegistro");
                return;
            }

            try
            {
                InconsistenciaFacturacion inc = (InconsistenciaFacturacion)cboInconsistencia.SelectedItem;
                string observaciones = txtObservaciones.Text;
                EstadosInconsistencias estadito = EstadosInconsistencias.Descartada;



                frmBandejaInconsistenciasFacturacion padre = (frmBandejaInconsistenciasFacturacion)this.Owner;

                // Verificar si el canal ya está registrado

                if (_canal == null)
                {
                    // Agregar los datos del canal

                    if (Mensaje.mostrarMensajeConfirmacion("MensajeCanalRegistro") == DialogResult.Yes)
                    {
                        RegistroInconsistenciaFacturacion nuevo = new RegistroInconsistenciaFacturacion(usuarioregistro: _usuario, inc: inc, est: estadito, observaciones: observaciones, p: _canal);

                        _coordinacion.agregarRegistroInconsistenciaFacturacion(ref nuevo);


                        Mensaje.mostrarMensaje("MensajeCanalConfirmacionRegistro");
                        this.Close();
                    }

                }

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }


        #endregion Eventos


        

        #region Métodos Privados

        #endregion Métodos Privados
    }
}
