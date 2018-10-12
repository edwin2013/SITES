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
    public partial class frmMantenimientoTipoEquipo : Form
    {
        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;

        private TipoEquipo _tipoequipo = null;

        #endregion Atributos

        #region Constructor

        public frmMantenimientoTipoEquipo()
        {
            InitializeComponent();
        }

        public frmMantenimientoTipoEquipo(TipoEquipo tipoequipo)
        {
            InitializeComponent();

            _tipoequipo = tipoequipo;

            txtNombre.Text = _tipoequipo.Descripcion;
            chkObligatorio.Checked = tipoequipo.Obligatorio;
        }

        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de guardar.
        /// </summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Verificar que se hayan seleccionado los datos

            if (txtNombre.Text.Equals(string.Empty))
            {
                Excepcion.mostrarMensaje("ErrorTipoEquipoRegistro");
                return;
            }

            try
            {
                string nombre = txtNombre.Text;
                bool obligatorio = chkObligatorio.Checked;

                frmAdministracionTipoEquipo padre = (frmAdministracionTipoEquipo)this.Owner;

                // Verificar si el tipoequipo ya está registrado

                if (_tipoequipo == null)
                {
                    // Agregar los datos del tipoequipo

                    if (Mensaje.mostrarMensajeConfirmacion("MensajeTipoEquipoRegistro") == DialogResult.Yes)
                    {
                        TipoEquipo nuevo = new TipoEquipo(nombre,obligatorio:obligatorio);

                        _mantenimiento.agregarTipoEquipo(ref nuevo);

                        padre.agregarTipoEquipo(nuevo);
                        Mensaje.mostrarMensaje("MensajeTipoEquipoConfirmacionRegistro");
                        this.Close();
                    }

                }
                else
                {
                    // Actualizar los datos del tipoequipo

                    TipoEquipo copia = new TipoEquipo(nombre,_tipoequipo.ID,obligatorio:obligatorio );

                    _mantenimiento.actualizarTipoEquipo(copia);

                    _tipoequipo.Descripcion = nombre;

                    padre.actualizarLista();
                    Mensaje.mostrarMensaje("MensajeTipoEquipoConfirmacionActualizacion");
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
