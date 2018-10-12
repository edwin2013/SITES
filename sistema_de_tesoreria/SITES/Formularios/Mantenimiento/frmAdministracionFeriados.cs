using BussinessLayer;
using CommonObjects;
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

namespace GUILayer.Formularios.Facturacion
{
    public partial class frmAdministracionFeriados : Form
    {
        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;

        private Colaborador _usuario = null;

        #endregion Atributos

        #region Constructor

        public frmAdministracionFeriados(Colaborador usuario)
        {
            InitializeComponent();

            _usuario = usuario;

            try
            {
                // Cargar la lista de feriados

                dgvFeriados.AutoGenerateColumns = false;
                dgvFeriados.DataSource = _mantenimiento.listarFeriados(_usuario);
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
        /// Clic en el botón de agregar feriado.
        /// </summary>
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                frmMantenimientoFeriado formulario = new frmMantenimientoFeriado(_usuario);

                formulario.Padre = this;
                formulario.ShowDialog();
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
        /// Clic en el botón de terminar.
        /// </summary>
        private void btnTerminar_Click(object sender, EventArgs e)
        {

            try
            {

                if (Mensaje.mostrarMensajeConfirmacion("MensajeFeriadoTerminacion") == DialogResult.Yes)
                {
                    Feriado feriado = (Feriado)dgvFeriados.SelectedRows[0].DataBoundItem;

                    _mantenimiento.terminarFeriado(feriado);

                    dgvFeriados.Rows.Remove(dgvFeriados.SelectedRows[0]);
                    Mensaje.mostrarMensaje("MensajeFeriadoConfirmacionTerminacion");
                }

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de eliminar.
        /// </summary>
        private void btnEliminar_Click(object sender, EventArgs e)
        {

            try
            {

                if (Mensaje.mostrarMensajeConfirmacion("MensajeFeriadoEliminacion") == DialogResult.Yes)
                {
                    Feriado feriado = (Feriado)dgvFeriados.SelectedRows[0].DataBoundItem;

                    _mantenimiento.eliminarFeriado(feriado);

                    dgvFeriados.Rows.Remove(dgvFeriados.SelectedRows[0]);
                    Mensaje.mostrarMensaje("MensajeFeriadoConfirmacionEliminacion");
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
        /// Doble clic en la lista de permisos.
        /// </summary>
        private void dgvFeriados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.mostarVentanaModificacion();
        }

        /// <summary>
        /// Se seleccion un feriado de la lista.
        /// </summary>
        private void dgvFeriados_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvFeriados.SelectedRows.Count > 0)
            {
                btnEliminar.Enabled = true;
                btnModificar.Enabled = true;
                btnTerminar.Enabled = true;
            }
            else
            {
                btnEliminar.Enabled = false;
                btnModificar.Enabled = false;
                btnTerminar.Enabled = false;
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
                Feriado feriado = (Feriado)dgvFeriados.SelectedRows[0].DataBoundItem;
                frmMantenimientoFeriado formulario = new frmMantenimientoFeriado(_usuario, feriado);

                formulario.Padre = this;
                formulario.ShowDialog();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        #endregion Métodos Privados

        #region Métodos Públicos

        /// <summary>
        /// Actualizar la lista de feriados.
        /// </summary>
        public void actualizarLista()
        {
            dgvFeriados.Refresh();
            dgvFeriados.AutoResizeColumns();
        }

        /// <summary>
        /// Agregar un feriado a la lista.
        /// </summary>
        public void agregarFeriado(Feriado feriado)
        {
            BindingList<Feriado> feriados = (BindingList<Feriado>)dgvFeriados.DataSource;

            feriados.Add(feriado);
            dgvFeriados.AutoResizeColumns();
        }

        #endregion Métodos Públicos
    }
}
