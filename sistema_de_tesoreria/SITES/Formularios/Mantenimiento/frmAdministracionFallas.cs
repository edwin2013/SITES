using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BussinessLayer;
using LibreriaMensajes;
using CommonObjects.Clases;

namespace GUILayer.Formularios.Mantenimiento
{
    public partial class frmAdministracionFallas : Form
    {
       
        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        
        #endregion Atributos

        #region Constructor

        public frmAdministracionFallas()
        {
            InitializeComponent();

            try
            {
                // Cargar la lista de fallas

                cboTipoFalla.ListaMostrada = _mantenimiento.listarTipoFallasBlindadoss();

                dgvFallas.AutoGenerateColumns = false;
                dgvFallas.DataSource = _mantenimiento.listarFalla(String.Empty, null);             
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
        /// Clic en el botón de actualizar.
        /// </summary>
        private void btnActualizar_Click(object sender, EventArgs e)
        {

            try
            {
                if (ValidateTipo())
                {
                    string buscado = txtBuscar.Text;
                    TipoFallasBlindados tipo = cboTipoFalla.SelectedIndex == 0 ?
                     null : (TipoFallasBlindados)cboTipoFalla.SelectedItem;
                    dgvFallas.DataSource = _mantenimiento.listarFalla(buscado, tipo);
                }
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de nuevo usuario.
        /// </summary>
        private void btnNuevo_Click(object sender, EventArgs e)
        {

            try
            {
                frmMantenimientoFallas formulario = new frmMantenimientoFallas();

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
            this.mostarVentanaModificacion();      
        }

        /// <summary>
        /// Clic en el botón de eliminar.
        /// </summary>
        private void btnEliminar_Click(object sender, EventArgs e)
        {

            try
            {
                if (Mensaje.mostrarMensajeConfirmacion("MensajeFallaEliminacion") == DialogResult.Yes)
                {
                    Falla falla = (Falla)dgvFallas.SelectedRows[0].DataBoundItem;

                    _mantenimiento.eliminarFalla(falla);

                    dgvFallas.Rows.Remove(dgvFallas.SelectedRows[0]);
                    Mensaje.mostrarMensaje("MensajeClienteConfirmacionEliminacion");
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

        /// <summary>
        /// Doble clic en la lista de clientes.
        /// </summary>
        private void dgvClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1) this.mostarVentanaModificacion();
        }

        /// <summary>
        /// Se selecciona otro cliente de la lista de clientes.
        /// </summary>
        private void dgvClientes_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvFallas.SelectedRows.Count > 0)
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
        /// Valida los campos 
        /// </summary>
        /// <returns>Si los campos estan correctos o no</returns>
        private bool ValidateTipo()
        {
            bool bStatus = true;
            if (cboTipoFalla.Text == "")
            {
                errorProvider1.SetError(cboTipoFalla, "Debe ingresar el tipo de falla ");
                bStatus = false;
            }
            else
                errorProvider1.SetError(cboTipoFalla, "");
            return bStatus;
        }


        /// <summary>
        /// Mostrar la ventana de modificación.
        /// </summary>
        public void mostarVentanaModificacion()
        {

            try
            {
                if (dgvFallas.SelectedRows.Count > 0)
                {
                    Falla falla = (Falla)dgvFallas.SelectedRows[0].DataBoundItem;
                    frmMantenimientoFallas formulario = new frmMantenimientoFallas(falla);

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
        /// Actualizar las lista de clientes.
        /// </summary>
        public void actualizarLista()
        {
            dgvFallas.Refresh();
            dgvFallas.AutoResizeColumns();
        }

        /// <summary>
        /// Agregar un cliente a la lista.
        /// </summary>
        public void agregarFalla(Falla falla)
        {
            BindingList<Falla> clientes = (BindingList<Falla>)dgvFallas.DataSource;

            clientes.Add(falla);
        }

        #endregion Métodos Públicos
    }
}
