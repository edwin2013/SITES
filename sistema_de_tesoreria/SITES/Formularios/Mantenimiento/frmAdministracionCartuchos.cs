//
//  @ Project : 
//  @ File Name : frmAdministracionCartuchos.cs
//  @ Date : 01/08/2012
//  @ Author : Erick Chavarría 
//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

using CommonObjects;
using BussinessLayer;
using LibreriaMensajes;

namespace GUILayer
{

    public partial class frmAdministracionCartuchos : Form
    {

        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;

        #endregion Atributos

        #region Constructor

        public frmAdministracionCartuchos()
        {
            InitializeComponent();

            try
            {
                // Cargar la lista de cartuchos

                dgvCartuchos.AutoGenerateColumns = false;
                dgvCartuchos.DataSource = _mantenimiento.listarCartuchos();
            }
            catch (Exception ex)
            {
                this.Close();
                throw ex;
            }

        }

        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de agregar un cartucho.
        /// </summary>
        private void btnNuevo_Click(object sender, EventArgs e)
        {

            try
            {
                frmMantenimientoCartuchos formulario = new frmMantenimientoCartuchos();

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de modificar un cartucho.
        /// </summary>
        private void btnModificar_Click(object sender, EventArgs e)
        {
            this.mostarVentanaModificacion();
        }

        /// <summary>
        /// Clic en el botón de eliminar un cartucho.
        /// </summary>
        private void btnEliminar_Click(object sender, EventArgs e)
        {

            try
            {
                if (Mensaje.mostrarMensajeConfirmacion("MensajeCartuchoEliminacion") == DialogResult.Yes)
                {
                    Cartucho cartucho = (Cartucho)dgvCartuchos.SelectedRows[0].DataBoundItem;

                    _mantenimiento.eliminarCartucho(cartucho);

                    dgvCartuchos.Rows.Remove(dgvCartuchos.SelectedRows[0]);
                    Mensaje.mostrarMensaje("MensajeCartuchoConfirmacionEliminacion");
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

        #region Métodos Privados

        /// <summary>
        /// Mostrar la ventana de modificación.
        /// </summary>
        public void mostarVentanaModificacion()
        {

            try
            {
                if (dgvCartuchos.SelectedRows.Count > 0)
                {
                    Cartucho cartucho = (Cartucho)dgvCartuchos.SelectedRows[0].DataBoundItem;
                    frmMantenimientoCartuchos formulario = new frmMantenimientoCartuchos(cartucho);

                    formulario.ShowDialog(this);
                }

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Doble clic en la lista de cartuchos.
        /// </summary>
        private void dgvCartuchos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1) this.mostarVentanaModificacion();
        }

        /// <summary>
        /// Se selecciona otro cartucho de la lista de cartuchos.
        /// </summary>
        private void dgvCartuchos_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvCartuchos.SelectedRows.Count > 0)
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

        #endregion Métodos Privados

        #region Métodos Públicos

        /// <summary>
        /// Actualizar las lista de cartuchos.
        /// </summary>
        public void actualizarLista()
        {
            dgvCartuchos.Refresh();
            dgvCartuchos.AutoResizeColumns();
        }

        /// <summary>
        /// Agregar un cartucho a la lista.
        /// </summary>
        public void agregarCartucho(Cartucho cartucho)
        {
            BindingList<Cartucho> cartuchos = (BindingList<Cartucho>)dgvCartuchos.DataSource;

            cartuchos.Add(cartucho);
        }

        #endregion Métodos Públicos

    }

}
