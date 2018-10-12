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
using CommonObjects;

namespace GUILayer.Formularios.Mantenimiento
{
    public partial class frmAdministracionSolicitudRequerimientos : Form
    {

        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private Colaborador _usuario = new Colaborador();

        #endregion Atributos

        #region Constructor

        public frmAdministracionSolicitudRequerimientos(Colaborador usuario)
        {
            InitializeComponent();

            _usuario = usuario;
            dgvRequerimientos.AutoGenerateColumns = false;
            dgvRequerimientos.DataSource = _mantenimiento.listarRequerimientosMantenimiento();
        }

        #endregion Constructor

        #region Métodos Privados

        /// <summary>
        /// Mostrar la ventana de modificación.
        /// </summary>
        public void mostarVentanaModificacion()
        {

            try
            {
                if (dgvRequerimientos.SelectedRows.Count > 0)
                {
                    RequerimientoMantenimiento requerimiento = (RequerimientoMantenimiento)dgvRequerimientos.SelectedRows[0].DataBoundItem;
                    frmSolicitudRequerimientos formulario = new frmSolicitudRequerimientos(requerimiento);

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
        /// Actualizar las lista de requerimientos.
        /// </summary>
        public void actualizarLista()
        {
            dgvRequerimientos.Refresh();
            dgvRequerimientos.AutoResizeColumns();
        }

        /// <summary>
        /// Agregar un requerimiento a la lista.
        /// </summary>
        public void agregarRequerimientoMantenimiento(RequerimientoMantenimiento requerimiento)
        {
            BindingList<RequerimientoMantenimiento> requerimientos = (BindingList<RequerimientoMantenimiento>)dgvRequerimientos.DataSource;

            requerimientos.Add(requerimiento);
        }

        #endregion Métodos Públicos

        #region Eventos
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                frmSolicitudRequerimientos formulario = new frmSolicitudRequerimientos(_usuario);

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            this.mostarVentanaModificacion();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Mensaje.mostrarMensajeConfirmacion("MensajeRequerimientoMantenimientoEliminacion") == DialogResult.Yes)
                {
                    RequerimientoMantenimiento requerimiento = (RequerimientoMantenimiento)dgvRequerimientos.SelectedRows[0].DataBoundItem;

                    _mantenimiento.eliminarRequerimientoMantenimiento(requerimiento);

                    dgvRequerimientos.Rows.Remove(dgvRequerimientos.SelectedRows[0]);
                    Mensaje.mostrarMensaje("MensajeRequerimientoMantenimientoConfirmacionEliminacion");
                }

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        private void dgvRequerimientos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRequerimientos.SelectedRows.Count > 0)
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
       
    }
}
