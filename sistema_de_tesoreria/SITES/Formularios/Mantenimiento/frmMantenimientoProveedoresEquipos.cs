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
    public partial class frmMantenimientoProveedoresEquipos : Form
    {
        #region Atributos

        private ProveedorEquipo _proveedor = null;
        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;

        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;

        #endregion Atributos

        #region Constructor
        public frmMantenimientoProveedoresEquipos()
        {
            InitializeComponent();
        }

        public frmMantenimientoProveedoresEquipos(ProveedorEquipo proveedor)
        {
            InitializeComponent();

            _proveedor = proveedor;
            txtDescripcion.Text = _proveedor.Nombre;
        }

        #endregion Constructor

        #region Eventos
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Verificar que se hayan seleccionado los datos

            if (txtDescripcion.Text.Equals(string.Empty))
            {
                Excepcion.mostrarMensaje("ErrorEstadoCartuchoDatosRegistro");
                return;
            }

            try
            {
                frmAdministracionProveedoresEquipos padre = (frmAdministracionProveedoresEquipos)this.Owner;

                string nombre = txtDescripcion.Text;

                // Verificar si el estado ya está registrado

                if (_proveedor == null)
                {
                    // Agregar la falla

                    if (Mensaje.mostrarMensajeConfirmacion("MensajeProveedorCartuchoRegistro") == DialogResult.Yes)
                    {
                        ProveedorEquipo nueva = new ProveedorEquipo(nombre: nombre);

                        _mantenimiento.agregarProveedorEquipo(ref nueva);

                        padre.agregarProveedorEquipo(nueva);

                        Mensaje.mostrarMensaje("MensajeProveedorCartuchoConfirmacionRegistro");
                        this.Close();
                    }

                }
                else
                {
                    // Actualizar los datos de la falla

                    ProveedorEquipo copia = new ProveedorEquipo(id: _proveedor.ID, nombre: nombre);

                    _mantenimiento.actualizarProveedorEquipo(ref copia);

                    _proveedor.Nombre = nombre;

                    padre.actualizarLista();
                    Mensaje.mostrarMensaje("MensajeProveedorCartuchoConfirmacionActualizacion");
                    this.Close();
                }

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        #endregion Eventos
    }
}
