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
    public partial class frmMantenimientoInconsistenciaFacturacion : Form
    {
        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;

        private InconsistenciaFacturacion _camara = null;

        #endregion Atributos

        #region Constructor

        public frmMantenimientoInconsistenciaFacturacion()
        {
            InitializeComponent();
        }

        public frmMantenimientoInconsistenciaFacturacion(InconsistenciaFacturacion camara)
        {
            InitializeComponent();

            _camara = camara;

            txtIdentificador.Text = _camara.Identificador;
            
        }
       
        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de guardar.
        /// </summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Verificar que se hayan seleccionado los datos

            if (txtIdentificador.Text.Equals(string.Empty))
            {
                Excepcion.mostrarMensaje("ErrorInconsistenciaFacturacionDatosRegistro");
                return;
            }

            try
            {
                frmAdministracionInconsistenciaFacturacion padre = (frmAdministracionInconsistenciaFacturacion)this.Owner;

                string identificador = txtIdentificador.Text;
 

                // Verificar si la camará ya está registrada

                if (_camara == null)
                {
                    // Agregar la cámara

                    if (Mensaje.mostrarMensajeConfirmacion("MensajeInconsistenciaFacturacionRegistro") == DialogResult.Yes)
                    {
                        InconsistenciaFacturacion nueva = new InconsistenciaFacturacion(identificador);

                        _mantenimiento.agregarInconsistenciaFacturacion(ref nueva);
                        padre.agregarInconsistenciaFacturacion(nueva);

                        Mensaje.mostrarMensaje("MensajeInconsistenciaFacturacionConfirmacionRegistro");
                        this.Close();
                    }

                }
                else
                {
                    // Actualizar los datos de la cámara

                    InconsistenciaFacturacion copia = new InconsistenciaFacturacion(identificador, id: _camara.ID);

                    _mantenimiento.actualizarInconsistenciaFacturacion(copia);

                    _camara.Identificador = identificador;
 

                    padre.actualizarLista();
                    Mensaje.mostrarMensaje("MensajeInconsistenciaFacturacionConfirmacionActualizacion");
                    this.Close();
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

        #endregion Eventos
    }
}
