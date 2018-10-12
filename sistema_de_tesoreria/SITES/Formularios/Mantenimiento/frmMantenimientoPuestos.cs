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

namespace GUILayer.Formularios.Mantenimiento
{
    public partial class frmMantenimientoPuestos : Form
    {

        #region Atributos

        private SeguridadBL _seguridad = SeguridadBL.Instancia;

        private PuestoColaborador _puesto = null;

        #endregion Atributos

        #region Constructor
        public frmMantenimientoPuestos()
        {
            InitializeComponent();
        }

        public frmMantenimientoPuestos(PuestoColaborador puesto)
        {
            InitializeComponent();

            _puesto = puesto;

            txtNombre.Text = _puesto.Nombre;
        }

        #endregion Constructor


        #region Eventos
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Verificar que se hayan seleccionado los datos

            if (txtNombre.Text.Equals(string.Empty))
            {
                Excepcion.mostrarMensaje("ErrorPuestoDatosRegistro");
                return;
            }

            try
            {
                string nombre = txtNombre.Text;

                frmAdministracionPuestos padre = (frmAdministracionPuestos)this.Owner;

                // Si el puesto es un nuevo

                if (_puesto == null)
                {
                    // Agregar el puesto

                    if (Mensaje.mostrarMensajeConfirmacion("MensajePuestoRegistro") == DialogResult.Yes)
                    {
                        PuestoColaborador nuevo = new PuestoColaborador(nombre: nombre);
                                               
                        _seguridad.agregarPuestos(ref nuevo);

                        padre.agregarPuesto(nuevo);
                        Mensaje.mostrarMensaje("MensajePuestoConfirmacionRegistro");
                        this.Close();
                    }

                }
                else
                {
                    // Actualizar los datos del puesto

                    PuestoColaborador copia = new PuestoColaborador(id: _puesto.ID, nombre: nombre);

                    _seguridad.actualizarNombrePuesto(copia);

                    _puesto.Nombre = nombre;
                   
                    padre.actualizarLista();
                    Mensaje.mostrarMensaje("MensajePuestoConfirmacionActualizacion");
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
