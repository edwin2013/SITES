//
//  @ Project : 
//  @ File Name : frmAdministracionPerfiles.cs
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

    public partial class frmAdministracionPerfiles : Form
    {

        #region Atributos

        private SeguridadBL _seguridad = SeguridadBL.Instancia;

        #endregion Atributos

        #region Constructor

        public frmAdministracionPerfiles()
        {
            InitializeComponent();

            try
            {
                dgvPerfiles.AutoGenerateColumns = false;
                dgvPerfiles.DataSource = _seguridad.listarPerfiles();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de nuevo perfil.
        /// </summary>
        private void btnNuevo_Click(object sender, EventArgs e)
        {

            try
            {
                frmMantenimientoPerfiles formulario = new frmMantenimientoPerfiles();

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de modificar.
        /// </summary>
        private void btnModificar_Click(object sender, EventArgs e)
        {
            this.mostrarVentanaModificacion();
        }

        /// <summary>
        /// Clic en el botón de eliminar.
        /// </summary>
        private void btnEliminar_Click(object sender, EventArgs e)
        {

            try
            {
                if (Mensaje.mostrarMensajeConfirmacion("MensajePerfilEliminacion") == DialogResult.Yes)
                {
                    Perfil perfil = (Perfil)dgvPerfiles.SelectedRows[0].DataBoundItem;

                    _seguridad.eliminarPerfil(perfil);

                    dgvPerfiles.Rows.Remove(dgvPerfiles.SelectedRows[0]);
                    Mensaje.mostrarMensaje("MensajePerfilConfirmacionEliminacion");
                }

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
                ;
            }

        }

        /// <summary>
        /// Clic en el botón de salir.
        /// </summary>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Doble clic en la lista de perfiles.
        /// </summary>
        private void dgvPerfiles_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1) this.mostrarVentanaModificacion();
        }

        /// <summary>
        /// Se selecciona otro perfil.
        /// </summary>
        private void dgvPerfiles_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvPerfiles.RowCount > 0)
            {
                btnEliminar.Enabled = true;
                btnModificar.Enabled = true;
            }
            else
            {
                btnEliminar.Enabled = false;
                btnModificar.Enabled = false;
            }

        }

        #endregion Eventos

        #region Métodos Privados

        /// <summary>
        /// Mostrar la ventana de modificación.
        /// </summary>
        public void mostrarVentanaModificacion()
        {

            try
            {

                if (dgvPerfiles.SelectedRows.Count > 0)
                {
                    Perfil perfil = (Perfil)dgvPerfiles.SelectedRows[0].DataBoundItem;
                    frmMantenimientoPerfiles formulario = new frmMantenimientoPerfiles(perfil);

                    formulario.ShowDialog(this);
                }

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        #endregion Métodos Privados

        #region Métodos Públicos

        /// <summary>
        /// Actualizar la lista de perfiles.
        /// </summary>
        public void actualizarLista()
        {
            dgvPerfiles.Refresh();
            dgvPerfiles.AutoResizeColumns();
        }

        /// <summary>
        /// Agregar un perfil a la lista.
        /// </summary>
        public void agregarPerfil(Perfil perfil)
        {
            BindingList<Perfil> perfiles = (BindingList<Perfil>)dgvPerfiles.DataSource;

            perfiles.Add(perfil);
        }

        #endregion Métodos Públicos

    }

}
