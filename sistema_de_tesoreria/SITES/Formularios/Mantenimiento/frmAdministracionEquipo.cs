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
    public partial class frmAdministracionEquipo : Form
    {
         #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private Colaborador _usuario = null;
        #endregion Atributos

        #region Constructor

        public frmAdministracionEquipo(Colaborador usuario)
        {
            InitializeComponent();

            _usuario = usuario;

            try
            {
                // Cargar la lista de Equipo's

                dgvEquipos.AutoGenerateColumns = false;
                dgvEquipos.DataSource = _mantenimiento.listarEquipo(string.Empty);
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
        /// Clic en el boton de actualizar
        /// </summary>
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                string buscado = txtBuscar.Text;

                dgvEquipos.DataSource = _mantenimiento.listarEquipo(buscado);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }


        /// <summary>
        /// Clic en el botón de agregar Equipo.
        /// </summary>
        private void btnNuevo_Click(object sender, EventArgs e)
        {

            try
            {
                frmMantenimientoEquipo formulario = new frmMantenimientoEquipo();

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de modificar Equipo.
        /// </summary>
        private void btnModificar_Click(object sender, EventArgs e)
        {
            this.mostrarVentanaModificacion();
        }

        /// <summary>
        /// Clic en el botón de eliminar Equipo.
        /// </summary>
        private void btnEliminar_Click(object sender, EventArgs e)
        {

            try
            {
                if (Mensaje.mostrarMensajeConfirmacion("MensajeEquipoEliminacion") == DialogResult.Yes)
                {
                    Equipo equipo = (Equipo)dgvEquipos.SelectedRows[0].DataBoundItem;

                    _mantenimiento.eliminarEquipo(equipo);

                    dgvEquipos.Rows.Remove(dgvEquipos.SelectedRows[0]);
                    Mensaje.mostrarMensaje("MensajeEquipoConfirmacionEliminacion");
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
        /// Doble clic en la lista de Equipo's.
        /// </summary>
        private void dgvEquipos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1) this.mostrarVentanaModificacion();
        }

        /// <summary>
        /// Se selecciona otro Equipo de la lista de Equipo's.
        /// </summary>
        private void dgvEquipos_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvEquipos.SelectedRows.Count > 0)
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
                if (dgvEquipos.SelectedRows.Count > 0)
                {
                    Equipo equipo = (Equipo)dgvEquipos.SelectedRows[0].DataBoundItem;
                    frmMantenimientoEquipo formulario = new frmMantenimientoEquipo(equipo);

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
        /// Actualizar las lista de Equipo's.
        /// </summary>
        public void actualizarLista()
        {
            dgvEquipos.Refresh();
            dgvEquipos.AutoResizeColumns();
        }

        /// <summary>
        /// Agregar un Equipo a la lista.
        /// </summary>
        public void agregarEquipo(Equipo equipo)
        {
            BindingList<Equipo> equipos = (BindingList<Equipo>)dgvEquipos.DataSource;

            equipos.Add(equipo);
        }

        #endregion Métodos Públicos

        
    }
}
