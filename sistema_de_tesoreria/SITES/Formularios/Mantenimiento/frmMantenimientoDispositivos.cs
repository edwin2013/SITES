using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LibreriaMensajes;
using CommonObjects.Clases;
using BussinessLayer;

namespace GUILayer.Formularios.Mantenimiento
{
    public partial class frmMantenimientoDispositivos : Form
    {
        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;

        private Dispositivo _dispositivo = null;

        #endregion Atributos

        #region Constructor

        public frmMantenimientoDispositivos()
        {
            InitializeComponent();
        }

        public frmMantenimientoDispositivos(Dispositivo dispositivo)
        {
            InitializeComponent();

            _dispositivo = dispositivo;

            txtNombre.Text = _dispositivo.Serial;
        }

        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de guardar.
        /// </summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Verificar que se hayan seleccionado los datos

            if (txtNombre.Text.Equals(string.Empty)|| (txtDescripcion.Text.Equals(string.Empty)))
            {
                Excepcion.mostrarMensaje("ErrorDispositivoRegistro");
                return;
            }

            try
            {
                string nombre = txtNombre.Text;
                string descripcion = txtDescripcion.Text;

                frmAdministracionDispositivos padre = (frmAdministracionDispositivos)this.Owner;

                // Verificar si el dispositivo ya está registrado

                if (_dispositivo == null)
                {
                    // Agregar los datos del dispositivo

                    if (Mensaje.mostrarMensajeConfirmacion("MensajeDispositivoRegistro") == DialogResult.Yes)
                    {
                        Dispositivo nuevo = new Dispositivo(nombre,descripcion:descripcion);

                        _mantenimiento.agregarDispositivo(ref nuevo);

                        padre.agregarDispositivo(nuevo);
                        Mensaje.mostrarMensaje("MensajeDispositivoConfirmacionRegistro");
                        this.Close();
                    }

                }
                else
                {
                    // Actualizar los datos del dispositivo

                    Dispositivo copia = new Dispositivo(nombre, descripcion: descripcion, id:_dispositivo.ID);

                    _mantenimiento.actualizarDispositivo(copia);

                    _dispositivo.Serial = nombre;
                    _dispositivo.Descripcion = descripcion;

                    padre.actualizarLista();
                    Mensaje.mostrarMensaje("MensajeDispositivoConfirmacionActualizacion");
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
