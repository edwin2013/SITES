using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonObjects.Clases;
using LibreriaMensajes;
using BussinessLayer;

namespace GUILayer.Formularios.Mantenimiento
{
    public partial class frmAdministracionProveedoresEquipos : Form
    {
        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;

        private BindingList<ProveedorEquipo> _proveedores = new BindingList<ProveedorEquipo>();

        #endregion Atributos

        #region Constructor

        public frmAdministracionProveedoresEquipos()
        {
            InitializeComponent();

            _proveedores = _mantenimiento.listarProveedorEquipo(string.Empty);

            dgvProveedoresEquipos.AutoGenerateColumns = false;
            dgvProveedoresEquipos.DataSource = _proveedores;
        }

        #endregion Constructor

        #region Eventos

        private void dgvProveedoresEquipos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProveedoresEquipos.RowCount > 0)
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
    

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmMantenimientoProveedoresEquipos formulario = new frmMantenimientoProveedoresEquipos();

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
                    ProveedorEquipo estado = (ProveedorEquipo)dgvProveedoresEquipos.SelectedRows[0].DataBoundItem;

                    _mantenimiento.eliminarProveedorEquipo(estado);

                    this.eliminarProveedorEquipo(estado);

                    Mensaje.mostrarMensaje("MensajeProveedorCartuchoConfirmacionEliminacion");
                }

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        #endregion Eventos

        #region Metodos Privados


        /// <summary>
        /// Mostrar la ventana de modificación.
        /// </summary>
        private void mostarVentanaModificacion()
        {

            try
            {
                ProveedorEquipo estado = (ProveedorEquipo)dgvProveedoresEquipos.SelectedRows[0].DataBoundItem;

                frmMantenimientoProveedoresEquipos formulario = new frmMantenimientoProveedoresEquipos(estado);
                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        #endregion Metodos Privados

        #region Metodos Publicos
        /// <summary>
        /// Actualizar las lista de provedores.
        /// </summary>
        public void actualizarLista()
        {
            dgvProveedoresEquipos.Refresh();
            dgvProveedoresEquipos.AutoResizeColumns();
        }

        /// <summary>
        /// Agregar un provedor a la lista.
        /// </summary>
        public void agregarProveedorEquipo(ProveedorEquipo provedor)
        {
            BindingList<ProveedorEquipo> provedores = (BindingList<ProveedorEquipo>)dgvProveedoresEquipos.DataSource;
            provedores.Add(provedor);
        }

        /// <summary>
        /// Eliminar un provedor de la lista.
        /// </summary>
        public void eliminarProveedorEquipo(ProveedorEquipo provedor)
        {
            BindingList<ProveedorEquipo> provedores = (BindingList<ProveedorEquipo>)dgvProveedoresEquipos.DataSource;

            provedores.Remove(provedor);
            dgvProveedoresEquipos.AutoResizeColumns();
        }

        #endregion Metodos Publicos

       }
}
