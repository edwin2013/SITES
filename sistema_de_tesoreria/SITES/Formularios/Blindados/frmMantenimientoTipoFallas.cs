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
    public partial class frmMantenimientoTipoFallas : Form
    {
         #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;

        private TipoFallasBlindados _TipoFallasBlindados = null;

        #endregion Atributos

        #region Constructor

        public frmMantenimientoTipoFallas()
        {
            InitializeComponent();
        }

        public frmMantenimientoTipoFallas(TipoFallasBlindados TipoFallasBlindados)
        {
            InitializeComponent();

            _TipoFallasBlindados = TipoFallasBlindados;

            txtDescripcion.Text = _TipoFallasBlindados.Descripcion; 
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
                Excepcion.mostrarMensaje("ErrorTipoFallasBlindadosDatosRegistro");
                return;
            }

            try
            {
                frmAdministracionTipoFallas padre = (frmAdministracionTipoFallas)this.Owner;

                string descripcion = txtDescripcion.Text;

                // Verificar si la camará ya está registrada

                if (_TipoFallasBlindados == null)
                {
                    // Agregar la cámara

                    if (Mensaje.mostrarMensajeConfirmacion("MensajeTipoFallasBlindadosRegistro") == DialogResult.Yes)
                    {
                        TipoFallasBlindados nueva = new TipoFallasBlindados(descripcion:descripcion);

                        _mantenimiento.agregarTipoFallasBlindados(ref nueva);
                        padre.agregarTipoFallasBlindados(nueva);

                        Mensaje.mostrarMensaje("MensajeTipoFallasBlindadosConfirmacionRegistro");
                        this.Close();
                    }

                }
                else
                {
                    // Actualizar los datos de la cámara

                    TipoFallasBlindados copia = new TipoFallasBlindados(id: _TipoFallasBlindados.ID, descripcion: descripcion);

                    _mantenimiento.actualizarTipoFallasBlindados(copia);


                    _TipoFallasBlindados.Descripcion = descripcion;

                    padre.actualizarLista();
                    Mensaje.mostrarMensaje("MensajeTipoFallasBlindadosConfirmacionActualizacion");
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
