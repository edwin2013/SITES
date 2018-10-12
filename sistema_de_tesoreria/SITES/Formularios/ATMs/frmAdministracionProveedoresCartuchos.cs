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
using GUILayer.Formularios.ATMs;

namespace GUILayer.Formularios.Níquel
{
    public partial class frmAdministracionProveedoresCartuchos : Form
    {

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;

        private BindingList<ProveedorCartucho> _proveedores = new BindingList<ProveedorCartucho>();

        #region Constructor
        public frmAdministracionProveedoresCartuchos()
        {
            InitializeComponent();

            try
            {
                // Generar la lista de estados

                _proveedores = _mantenimiento.listarProveedorCartucho(string.Empty);

                dgvProveedoresCartuchos.AutoGenerateColumns = false;
                dgvProveedoresCartuchos.DataSource = _proveedores;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion Constructor

        #region Eventos
        private void gbFallasCartuchos_Enter(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmMantenimientoProveedoresCartuchos formulario = new frmMantenimientoProveedoresCartuchos();

            formulario.ShowDialog(this);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            this.mostarVentanaModificacion();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {

                if (Mensaje.mostrarMensajeConfirmacion("MensajeProveedorCartuchoEliminacion") == DialogResult.Yes)
                {
                    ProveedorCartucho estado = (ProveedorCartucho)dgvProveedoresCartuchos.SelectedRows[0].DataBoundItem;

                    _mantenimiento.eliminarProveedorCartucho(estado);

                    this.eliminarProveedorCartucho(estado);

                    Mensaje.mostrarMensaje("MensajeProveedorCartuchoConfirmacionEliminacion");
                }

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        private void dgvProveedoresCartuchos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1) this.mostarVentanaModificacion();
        }

        private void dgvProveedoresCartuchos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProveedoresCartuchos.RowCount > 0)
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

        #region Metodos Publicos
        /// <summary>
        /// Actualizar las lista de provedores.
        /// </summary>
        public void actualizarLista()
        {
            dgvProveedoresCartuchos.Refresh();
            dgvProveedoresCartuchos.AutoResizeColumns();
        }

        /// <summary>
        /// Agregar un provedor a la lista.
        /// </summary>
        public void agregarProveedorCartucho(ProveedorCartucho provedor)
        {
            BindingList<ProveedorCartucho> provedores = (BindingList<ProveedorCartucho>)dgvProveedoresCartuchos.DataSource;
            provedores.Add(provedor);
        }

        /// <summary>
        /// Eliminar un provedor de la lista.
        /// </summary>
        public void eliminarProveedorCartucho(ProveedorCartucho provedor)
        {
            BindingList<ProveedorCartucho> provedores = (BindingList<ProveedorCartucho>)dgvProveedoresCartuchos.DataSource;

            provedores.Remove(provedor);
            dgvProveedoresCartuchos.AutoResizeColumns();
        }

        #endregion Metodos Publicos

        #region Metodos Privados


        /// <summary>
        /// Mostrar la ventana de modificación.
        /// </summary>
        private void mostarVentanaModificacion()
        {

            try
            {
                ProveedorCartucho estado = (ProveedorCartucho)dgvProveedoresCartuchos.SelectedRows[0].DataBoundItem;

                frmMantenimientoProveedoresCartuchos formulario = new frmMantenimientoProveedoresCartuchos(estado);
                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        #endregion Metodos Privados

       
    }
}
