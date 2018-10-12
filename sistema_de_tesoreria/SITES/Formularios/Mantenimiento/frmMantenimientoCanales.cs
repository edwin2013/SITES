//
//  @ Project : 
//  @ File Name : frmMantenimientoCanales.cs
//  @ Date : 07/08/2011
//  @ Author : Erick Chavarría 
//

using System;
using System.Windows.Forms;

using CommonObjects;
using BussinessLayer;
using LibreriaMensajes;

namespace GUILayer
{

    public partial class frmMantenimientoCanales : Form
    {

        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;

        private Canal _canal = null;

        #endregion Atributos

        #region Constructor

        public frmMantenimientoCanales()
        {
            InitializeComponent();
        }

        public frmMantenimientoCanales(Canal canal)
        {
            InitializeComponent();

            _canal = canal;

            txtNombre.Text = _canal.Nombre;
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
                Excepcion.mostrarMensaje("ErrorCanalDatosRegistro");
                return;
            }

            try
            {
                string nombre = txtNombre.Text;

                frmAdministracionCanales padre = (frmAdministracionCanales)this.Owner;

                // Verificar si el canal ya está registrado

                if (_canal == null)
                {
                    // Agregar los datos del canal

                    if (Mensaje.mostrarMensajeConfirmacion("MensajeCanalRegistro") == DialogResult.Yes)
                    {
                        Canal nuevo = new Canal(nombre);

                        _mantenimiento.agregarCanal(ref nuevo);

                        padre.agregarCanal(nuevo);
                        Mensaje.mostrarMensaje("MensajeCanalConfirmacionRegistro");
                        this.Close();
                    }

                }
                else
                {
                    // Actualizar los datos del canal

                    Canal copia = new Canal(_canal.Id, nombre);

                    _mantenimiento.actualizarCanal(copia);

                    _canal.Nombre = nombre;

                    padre.actualizarLista();
                    Mensaje.mostrarMensaje("MensajeCanalConfirmacionActualizacion");
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
