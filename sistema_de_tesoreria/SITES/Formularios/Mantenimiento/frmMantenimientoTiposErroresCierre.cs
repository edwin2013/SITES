//
//  @ Project : 
//  @ File Name : frmMantenimientoTiposErroresCierreCajero.cs
//  @ Date : 05/02/2012
//  @ Author : Erick Chavarría 
//

using System;
using System.Windows.Forms;

using CommonObjects;
using BussinessLayer;
using LibreriaMensajes;

namespace GUILayer
{

    public partial class frmMantenimientoTiposErroresCierre : Form
    {

        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;

        private TipoErrorCierre _tipo = null;

        #endregion Atributos

        #region Constructor

        public frmMantenimientoTiposErroresCierre()
        {
            InitializeComponent();
        }

        public frmMantenimientoTiposErroresCierre(TipoErrorCierre tipo)
        {
            InitializeComponent();

            _tipo = tipo;

            txtNombre.Text = _tipo.Nombre;
            txtDescripcion.Text = _tipo.Descripcion;
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
                Excepcion.mostrarMensaje("ErrorTipoErrorCierreDatosRegistro");
                return;
            }

            try
            {
                string nombre = txtNombre.Text;
                string descripcion = txtDescripcion.Text;

                frmAdministracionTiposErroresCierre padre = (frmAdministracionTiposErroresCierre)this.Owner;

                // Verificar si el tipo de error ya está registrado

                if (_tipo == null)
                {
                    // Agregar los datos del tipo de error

                    if (Mensaje.mostrarMensajeConfirmacion("MensajeTipoErrorCierreRegistro") == DialogResult.Yes)
                    {
                        TipoErrorCierre nuevo = new TipoErrorCierre(nombre, descripcion);

                        _mantenimiento.agregarTipoError(ref nuevo);

                        padre.agregarTipoError(nuevo);
                        Mensaje.mostrarMensaje("MensajeTipoErrorCierreConfirmacionRegistro");
                        this.Close();
                    }

                }
                else
                {
                    // Actualizar los datos del tipo de error

                    TipoErrorCierre copia = new TipoErrorCierre(_tipo.Id, nombre, descripcion);

                    _mantenimiento.actualizarTipoError(copia);

                    _tipo.Nombre = nombre;
                    _tipo.Descripcion = descripcion;

                    padre.actualizarLista();
                    Mensaje.mostrarMensaje("MensajeTipoErrorCierreConfirmacionActualizacion");
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
