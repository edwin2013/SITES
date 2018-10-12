//
//  @ Project : 
//  @ File Name : frmAdministracionClientes.cs
//  @ Date : 01/06/2011
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

    public partial class frmAdministracionClientes : Form
    {

        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        
        #endregion Atributos

        #region Constructor

        public frmAdministracionClientes()
        {
            InitializeComponent();

            try
            {
                // Cargar la lista de clientes

                dgvClientes.AutoGenerateColumns = false;
                dgvClientes.DataSource = _mantenimiento.listarClientes(string.Empty);
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
                string buscado = txtBuscar.Text;

                dgvClientes.DataSource = _mantenimiento.listarClientes(buscado);
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
                frmMantenimientoClientes formulario = new frmMantenimientoClientes();

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
                if (Mensaje.mostrarMensajeConfirmacion("MensajeClienteEliminacion") == DialogResult.Yes)
                {
                    Cliente cliente = (Cliente)dgvClientes.SelectedRows[0].DataBoundItem;

                    _mantenimiento.eliminarCliente(cliente);

                    dgvClientes.Rows.Remove(dgvClientes.SelectedRows[0]);
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

            if (dgvClientes.SelectedRows.Count > 0)
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
        public void mostarVentanaModificacion()
        {

            try
            {
                if (dgvClientes.SelectedRows.Count > 0)
                {
                    Cliente cliente = (Cliente)dgvClientes.SelectedRows[0].DataBoundItem;
                    frmMantenimientoClientes formulario = new frmMantenimientoClientes(cliente);

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
            dgvClientes.Refresh();
            dgvClientes.AutoResizeColumns();
        }

        /// <summary>
        /// Agregar un cliente a la lista.
        /// </summary>
        public void agregarCliente(Cliente cliente)
        {
            BindingList<Cliente> clientes = (BindingList<Cliente>)dgvClientes.DataSource;

            clientes.Add(cliente);
        }

        #endregion Métodos Públicos

      

    }

}
