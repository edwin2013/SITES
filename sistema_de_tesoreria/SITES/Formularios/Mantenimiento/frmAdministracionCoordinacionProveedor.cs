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
    public partial class frmAdministracionCoordinacionProveedor : Form
    {
        #region Constructor

        public frmAdministracionCoordinacionProveedor()
        {
            InitializeComponent();

            dgvRequerimientos.AutoGenerateColumns = false;
            dgvRequerimientos.DataSource = _mantenimiento.listarRequerimientosMantenimiento();
        }

        #endregion Constructor
       
        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;

        #endregion Atributos

        #region Métodos Públicos

        public void actualizarLista()
        {
            dgvRequerimientos.Refresh();
            dgvRequerimientos.AutoResizeColumns();
        }

        public void agregarRequerimientoMantenimiento(RequerimientoMantenimiento requerimiento)
        {
            BindingList<RequerimientoMantenimiento> requerimientos = (BindingList<RequerimientoMantenimiento>)dgvRequerimientos.DataSource;
            requerimientos.Add(requerimiento);
        }

        #endregion Métodos Públicos

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
                    frmCoordinacionProveedor formulario = new frmCoordinacionProveedor(requerimiento);
                    formulario.ShowDialog(this);
                }

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        #endregion Métodos Privados

        #region Eventos

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            dgvRequerimientos.DataSource = _mantenimiento.listarRequerimientosMantenimiento(dtpFechaInicio.Value, dtpFechaFin.Value);
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

        private void btnModificar_Click(object sender, EventArgs e)
        {
            this.mostarVentanaModificacion();
        }

        #endregion Eventos    
                
    }
}
