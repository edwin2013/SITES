using BussinessLayer;
using CommonObjects.Clases;
using LibreriaMensajes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GUILayer.Formularios.Mantenimiento
{
    public partial class frmAdministracionPuestos : Form
    {
      
        #region Atributos

        private SeguridadBL _seguridad = SeguridadBL.Instancia;

        #endregion Atributos

        #region Constructor

        public frmAdministracionPuestos()
        {
            InitializeComponent();

            try
            {
                dgvPuestos.AutoGenerateColumns = false;
                dgvPuestos.DataSource = _seguridad.listarPuestos();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion Constructor

        #region Eventos

               
        /// <summary>
        /// Clic en el botón de salir.
        /// </summary>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                frmMantenimientoPuestos formulario = new frmMantenimientoPuestos();

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            this.mostrarVentanaModificacion();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Mensaje.mostrarMensajeConfirmacion("MensajePerfilEliminacion") == DialogResult.Yes)
                {
                    PuestoColaborador puesto = (PuestoColaborador)dgvPuestos.SelectedRows[0].DataBoundItem;

                    _seguridad.eliminarPuesto(puesto);

                    dgvPuestos.Rows.Remove(dgvPuestos.SelectedRows[0]);
                    Mensaje.mostrarMensaje("MensajePerfilConfirmacionEliminacion");
                }

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
                
            }
        }


        private void dgvPuestos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1) this.mostrarVentanaModificacion();
        }

        private void dgvPuestos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPuestos.RowCount > 0)
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

                if (dgvPuestos.SelectedRows.Count > 0)
                {
                    PuestoColaborador puesto = (PuestoColaborador)dgvPuestos.SelectedRows[0].DataBoundItem;
                    frmMantenimientoPuestos formulario = new frmMantenimientoPuestos(puesto);

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
            dgvPuestos.Refresh();
            dgvPuestos.AutoResizeColumns();
        }

        /// <summary>
        /// Agregar un puesto a la lista.
        /// </summary>
        public void agregarPuesto(PuestoColaborador puesto)
        {
            BindingList<PuestoColaborador> puestos = (BindingList<PuestoColaborador>)dgvPuestos.DataSource;

            puestos.Add(puesto);
        }



        #endregion Métodos Públicos

        
    }
}
