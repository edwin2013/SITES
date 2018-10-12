//
//  @ Project : 
//  @ File Name : frmMantenimientoPerfiles.cs
//  @ Date : 14/09/2012
//  @ Author : Erick Chavarría 
//

using System;
using System.ComponentModel;
using System.Windows.Forms;

using CommonObjects;
using BussinessLayer;
using LibreriaMensajes;

namespace GUILayer
{

    public partial class frmMantenimientoPerfiles : Form
    {

        #region Atributos

        private SeguridadBL _seguridad = SeguridadBL.Instancia;

        private Perfil _perfil = null;

        #endregion Atributos

        #region Constructor

        public frmMantenimientoPerfiles()
        {
            InitializeComponent();

            try
            {
                // Cargar la lista de opciones

                this.cargarDatos();
            }
            catch (Exception ex)
            {
                this.Close();
                throw ex;
            }

        }

        public frmMantenimientoPerfiles(Perfil perfil)
        {
            InitializeComponent();

            _perfil = perfil;

            txtNombre.Text = _perfil.Nombre;

            try
            {
                // Cargar las opciones de acceso

                this.cargarDatos();

                // Asignar las opciones actuales del perfil

                for (int i = 0; i < clbOpciones.Items.Count; i++)
                {
                    Opcion opcion = (Opcion)clbOpciones.Items[i];
                    bool estado = _perfil.Opciones.Contains(opcion);

                    clbOpciones.SetItemChecked(i, estado);
                }

            }
            catch (Exception ex)
            {
                this.Close();
                throw ex;
            }

        }

        /// <summary>
        /// Mostrar las opciones de acceso.
        /// </summary>
        private void cargarDatos()
        {

            try
            {
                // Cargar la lista de opciones

                BindingList<Opcion> opciones = _seguridad.listarOpciones();

                foreach (Opcion opcion in opciones)
                    clbOpciones.Items.Add(opcion);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de guardar.
        /// </summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Verificar que se hayan seleccionado los datos

            if ((txtNombre.Text.Equals(string.Empty)) ||
                (clbOpciones.CheckedItems.Count == 0))
            {
                Excepcion.mostrarMensaje("ErrorPerfilDatosRegistro");
                return;
            }

            try
            {
                string nombre = txtNombre.Text;

                frmAdministracionPerfiles padre = (frmAdministracionPerfiles)this.Owner;

                // Si el perfil es un nuevo

                if (_perfil == null)
                {
                    // Agregar el perfil

                    if (Mensaje.mostrarMensajeConfirmacion("MensajePerfilRegistro") == DialogResult.Yes)
                    {
                        Perfil nuevo = new Perfil(nombre: nombre);

                        foreach (Opcion opcion in clbOpciones.CheckedItems)
                            nuevo.agregarOpcion(opcion);

                        _seguridad.agregarPerfil(ref nuevo);

                        padre.agregarPerfil(nuevo);
                        Mensaje.mostrarMensaje("MensajePerfilConfirmacionRegistro");
                        this.Close();
                    }

                }
                else
                {
                    // Actualizar los datos del perfil

                    Perfil copia = new Perfil(id: _perfil.ID, nombre: nombre);

                    foreach (Opcion opcion in clbOpciones.CheckedItems)
                        copia.agregarOpcion(opcion);

                    _seguridad.actualizarPerfil(copia);

                    _perfil.Nombre = nombre;
                    _perfil.Opciones = copia.Opciones;

                    padre.actualizarLista();
                    Mensaje.mostrarMensaje("MensajePerfilConfirmacionActualizacion");
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
