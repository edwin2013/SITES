using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BussinessLayer;
using CommonObjects.Clases;
using LibreriaMensajes;

namespace GUILayer.Formularios.Mantenimiento
{
    public partial class frmMantenimientoManojo : Form
    {
        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;

        private Manojo _manojo = null;

        #endregion Atributos

        #region Constructor

        public frmMantenimientoManojo()
        {
            InitializeComponent();

        }

        public frmMantenimientoManojo(Manojo manojo)
        {
            InitializeComponent();

            _manojo = manojo;

            txtDescripcion.Text = _manojo.Descripcion;
        }
       
        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de guardar.
        /// </summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Verificar que se hayan seleccionado los datos

            if (txtDescripcion.Text.Equals(string.Empty))
            {
                Excepcion.mostrarMensaje("ErrorManojoDatosRegistro");
                return;
            }

            try
            {
                frmAdministracionManojos padre = (frmAdministracionManojos)this.Owner;

                string identificador = txtDescripcion.Text;

                // Verificar si la camará ya está registrada

                if (_manojo == null)
                {
                    // Agregar la cámara

                    if (Mensaje.mostrarMensajeConfirmacion("MensajeManojoRegistro") == DialogResult.Yes)
                    {
                        Manojo nueva = new Manojo(identificador);

                        _mantenimiento.agregarManojo(ref nueva);
                        padre.agregarManojo(nueva);

                        Mensaje.mostrarMensaje("MensajeManojoConfirmacionRegistro");
                        this.Close();
                    }

                }
                else
                {
                    // Actualizar los datos del manojo

                    Manojo copia = new Manojo( id: _manojo.ID, descripcion:identificador);

                    _mantenimiento.actualizarManojo(copia);

                    _manojo.Descripcion = identificador;


                    padre.actualizarLista();
                    Mensaje.mostrarMensaje("MensajeManojoConfirmacionActualizacion");
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
