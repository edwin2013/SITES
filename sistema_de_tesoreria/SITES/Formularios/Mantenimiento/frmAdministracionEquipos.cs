using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LibreriaMensajes;
using CommonObjects.Clases;
using BussinessLayer;

namespace GUILayer.Formularios.Mantenimiento
{
    public partial class frmAdministracionEquipos : Form
    {
        #region Atributos
        private MantenimientoBL _manejador = MantenimientoBL.Instancia;

        #endregion Atributos

        #region Constructor
        public frmAdministracionEquipos()
        {
            InitializeComponent();


            dgvEquipos.AutoGenerateColumns = false;

            dgvEquipos.DataSource = _manejador.listarEquiposTesoreria();

        }

        #endregion Constructor

        #region Eventos

        private void dgvEquipos_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (dgvEquipos.Rows.Count == 0)
            {
                btnEliminar.Enabled = false;
                btnModificar.Enabled = false;
            }
        }

        private void dgvEquipos_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            btnEliminar.Enabled = true;
            btnModificar.Enabled = true;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                frmMantenimientoEquipos formulario = new frmMantenimientoEquipos(this);
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
                if (Mensaje.mostrarMensajeConfirmacion("MensajeEquipoEliminacion") == DialogResult.Yes)
                {
                    EquipoTesoreria equipo = (EquipoTesoreria)dgvEquipos.SelectedRows[0].DataBoundItem;

                    _manejador.eliminarEquipoTesoreria(equipo);
                    dgvEquipos.Rows.Remove(dgvEquipos.SelectedRows[0]);
                    Mensaje.mostrarMensaje("MensajeEquipoConfirmacionEliminacion");
                }

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje(); ;
            }
        }

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
                if (dgvEquipos.SelectedRows.Count > 0)
                {
                    EquipoTesoreria equipo = (EquipoTesoreria)dgvEquipos.SelectedRows[0].DataBoundItem;
                    frmMantenimientoEquipos formulario = new frmMantenimientoEquipos(equipo,this);
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

        public void actualizarLista()
        {
            dgvEquipos.Refresh();
            dgvEquipos.AutoResizeColumns();
        }

        public void agregarEquipo(EquipoTesoreria equipo)
        {
            BindingList<EquipoTesoreria> equipos = (BindingList<EquipoTesoreria>)dgvEquipos.DataSource;
            equipos.Add(equipo);
        }

        #endregion Métodos Públicos
        
    }
}
