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
    public partial class frmAdministracionCalidadBilletes : Form
    {
        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;

        #endregion Atributos

        #region Constructor
        public frmAdministracionCalidadBilletes()
        {
            InitializeComponent();

            dgvCalidadBilletes.AutoGenerateColumns = false;
            dgvCalidadBilletes.DataSource = _mantenimiento.listarCalidadBilletes(string.Empty);
        }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Actualizar las lista de calidad de billetes.
        /// </summary>
        public void actualizarLista()
        {
            dgvCalidadBilletes.Refresh();
            dgvCalidadBilletes.AutoResizeColumns();
        }

        /// <summary>
        /// Agregar una cañlidad de billetes a la lista.
        /// </summary>
        public void agregarCalidadBilletes(CalidadBilletes calidad)
        {
            BindingList<CalidadBilletes> calidades = (BindingList<CalidadBilletes>)dgvCalidadBilletes.DataSource;
            calidades.Add(calidad);
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

                if (dgvCalidadBilletes.SelectedRows.Count > 0)
                {
                    CalidadBilletes calidad = (CalidadBilletes)dgvCalidadBilletes.SelectedRows[0].DataBoundItem;
                    frmMantenimientoCalidadBilletes formulario = new frmMantenimientoCalidadBilletes(calidad, this);
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

        private void dgvCalidadBilletes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1) this.mostarVentanaModificacion();
        }

        private void dgvCalidadBilletes_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvCalidadBilletes.SelectedRows.Count > 0)
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

        private void btnNueva_Click(object sender, EventArgs e)
        {
            try
            {
                frmMantenimientoCalidadBilletes formulario = new frmMantenimientoCalidadBilletes(this);
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
                if (Mensaje.mostrarMensajeConfirmacion("MensajeEmpresaTransporteEliminacion") == DialogResult.Yes)
                {
                    CalidadBilletes calidad = (CalidadBilletes)dgvCalidadBilletes.SelectedRows[0].DataBoundItem;

                    _mantenimiento.eliminarCalidadBilletes(calidad);
                    dgvCalidadBilletes.Rows.Remove(dgvCalidadBilletes.SelectedRows[0]);
                    Mensaje.mostrarMensaje("MensajeEmpresaTransporteConfirmacionEliminacion");
                }

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje(); ;
            }
        }

        #endregion Eventos

    }
}
