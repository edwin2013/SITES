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

namespace GUILayer.Formularios.Blindados
{
    public partial class frmMantenimientoEsperas : Form
    {
        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;

        private Espera _Espera = null;

        #endregion Atributos

        #region Constructor

        public frmMantenimientoEsperas()
        {
            InitializeComponent();
        }

        public frmMantenimientoEsperas(Espera Espera)
        {
            InitializeComponent();

            _Espera = Espera;

            txtCodigo.Text = _Espera.Identificador;
            txtDescripcion.Text = _Espera.Descripcion; 
        }
       
        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de guardar.
        /// </summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Verificar que se hayan seleccionado los datos

            if (txtCodigo.Text.Equals(string.Empty))
            {
                Excepcion.mostrarMensaje("ErrorEsperaDatosRegistro");
                return;
            }

            try
            {
                frmAdministracionEsperas padre = (frmAdministracionEsperas)this.Owner;

                string identificador = txtCodigo.Text;
                string descripcion = txtDescripcion.Text;

                // Verificar si la camará ya está registrada

                if (_Espera == null)
                {
                    // Agregar la cámara

                    if (Mensaje.mostrarMensajeConfirmacion("MensajeEsperaRegistro") == DialogResult.Yes)
                    {
                        Espera nueva = new Espera(identificador, descripcion:descripcion);

                        _mantenimiento.agregarEspera(ref nueva);
                        padre.agregarEspera(nueva);

                        Mensaje.mostrarMensaje("MensajeEsperaConfirmacionRegistro");
                        this.Close();
                    }

                }
                else
                {
                    // Actualizar los datos de la cámara

                    Espera copia = new Espera(identificador, id: _Espera.ID, descripcion: descripcion);

                    _mantenimiento.actualizarEspera(copia);

                    _Espera.Identificador = identificador;
                    _Espera.Descripcion = descripcion;

                    padre.actualizarLista();
                    Mensaje.mostrarMensaje("MensajeEsperaConfirmacionActualizacion");
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
